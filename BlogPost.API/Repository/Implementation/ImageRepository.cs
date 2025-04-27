using BlogPost.API.Model.Domain;
using BlogPost.API.Repository.Interface;
using BlogPostSystem;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace BlogPost.API.Repository.Implementation
{
    public class ImageRepository : IImageRepository
    {
        private IWebHostEnvironment webHostEnvironment;
        private IHttpContextAccessor httpContextAccessor;
        private BlogPostDbContext dbContext;

        public ImageRepository(IWebHostEnvironment webHostEnvironment,
            IHttpContextAccessor httpContextAccessor,
            BlogPostDbContext dbContext) 
        {
            this.webHostEnvironment = webHostEnvironment;
            this.httpContextAccessor = httpContextAccessor;
            this.dbContext = dbContext;
        }


        public async Task<IEnumerable<BlogImage>> GetAll()
        {
            return await dbContext.BlogImage.ToListAsync();
        }



        public async Task<BlogImage> Upload(IFormFile file, BlogImage blogImage)
        {
            //1- Upload the Image to API/Image 
            var localPath = Path.Combine(webHostEnvironment.ContentRootPath, "Images", $"{blogImage.FileName}{blogImage.FileExtension}");

            using var stream = new FileStream(localPath, FileMode.Create);
            await file.CopyToAsync(stream);



            //2- Update the database 
            //https://codepulse.com/images/somefilename.jpg
            var httpRequest = httpContextAccessor.HttpContext.Request;
            var urlPath = $"{httpRequest.Scheme}://{httpRequest.Host}{httpRequest.PathBase}/Images/{blogImage.FileName}{blogImage.FileExtension}";

            blogImage.Url = urlPath;

            await dbContext.BlogImage.AddAsync(blogImage);
            await dbContext.SaveChangesAsync();

            return blogImage;
        }
    }
}
