using BlogPost.API.Model.Domain;
using BlogPost.API.Model.DTO;
using BlogPost.API.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogPost.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private IImageRepository imageRepository;

        public ImagesController(IImageRepository imageRepository) 
        {
            this.imageRepository = imageRepository;
        }


        //POST : {apibaseUrl}/api/images 
        [HttpPost]
        public async Task<IActionResult> UploadImage([FromForm] IFormFile file,
            [FromForm] string fileName, [FromForm] string title)
        {
            ValidateFileUpload(file);

            if(ModelState.IsValid) 
            {
                //File Upload
                var blogImage = new BlogImage
                { 
                    FileExtension = Path.GetExtension(file.FileName).ToLower(),
                    FileName = fileName,
                    Title = title,
                    DateCreated= DateTime.Now

                };

                blogImage =  await imageRepository.Upload(file, blogImage);

                //Convert Domain Model to DTO 
                var response = new BlogImageDTO
                {
                    Id = blogImage.Id,
                    FileName = blogImage.FileName,
                    Title = blogImage.Title,
                    DateCreated = blogImage.DateCreated,
                    FileExtension = blogImage.FileExtension,
                    Url = blogImage.Url
                };

                return Ok(response);

            }

            return BadRequest();



        }

        private void ValidateFileUpload(IFormFile file)
        {
            var allowedExtensions = new string[] { ".jpeg",".jpg",".png",".pdf" };

            if (!allowedExtensions.Contains(Path.GetExtension(file.FileName).ToLower())) 
            {
                ModelState.AddModelError("file", "Unsupported file format");
            }

            if (file.Length > 10485760)
            {
                ModelState.AddModelError("file", "File size cannot be more than 10MB");
            }

        }


    }
}
