using Microsoft.AspNetCore.Mvc;
using BlogPost.API.DTOs;
using BlogPost.API.Model.Domain;
using Microsoft.EntityFrameworkCore;
using BlogPostSystem;

namespace BlogPost.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogCategoryController : ControllerBase
    {
        private readonly BlogPostDbContext _context;

        public BlogCategoryController(BlogPostDbContext context)
        {
            _context = context;
        }

        // GET: api/BlogCategory
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BlogCategoryDTO>>> GetCategories()
        {
            var categories = await _context.Categories
                .Select(c => new BlogCategoryDTO
                {
                    Id = c.Id,
                    Name = c.Name,
                    UrlHandle = c.UrlHandle,
                    Description = c.Description
                })
                .ToListAsync();

            return Ok(categories);
        }

        // GET: api/BlogCategory/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<BlogCategoryDTO>> GetCategory(Guid id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                return NotFound(new { message = "Category not found." });
            }

            return Ok(new BlogCategoryDTO
            {
                Id = category.Id,
                Name = category.Name,
                UrlHandle = category.UrlHandle,
                Description = category.Description
            });
        }

        // POST: api/BlogCategory
        [HttpPost]
        public async Task<ActionResult<BlogCategoryDTO>> CreateCategory([FromBody] BlogCategoryDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var category = new BlogCategory
            {
                Id = Guid.NewGuid(),
                Name = dto.Name,
                UrlHandle = dto.UrlHandle,
                Description = dto.Description
            };

            _context.Categories.Add(category);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCategory), new { id = category.Id }, dto);
        }

        // PUT: api/BlogCategory/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(Guid id, [FromBody] BlogCategoryDTO dto)
        {
            if (id != dto.Id)
            {
                return BadRequest(new { message = "ID mismatch." });
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                return NotFound(new { message = "Category not found." });
            }

            category.Name = dto.Name;
            category.UrlHandle = dto.UrlHandle;
            category.Description = dto.Description;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/BlogCategory/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(Guid id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                return NotFound(new { message = "Category not found." });
            }

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
