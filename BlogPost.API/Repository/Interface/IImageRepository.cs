using BlogPost.API.Model.Domain;

namespace BlogPost.API.Repository.Interface
{
    public interface IImageRepository
    {
        Task<BlogImage> Upload(IFormFile file, BlogImage blogImage);
    }
}
