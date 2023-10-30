using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace SecurityApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Upload(IFormFile file)
        {

            // Save the uploaded file to a temporary location
            var path = Path.GetTempFileName();
            using (var stream = System.IO.File.Create(path))
            {
                await file.CopyToAsync(stream);
            }

            // Do something with the uploaded file
            // ...

            return Ok("File uploaded");
        }
    }
}
