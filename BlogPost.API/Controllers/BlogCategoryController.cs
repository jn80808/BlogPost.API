using Microsoft.AspNetCore.Mvc;
using BlogPost.API.DTOs;
using BlogPost.API.Model.Domain;
using Microsoft.EntityFrameworkCore;
using BlogPostSystem;
using BlogPost.API.Model.DTO;

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
        public async Task<ActionResult<CreateCategoryReturnDto>> CreateCategory([FromBody] CreateBlogCategoryDTO createBlogCategoryDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Check if Name or Description already exists in the database
            bool categoryExists = await _context.Categories.AnyAsync(c =>
                c.Name == createBlogCategoryDTO.Name ||
                c.Description == createBlogCategoryDTO.Description);

            if (categoryExists)
            {
                return BadRequest("A category with the same Name or Description already exists.");
            }

            // Map DTO to Domain Model
            var category = new BlogCategory
            {
                Name = createBlogCategoryDTO.Name,
                UrlHandle = createBlogCategoryDTO.UrlHandle,
                Description = createBlogCategoryDTO.Description
            };

            _context.Categories.Add(category);
            await _context.SaveChangesAsync();

            // Map Domain Model to Response DTO
            var response = new CreateCategoryReturnDto
            {
                Id = category.Id,
                Name = category.Name,
                UrlHandle = category.UrlHandle,
                Description = category.Description
            };

            return Ok(response);
        }

        // PUT: api/BlogCategory/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(Guid id, [FromBody] UpdateBlogCategoryDTO updateBlogCategoryDTO)
        {
            if (id != updateBlogCategoryDTO.Id)
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

            category.Name = updateBlogCategoryDTO.Name;
            category.UrlHandle = updateBlogCategoryDTO.UrlHandle;
            category.Description = updateBlogCategoryDTO.Description;

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
