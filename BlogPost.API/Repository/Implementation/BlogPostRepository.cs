using BlogPost.API.DTOs;
using BlogPost.API.Model.Domain;
using BlogPostSystem;
using Microsoft.EntityFrameworkCore;

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
            return await _context.BlogPosts.ToListAsync();
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
            var blogPost = await _context.BlogPosts.FindAsync(id);
            if (blogPost == null) return null;

            blogPost.Title = dto.Title;
            blogPost.ShortDescription = dto.ShortDescription;
            blogPost.Content = dto.Content;
            blogPost.FeatureImageUrl = dto.FeatureImageUrl;
            blogPost.AuthorName = dto.AuthorName;
            blogPost.UrlHandle = dto.UrlHandle;
            blogPost.PublishedDate = dto.PublishedDate;
            blogPost.IsVisible = dto.IsVisible;
            blogPost.IsPublished = dto.IsPublished;
            blogPost.CategoryId = dto.CategoryId;

            await _context.SaveChangesAsync();
            return blogPost;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var blogPost = await _context.BlogPosts.FindAsync(id);
            if (blogPost == null) return false;

            _context.BlogPosts.Remove(blogPost);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
