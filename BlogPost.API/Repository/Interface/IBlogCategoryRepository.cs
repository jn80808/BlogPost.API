using BlogPost.API.Model.Domain;

namespace BlogPost.API.Repository.Interface
{
    public interface IBlogCategoryRepository
    {
        Task<IEnumerable<BlogCategory>> GetAllAsync(string? query = null);
        Task<BlogCategory?> GetByIdAsync(Guid id);
        Task<BlogCategory> CreateAsync(BlogCategory category);
        Task<BlogCategory?> UpdateAsync(BlogCategory category);
        Task<bool> DeleteAsync(Guid id);

        Task<bool> ExistsAsync(string name, string description);


    }
}
