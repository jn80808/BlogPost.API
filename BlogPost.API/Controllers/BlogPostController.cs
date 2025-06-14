﻿using Microsoft.AspNetCore.Mvc;
using BlogPost.API.DTOs;
using BlogPost.API.Model.Domain;
using BlogPost.API.Repositories;
using BlogPost.API.Repository.Interface;
using BlogPost.API.Repository.Implementation;
using Microsoft.AspNetCore.Authorization;

namespace BlogPost.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogPostController : ControllerBase
    {
        private readonly IBlogPostRepository _blogPostRepository;
        private readonly IBlogCategoryRepository _blogCategoryRepository;

        // Constructor now accepts IBlogPostRepository instead of DbContext
        public BlogPostController(IBlogPostRepository blogPostRepository,
            IBlogCategoryRepository categoryRepository)
        {
            _blogPostRepository = blogPostRepository;
            _blogCategoryRepository = categoryRepository;
        }

        // GET: api/BlogPost?query=BlogPostName&sortBy=name&sortDirection=desc
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BlogPostDTO>>> GetBlogPosts([FromQuery] string? query,
            [FromQuery] string? sortBy,
            [FromQuery] string? sortDirection
            )
        {
            var blogPosts = await _blogPostRepository.GetAllAsync(query, sortBy, sortDirection);

            //Convert Domain model to DTO 
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
                CreatedAt = bp.CreatedAt,
                Categories = bp.Categories.Select(x => new BlogCategoryDTO
                {
                    Id = x.Id,
                    Name = x.Name,
                    UrlHandle = x.UrlHandle
                }).ToList()
            });

            return Ok(response);
        }


        // GET: api/BlogPost/by-url/{urlHandle}   <- Change route to avoid ambiguity
        [HttpGet("by-url/{urlHandle}")]
        public async Task<IActionResult> GetBlogPostByUrlHandle([FromRoute] string urlHandle)
        {
            var blogPost = await _blogPostRepository.GetByUrlHandleAsync(urlHandle);

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


        // GET: api/BlogPost/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<BlogPostDTO>> GetBlogPost([FromRoute] Guid id)
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
        [Authorize(Roles = "Writer")]
        public async Task<ActionResult<BlogPostDTO>> CreateBlogPost([FromBody] CreateBlogPostDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var titleExists = await _blogPostRepository.TitleExistsAsync(dto.Title);
            if (titleExists)
            {
                return BadRequest($"A blog post with the title '{dto.Title}' already exists.");
            }


            // Convert DTO to Domain
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
                CreatedAt = DateTime.UtcNow,
                Categories = new List<BlogCategory>()
            };

            //check the existing of categories then add this category when it saving a new blog post
            foreach (var categoryGuid in dto.Categories)
            {
                var existingCategory = await _blogCategoryRepository.GetByIdAsync(categoryGuid);

                if (existingCategory != null)
                {
                    blogPost.Categories.Add(existingCategory);
                }
            }

            var createdBlogPost = await _blogPostRepository.AddAsync(blogPost);

            //Convert Domain Model back to DTO 
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
                CreatedAt = createdBlogPost.CreatedAt,
                Categories = createdBlogPost.Categories.Select(x => new BlogCategoryDTO
                {
                    Id = x.Id,
                    Name = x.Name,
                    UrlHandle = x.UrlHandle
                }).ToList()
            };

            return CreatedAtAction(nameof(GetBlogPost), new { id = response.Id }, response);
        }

        // PUT: api/BlogPost/{id}
        [HttpPut("{id}")]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> UpdateBlogPost([FromRoute] Guid id, [FromBody] UpdateBlogPostDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var updatedBlogPost = await _blogPostRepository.UpdateAsync(id, dto);

            if (updatedBlogPost == null)
            {
                return NotFound(new { message = "Blog post not found." });
            }

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
                CreatedAt = updatedBlogPost.CreatedAt,
                Categories = updatedBlogPost.Categories.Select(x => new BlogCategoryDTO
                {
                    Id = x.Id,
                    Name = x.Name,
                    UrlHandle = x.UrlHandle
                }).ToList()
            };

            return Ok(new { message = "Successfully updated", response });
        }


        // DELETE: api/BlogPost/{id}
        [HttpDelete("{id}")]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> DeleteBlogPost([FromRoute] Guid id)
        {
            // Call the repository to delete the blog post
            var result = await _blogPostRepository.DeleteAsync(id);

            // If the blog post was not found, return NotFound
            if (!result)
            {
                return NotFound(new { message = "Blog post not found. Please Check Again" });
            }

            // Return a success message after successful deletion
            return Ok(new { message = "Blog post successfully deleted." });
        }


    }
}
