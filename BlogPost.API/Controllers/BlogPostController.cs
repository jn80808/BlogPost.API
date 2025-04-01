using Microsoft.AspNetCore.Mvc;
using BlogPost.API.DTOs;
using BlogPost.API.Model.Domain;
using BlogPost.API.Repositories;

namespace BlogPost.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogPostController : ControllerBase
    {
        private readonly IBlogPostRepository _blogPostRepository;

        // Constructor now accepts IBlogPostRepository instead of DbContext
        public BlogPostController(IBlogPostRepository blogPostRepository)
        {
            _blogPostRepository = blogPostRepository;
        }

        // GET: api/BlogPost
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BlogPostDTO>>> GetBlogPosts()
        {
            var blogPosts = await _blogPostRepository.GetAllAsync();
            var response = blogPosts.Select(bp => new BlogPostDTO
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
            }).ToList();

            return Ok(response);
        }

        // GET: api/BlogPost/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<BlogPostDTO>> GetBlogPost(Guid id)
        {
            var blogPost = await _blogPostRepository.GetByIdAsync(id);
            if (blogPost == null)
            {
                return NotFound(new { message = "Blog post not found." });
            }

            var response = new BlogPostDTO
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
            };

            return Ok(response);
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

            var createdBlogPost = await _blogPostRepository.AddAsync(blogPost);

            var response = new BlogPostDTO
            {
                Id = createdBlogPost.Id,
                Title = createdBlogPost.Title,
                ShortDescription = createdBlogPost.ShortDescription,
                Content = createdBlogPost.Content,
                FeatureImageUrl = createdBlogPost.FeatureImageUrl,
                AuthorName = createdBlogPost.AuthorName,
                UrlHandle = createdBlogPost.UrlHandle,
                PublishedDate = createdBlogPost.PublishedDate,
                IsVisible = createdBlogPost.IsVisible,
                IsPublished = createdBlogPost.IsPublished,
                CategoryId = createdBlogPost.CategoryId,
                CreatedAt = createdBlogPost.CreatedAt
            };

            return CreatedAtAction(nameof(GetBlogPost), new { id = response.Id }, response);
        }

        // PUT: api/BlogPost/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBlogPost(Guid id, [FromBody] UpdateBlogPostDTO dto)
        {
            // Check if the model state is valid
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Call the repository to update the blog post
            var updatedBlogPost = await _blogPostRepository.UpdateAsync(id, dto);

            // If the blog post wasn't found, return NotFound
            if (updatedBlogPost == null)
            {
                return NotFound(new { message = "Blog post not found." });
            }

            // Create the updated BlogPostDTO
            var response = new BlogPostDTO
            {
                Id = updatedBlogPost.Id,
                Title = updatedBlogPost.Title,
                ShortDescription = updatedBlogPost.ShortDescription,
                Content = updatedBlogPost.Content,
                FeatureImageUrl = updatedBlogPost.FeatureImageUrl,
                AuthorName = updatedBlogPost.AuthorName,
                UrlHandle = updatedBlogPost.UrlHandle,
                PublishedDate = updatedBlogPost.PublishedDate,
                IsVisible = updatedBlogPost.IsVisible,
                IsPublished = updatedBlogPost.IsPublished,
                CategoryId = updatedBlogPost.CategoryId,
                CreatedAt = updatedBlogPost.CreatedAt
            };

            // Return a success message along with the updated data
            return Ok(new { message = "Successfully updated", response });
        }

        // DELETE: api/BlogPost/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBlogPost(Guid id)
        {
            // Call the repository to delete the blog post
            var result = await _blogPostRepository.DeleteAsync(id);

            // If the blog post was not found, return NotFound
            if (!result)
            {
                return NotFound(new { message = "Blog post not found." });
            }

            // Return a success message after successful deletion
            return Ok(new { message = "Blog post successfully deleted." });
        }


    }
}
