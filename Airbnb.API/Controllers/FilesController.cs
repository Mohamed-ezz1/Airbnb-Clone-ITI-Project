using Airbnb.BL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Airbnb.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        [HttpPost]
        public ActionResult<UploadFileResultDto> Upload(IFormFile file)
        {
            var  extension = Path.GetExtension(file.FileName);

            var allowedExtension = new string[]
            {
                ".png",
                ".jpg",
                ".avg",
                ".webp"
            };

            bool isAllowedExtension = allowedExtension.Contains(extension,StringComparer.InvariantCultureIgnoreCase);

            if (!isAllowedExtension) 
            {
                return BadRequest(new UploadFileResultDto (  false, "is not valid" , " " )) ;
            }


            bool isSizedAllowed = file.Length is > 0 and <= 1_000_000;

            if(!isAllowedExtension) 
            { 
                return BadRequest(new UploadFileResultDto(false, "is not valid", " "));
            }


            var newFileNmae = $"{Guid.NewGuid()}{extension}";

            var imagesPath = Path.Combine(Environment.CurrentDirectory, "Images");

            var fulFilePath = Path.Combine(imagesPath, newFileNmae);

            using var stream =  new FileStream(fulFilePath, FileMode.Create);
            file.CopyTo(stream);

            //D:\dot net iti\finalprojectititbackend\Airbnb\Airbnb.API\Images\
            var url = $"{Request.Scheme}://{Request.Host}/Images/{newFileNmae}";
            return new UploadFileResultDto (true,"Suceess", url) ;
        }

    }
}
