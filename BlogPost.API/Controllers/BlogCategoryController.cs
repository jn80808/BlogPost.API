﻿using Microsoft.AspNetCore.Mvc;
using BlogPost.API.DTOs;
using BlogPost.API.Model.Domain;
using BlogPost.API.Repository.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;
using BlogPost.API.Model.DTO;
using Microsoft.AspNetCore.Authorization;

namespace BlogPost.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogCategoryController : ControllerBase
    {
        private readonly IBlogCategoryRepository _blogCategoryRepository;

        public BlogCategoryController(IBlogCategoryRepository blogCategoryRepository)
        {
            _blogCategoryRepository = blogCategoryRepository;
        }

        // GET: api/BlogCategory?query=categoryName&sortBy=name&sortDirection=desc
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BlogCategoryDTO>>> GetCategories(
            [FromQuery] string? query,
            [FromQuery] string? sortBy,
            [FromQuery] string? sortDirection,
            [FromQuery] int?    pageNumber,
            [FromQuery] int?    pageSize
            )
        {
            var categories = await _blogCategoryRepository.GetAllAsync(query, sortBy, sortDirection, pageNumber, pageSize);
            if (!categories.Any())
            {
                return NotFound(new { message = "No categories found." });
            }

            // Map Domain Model to DTO 
            var categoryDtos = categories.Select(c => new BlogCategoryDTO
            {
                Id = c.Id,
                Name = c.Name,
                UrlHandle = c.UrlHandle,
                Description = c.Description
            }).ToList();

            return Ok(categoryDtos);
        }

        // GET: api/BlogCategory/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<BlogCategoryDTO>> GetCategory([FromRoute]Guid id)
        {
            var category = await _blogCategoryRepository.GetByIdAsync(id);
            if (category == null)
            {
                return NotFound(new { message = "Category not found." });
            }

            var response = new BlogCategoryDTO
            {
                Id = category.Id,
                Name = category.Name,
                UrlHandle = category.UrlHandle,
                Description = category.Description
            };

            return Ok(response);
        }

        // POST: api/BlogCategory
        [HttpPost]
        [Authorize(Roles = "Writer")]
        public async Task<ActionResult<CreateCategoryReturnDto>> CreateCategory([FromBody] CreateBlogCategoryDTO createBlogCategoryDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Check if Name or Description already exists using Repository
            bool categoryExists = await _blogCategoryRepository.ExistsAsync(createBlogCategoryDTO.Name, createBlogCategoryDTO.Description);

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

            var createdCategory = await _blogCategoryRepository.CreateAsync(category);

            // Map Domain Model to Response DTO
            var response = new CreateCategoryReturnDto
            {
                Id = createdCategory.Id,
                Name = createdCategory.Name,
                UrlHandle = createdCategory.UrlHandle,
                Description = createdCategory.Description
            };

            return CreatedAtAction(nameof(GetCategory), new { id = response.Id }, response);
        }


        // PUT: api/BlogCategory/{id}
        [HttpPut("{id:Guid}")] 
        [Authorize(Roles = "Writer")]
        public async Task<ActionResult<BlogCategoryDTO>> UpdateCategory([FromRoute] Guid id, [FromBody] UpdateBlogCategoryDTO updateBlogCategoryDTO)
        {
            if (id != updateBlogCategoryDTO.Id)
            {
                return BadRequest(new { message = "ID mismatch." });
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var category = new BlogCategory
            {
                Id = id,
                Name = updateBlogCategoryDTO.Name,
                UrlHandle = updateBlogCategoryDTO.UrlHandle,
                Description = updateBlogCategoryDTO.Description
            };

            var updatedCategory = await _blogCategoryRepository.UpdateAsync(category);
            if (updatedCategory == null)
            {
                return NotFound(new { message = "Category not found." });
            }

            var response = new BlogCategoryDTO
            {
                Id = updatedCategory.Id,
                Name = updatedCategory.Name,
                UrlHandle = updatedCategory.UrlHandle,
                Description = updatedCategory.Description
            };

            return Ok(response);
        }


        // DELETE: api/BlogCategory/{id}
        [HttpDelete("{id}")]
        [Authorize(Roles = "Writer")]
        public async Task<ActionResult> DeleteCategory([FromRoute] Guid id)
        {
            var isDeleted = await _blogCategoryRepository.DeleteAsync(id);
            if (!isDeleted)
            {
                return NotFound(new { message = "Category not found." });
            }

            return Ok(new { message = "Category deleted successfully." });
        }
    }
}
