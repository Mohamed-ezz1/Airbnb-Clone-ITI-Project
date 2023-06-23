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

namespace Airbnb.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly UserManager<User> _userManager;

        public UserController(IConfiguration configuration, UserManager<User> userManager)
        {
            _configuration = configuration;
          _userManager = userManager;
        }

        #region Register

        [HttpPost]
        [Route("Register")]
        public ActionResult RegisterAsAppUser(RegisterDto  registerDto)
        {
            var user = new User
            {
                FirstName = registerDto.FirstName,
                LasttName = registerDto.LastttName,
                UserName = registerDto.UserName,
                Email = registerDto.Email,
            };

            //.Result to overcome async
            var creationResult = _userManager.CreateAsync(user, registerDto.Password).Result;
            if (!creationResult.Succeeded)
            {
                return BadRequest(creationResult.Errors);
            }

            var claims = new List<Claim>
        {
            new (ClaimTypes.NameIdentifier, user.Id),
        };

            var addingClaimsResult = _userManager.AddClaimsAsync(user, claims).Result;
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
        public ActionResult<TokenDto> Login(LoginDto credentials)
        {
           var user = _userManager.FindByNameAsync(credentials.UserName).Result;
            if (user == null)
            {
                return BadRequest();
            }

            bool isPasswordCorrect = _userManager.CheckPasswordAsync(user, credentials.Password).Result;
            if (!isPasswordCorrect)
            {
                return BadRequest();
            }

            List<Claim> claimsList = _userManager.GetClaimsAsync(user).Result.ToList();

            var keyString = _configuration.GetValue<string>("SecretKey");
            var keyInBytes = Encoding.ASCII.GetBytes(keyString!);
            var key = new SymmetricSecurityKey(keyInBytes);

            //Hashing Criteria 
            SigningCredentials signingCredentials = new SigningCredentials(key,
                SecurityAlgorithms.HmacSha256Signature);

            //Putting All together
            DateTime exp = DateTime.Now.AddMinutes(20);
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

    }
}
