using BlogPost.API.DTOs;
using BlogPost.API.Model.Domain;

namespace BlogPost.API.Repositories
{
    public interface IBlogPostRepository
    {
        Task<IEnumerable<BlogPostT>> GetAllAsync(string? query = null);
        Task<BlogPostT?> GetByIdAsync(Guid id);
        Task<BlogPostT?> GetByUrlHandleAsync(string urlHandle);
        Task<BlogPostT> AddAsync(BlogPostT blogPost);
        Task<BlogPostT?> UpdateAsync(Guid id, UpdateBlogPostDTO dto);
        Task<bool> DeleteAsync(Guid id);

        Task<bool> TitleExistsAsync(string title);


    }
}
