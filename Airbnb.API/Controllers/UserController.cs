using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Protocols;
using Airbnb.DAL;
using Airbnb.BL;
using Microsoft.Extensions.Configuration;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Airbnb.DAL.Data;
using Airbnb.BL.DTO.DataUser;

namespace Airbnb.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMailingService mailing;
        private readonly AircbnbContext _context;

        private readonly IConfiguration _configuration;
        private readonly UserManager<User> _userManager;
        private readonly IMailingService mailingService;

        public UserController(IConfiguration configuration, UserManager<User> userManager, IMailingService _mailingService, AircbnbContext context )
        {
            _configuration = configuration;
            _userManager = userManager;
            this.mailingService = _mailingService;
            _context = context;
        }

        #region Register

        [HttpPost]
        [Route("Register")]
        public async Task<ActionResult> RegisterAsAppUser(RegisterDto registerDto)
        {
            var user = new User
            {
                FirstName = registerDto.FirstName,
                LasttName = registerDto.LastttName,
                UserName = registerDto.UserName,
                Email = registerDto.Email,
            };

            var creationResult = await _userManager.CreateAsync(user, registerDto.Password);
            if (!creationResult.Succeeded)
            {
                return BadRequest(creationResult.Errors);
            }

            var claims = new List<Claim>
            {
                new (ClaimTypes.NameIdentifier, user.Id),
            };

            var addingClaimsResult = await _userManager.AddClaimsAsync(user, claims);
            if (!addingClaimsResult.Succeeded)
            {
                return BadRequest(addingClaimsResult.Errors);
            }

            return NoContent();
        }

        #endregion

        #region Login

        [HttpPost]
        [Route("Login")]
        public async Task<ActionResult<TokenDto>> Login(LoginDto credentials)
        {
            var user = await _userManager.FindByNameAsync(credentials.UserName);
            if (user == null)
            {
                return BadRequest();
            }

            bool isPasswordCorrect = await _userManager.CheckPasswordAsync(user, credentials.Password);
            if (!isPasswordCorrect)
            {
                return BadRequest();
            }

            List<Claim> claimsList = (await _userManager.GetClaimsAsync(user)).ToList();

            var keyString = _configuration.GetValue<string>("SecretKey");
            var keyInBytes = Encoding.ASCII.GetBytes(keyString!);
            var key = new SymmetricSecurityKey(keyInBytes);

            // Hashing Criteria 
            SigningCredentials signingCredentials = new SigningCredentials(key,
                SecurityAlgorithms.HmacSha256Signature);

            // Putting All together
            DateTime exp = DateTime.Now.AddMinutes(200);
            JwtSecurityToken token = new JwtSecurityToken(
                    claims: claimsList,
                    signingCredentials: signingCredentials,
                    expires: exp
                );

            var tokenHandler = new JwtSecurityTokenHandler();
            string tokenString = tokenHandler.WriteToken(token);

            return new TokenDto
            {
                Token = tokenString,
                Expiry = exp,
            };
        }

        #endregion

        #region Sending Email

        [HttpPost]
        [Route("Send_Email")]
        public async Task<ActionResult> SendEmail([FromForm] MailRequestDto mailRequestDto)
        {
            await mailingService.SendEmailAsync(mailRequestDto.ToEmail, mailRequestDto.Subject, mailRequestDto.Body);

            return Ok("Email Sending Successfully!!!");
        }

        #endregion


        #region Forget_Password
        [HttpPost]
        [Route("Forget_Password")]
        public async Task<ActionResult> Forget_Password([FromForm] string email)
        {

            if (string.IsNullOrEmpty(email))
            {
                return BadRequest("Email is Invalid!!!!");
            }

            User? user = await _userManager.FindByEmailAsync(email);
            if (user is null)
            {
                return BadRequest("User not found with the given email.");
            }

            var random = new Random();
            var code = random.Next(100000, 999999).ToString();
            user.Code = code;
            _context.SaveChanges();

            await mailingService.SendEmailAsync(email, "Reset Password", $"<h1>Your Code is {code}</h1>");

            var response = new
            {
                message = "Reset Password Email has been Sent Successfully!!!"
            };

            return Ok(response);
        }

        #endregion



        #region reset_password
        [HttpPost]
        [Route("Reset_Password")]
        public async Task<ActionResult> ResetPassword(UserResetPasswordDto userResetPasswordDto)
        {
            User? user = await _userManager.FindByEmailAsync(userResetPasswordDto.Email);
            if (user is null)
            {
                return NotFound("user not found!!!");
            }

            if (userResetPasswordDto.NewPassword != userResetPasswordDto.ConfirmNewPassword)
            {
                return BadRequest("passwored dosen't match confirmation!");
            }

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            //var encodedtoken = Encoding.UTF8.GetBytes(token);
            //var validtoken = WebEncoders.Base64UrlEncode(encodedtoken);

            var result = await _userManager.ResetPasswordAsync(user, token, userResetPasswordDto.NewPassword);

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            var response = new
            {
                message = "Password has been Reset Successfully!!!"
            };

            return Ok(response);
        }
        #endregion
    }
}
