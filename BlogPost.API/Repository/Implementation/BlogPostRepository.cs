using BlogPost.API.DTOs;
using BlogPost.API.Model.Domain;
using BlogPostSystem;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace BlogPost.API.Repositories
{
    public class BlogPostRepository : IBlogPostRepository
    {
        private readonly BlogPostDbContext _context;

        //contructor 
        public BlogPostRepository(BlogPostDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<BlogPostT>> GetAllAsync()
        {
            return await _context.BlogPosts.Include(x => x.Categories).ToListAsync();
        }

        public async Task<BlogPostT?> GetByIdAsync(Guid id)
        {
            return await _context.BlogPosts.FindAsync(id);
        }

        public async Task<BlogPostT> AddAsync(BlogPostT blogPost)
        {
            _context.BlogPosts.Add(blogPost);
            await _context.SaveChangesAsync();
            return blogPost;
        }

        public async Task<bool> TitleExistsAsync(string title)
        {
            return await _context.BlogPosts.AnyAsync(bp => bp.Title == title);
        }


        public async Task<BlogPostT?> UpdateAsync(Guid id, UpdateBlogPostDTO dto)
        {
            var existingBlogPost = await _context.BlogPosts
                .Include(bp => bp.Categories)
                .FirstOrDefaultAsync(bp => bp.Id == id);

            if (existingBlogPost == null)
            {
                return null;
            }

            // Update scalar properties
            existingBlogPost.Title = dto.Title;
            existingBlogPost.ShortDescription = dto.ShortDescription;
            existingBlogPost.Content = dto.Content;
            existingBlogPost.FeatureImageUrl = dto.FeatureImageUrl;
            existingBlogPost.AuthorName = dto.AuthorName;
            existingBlogPost.UrlHandle = dto.UrlHandle;
            existingBlogPost.PublishedDate = dto.PublishedDate;
            existingBlogPost.IsVisible = dto.IsVisible;
            existingBlogPost.IsPublished = dto.IsPublished;
            existingBlogPost.CategoryId = dto.CategoryId;


            // Clear existing categories
            existingBlogPost.Categories?.Clear();

            // Re-assign categories based on IDs in dto
            if (dto.Categories != null && dto.Categories.Count > 0)
            {
                var validCategories = await _context.Categories
                    .Where(c => dto.Categories.Contains(c.Id))
                    .ToListAsync();

                existingBlogPost.Categories = validCategories;
            }

            await _context.SaveChangesAsync();

            return existingBlogPost;
        }


        public async Task<bool> DeleteAsync(Guid id)
        {
            var blogPost = await _context.BlogPosts.FindAsync(id);
            if (blogPost == null) return false;

            _context.BlogPosts.Remove(blogPost);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<BlogPostT?> GetByUrlHandleAsync(string urlHandle)
        {
            return await _context.BlogPosts
                .Include(x => x.Categories)
                .FirstOrDefaultAsync(x => x.UrlHandle == urlHandle);
        }


    }
}
