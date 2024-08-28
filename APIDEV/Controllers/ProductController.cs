using APIDEV.Helper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIDEV.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IWebHostEnvironment environment;

        public ProductController(IWebHostEnvironment environment)
        {
            this.environment = environment;
        }

        [HttpPut("UploadImage")]
        public async Task<IActionResult> UploadImage(IFormFile formFile, string productcode)
        {
            APIResponse response = new APIResponse();
            try
            {
                string Filepath = GetFilepath(productcode);
                if (!System.IO.Directory.Exists(Filepath))
                {
                    System.IO.Directory.CreateDirectory(Filepath);
                }

                string imagepath = Filepath + "\\" + productcode + ".png";
                if (System.IO.File.Exists(imagepath))
                {
                    System.IO.File.Delete(imagepath);
                }
                using (FileStream stream = System.IO.File.Create(imagepath))
                {
                    await formFile.CopyToAsync(stream);
                    response.ResponseCode = 200;
                    response.Result = "pass";
                }
            }
            catch (Exception ex)
            {
                response.Errormessage = ex.Message;
            }
            return Ok(response);
        }

        [NonAction]

        private string GetFilepath(string productcode)
        {
            return this.environment.WebRootPath + "\\Upload\\product\\" + productcode;
        }
    }
}
