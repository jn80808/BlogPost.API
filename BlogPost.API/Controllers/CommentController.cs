using Microsoft.AspNetCore.Mvc;
using BlogPost.API.DTOs;
using BlogPost.API.Model.Domain;
using Microsoft.EntityFrameworkCore;
using BlogPostSystem;

namespace BlogPost.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly BlogPostDbContext _context;

        public CommentController(BlogPostDbContext context)
        {
            _context = context;
        }

        // GET: api/Comment/blogPost/{blogPostId}
        [HttpGet("blogPost/{blogPostId}")]
        public async Task<ActionResult<IEnumerable<CommentDTO>>> GetComments(Guid blogPostId)
        {
            var comments = await _context.Comments
                .Where(c => c.BlogPostId == blogPostId)
                .Select(c => new CommentDTO
                {
                    Id = c.Id,
                    BlogPostId = c.BlogPostId,
                    AuthorName = c.AuthorName,
                    Content = c.Content,
                    CreatedAt = c.CreatedAt
                })
                .ToListAsync();

            return Ok(comments);
        }

        // GET: api/Comment/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<CommentDTO>> GetComment(Guid id)
        {
            var comment = await _context.Comments.FindAsync(id);
            if (comment == null)
            {
                return NotFound(new { message = "Comment not found." });
            }

            return Ok(new CommentDTO
            {
                Id = comment.Id,
                BlogPostId = comment.BlogPostId,
                AuthorName = comment.AuthorName,
                Content = comment.Content,
                CreatedAt = comment.CreatedAt
            });
        }

        // POST: api/Comment
        [HttpPost]
        public async Task<ActionResult<CommentDTO>> CreateComment([FromBody] CreateCommentDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Ensure the referenced BlogPost exists
            var blogPostExists = await _context.BlogPosts.AnyAsync(bp => bp.Id == dto.BlogPostId);
            if (!blogPostExists)
            {
                return BadRequest(new { message = "Invalid BlogPostId. Blog post does not exist." });
            }

            var comment = new Comment
            {
                Id = Guid.NewGuid(),
                BlogPostId = dto.BlogPostId,
                AuthorName = dto.AuthorName,
                Content = dto.Content,
                CreatedAt = DateTime.UtcNow
            };

            _context.Comments.Add(comment);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetComment), new { id = comment.Id }, new CommentDTO
            {
                Id = comment.Id,
                BlogPostId = comment.BlogPostId,
                AuthorName = comment.AuthorName,
                Content = comment.Content,
                CreatedAt = comment.CreatedAt
            });
        }

        // PUT: api/Comment/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateComment(Guid id, [FromBody] UpdateCommentDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var comment = await _context.Comments.FindAsync(id);
            if (comment == null)
            {
                return NotFound(new { message = "Comment not found." });
            }

            comment.AuthorName = dto.AuthorName;
            comment.Content = dto.Content;

            await _context.SaveChangesAsync();

            return Ok(new CommentDTO
            {
                Id = comment.Id,
                BlogPostId = comment.BlogPostId,
                AuthorName = comment.AuthorName,
                Content = comment.Content,
                CreatedAt = comment.CreatedAt
            });
        }

        // DELETE: api/Comment/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComment(Guid id)
        {
            var comment = await _context.Comments.FindAsync(id);
            if (comment == null)
            {
                return NotFound(new { message = "Comment not found." });
            }

            _context.Comments.Remove(comment);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
