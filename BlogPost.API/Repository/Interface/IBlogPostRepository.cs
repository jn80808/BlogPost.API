using BlogPost.API.DTOs;
using BlogPost.API.Model.Domain;

namespace BlogPost.API.Repositories
{
    public interface IBlogPostRepository
    {
        Task<IEnumerable<BlogPostT>> GetAllAsync();
        Task<BlogPostT?> GetByIdAsync(Guid id);
        Task<BlogPostT> AddAsync(BlogPostT blogPost);
        Task<BlogPostT?> UpdateAsync(Guid id, UpdateBlogPostDTO dto);
        Task<bool> DeleteAsync(Guid id);
    }
}
