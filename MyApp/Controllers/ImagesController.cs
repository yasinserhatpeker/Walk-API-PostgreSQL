using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyApp.Models.DTOs.Image;

namespace MyApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {

        public async Task<IActionResult> Upload(ImageUploadRequestDTO imageUploadRequestDTO)
        {
            ValidateFileUpload(imageUploadRequestDTO);
            if (ModelState.IsValid)
            {
                // user repository to upload the image
            }
            return BadRequest(ModelState);
        }
        
        private void ValidateFileUpload(ImageUploadRequestDTO imageUploadRequestDTO)
        {
            var allowedExtensions = new string[] { ".jpg", ".jpeg", "png" };

            if (!allowedExtensions.Contains(Path.GetExtension(imageUploadRequestDTO.File.FileName)))
            {
                ModelState.AddModelError("file", "Unsupported file extension");
            }
            if (imageUploadRequestDTO.File.Length > 10485760)
            {
                ModelState.AddModelError("file", "File size is more than 10MB, please upload a smaller file.");
            }
            
        }
     }
}
