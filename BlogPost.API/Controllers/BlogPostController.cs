using Microsoft.AspNetCore.Mvc;
using BlogPost.API.DTOs;
using BlogPost.API.Model.Domain;
using Microsoft.EntityFrameworkCore;
using BlogPostSystem;

namespace BlogPost.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogPostController : ControllerBase
    {
        private readonly BlogPostDbContext _context;

        public BlogPostController(BlogPostDbContext context)
        {
            _context = context;
        }

        // GET: api/BlogPost
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BlogPostDTO>>> GetBlogPosts()
        {
            var blogPosts = await _context.BlogPosts
                .Select(bp => new BlogPostDTO
                {
                    Id = bp.Id,
                    Title = bp.Title,
                    ShortDescription = bp.ShortDescription,
                    Content = bp.Content,
                    FeatureImageUrl = bp.FeatureImageUrl,
                    AuthorName = bp.AuthorName,
                    UrlHandle = bp.UrlHandle,
                    PublishedDate = bp.PublishedDate,
                    IsVisible = bp.IsVisible,
                    IsPublished = bp.IsPublished,
                    CategoryId = bp.CategoryId,
                    CreatedAt = bp.CreatedAt
                })
                .ToListAsync();

            return Ok(blogPosts);
        }

        // GET: api/BlogPost/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<BlogPostDTO>> GetBlogPost(Guid id)
        {
            var blogPost = await _context.BlogPosts.FindAsync(id);

            if (blogPost == null)
            {
                return NotFound(new { message = "Blog post not found." });
            }

            return Ok(new BlogPostDTO
            {
                Id = blogPost.Id,
                Title = blogPost.Title,
                ShortDescription = blogPost.ShortDescription,
                Content = blogPost.Content,
                FeatureImageUrl = blogPost.FeatureImageUrl,
                AuthorName = blogPost.AuthorName,
                UrlHandle = blogPost.UrlHandle,
                PublishedDate = blogPost.PublishedDate,
                IsVisible = blogPost.IsVisible,
                IsPublished = blogPost.IsPublished,
                CategoryId = blogPost.CategoryId,
                CreatedAt = blogPost.CreatedAt
            });
        }

        // POST: api/BlogPost
        [HttpPost]
        public async Task<ActionResult<BlogPostDTO>> CreateBlogPost([FromBody] CreateBlogPostDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var blogPost = new BlogPostT
            {
                Id = Guid.NewGuid(),
                Title = dto.Title,
                ShortDescription = dto.ShortDescription,
                Content = dto.Content,
                FeatureImageUrl = dto.FeatureImageUrl,
                AuthorName = dto.AuthorName,
                UrlHandle = dto.UrlHandle,
                PublishedDate = dto.PublishedDate,
                IsVisible = dto.IsVisible,
                IsPublished = dto.IsPublished,
                CategoryId = dto.CategoryId,
                CreatedAt = DateTime.UtcNow
            };

            _context.BlogPosts.Add(blogPost);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetBlogPost), new { id = blogPost.Id }, new BlogPostDTO
            {
                Id = blogPost.Id,
                Title = blogPost.Title,
                ShortDescription = blogPost.ShortDescription,
                Content = blogPost.Content,
                FeatureImageUrl = blogPost.FeatureImageUrl,
                AuthorName = blogPost.AuthorName,
                UrlHandle = blogPost.UrlHandle,
                PublishedDate = blogPost.PublishedDate,
                IsVisible = blogPost.IsVisible,
                IsPublished = blogPost.IsPublished,
                CategoryId = blogPost.CategoryId,
                CreatedAt = blogPost.CreatedAt
            });
        }

        // PUT: api/BlogPost/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBlogPost(Guid id, [FromBody] UpdateBlogPostDTO dto)
        {
            var blogPost = await _context.BlogPosts.FindAsync(id);
            if (blogPost == null)
            {
                return NotFound(new { message = "Blog post not found." });
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

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

            return NoContent();
        }
    }
}
