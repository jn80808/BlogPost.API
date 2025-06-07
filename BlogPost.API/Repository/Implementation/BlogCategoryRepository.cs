using BlogPost.API.Model.Domain;
using BlogPost.API.Repository.Interface;
using BlogPostSystem;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace BlogPost.API.Repository.Implementation
{
    public class BlogCategoryRepository : IBlogCategoryRepository
    {
        private readonly BlogPostDbContext dbcontext;

        public BlogCategoryRepository(BlogPostDbContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }

        public async Task<IEnumerable<BlogCategory>> GetAllAsync(string? query = null) 
        {
            //Querry 
            var categories = dbcontext.Categories.AsQueryable();

            //Filtering 
            if (string.IsNullOrWhiteSpace(query) == false)
            {
                categories = categories.Where(x => x.Name.Contains(query));
            }


            //Sorting 


            //Pagination 

            return await categories.ToListAsync();



            //return await dbcontext.Categories.ToListAsync();

        }

        public async Task<BlogCategory?> GetByIdAsync(Guid id) 
        {
            return await dbcontext.Categories.FindAsync(id);
        }

        public async Task<BlogCategory> CreateAsync(BlogCategory category) 
        {
            dbcontext.Categories.Add(category);
            await dbcontext.SaveChangesAsync();
            return category;
        }

        public async Task<BlogCategory?> UpdateAsync(BlogCategory category) 
        {
            var existingCategory = await dbcontext.Categories.FindAsync(category.Id);
            if (existingCategory == null) return null;

            existingCategory.Name = category.Name;
            existingCategory.UrlHandle = category.UrlHandle;
            existingCategory.Description = category.Description;

            await dbcontext.SaveChangesAsync();
            return existingCategory;
        }

        public async Task<bool> DeleteAsync(Guid id) 
        {
            var category = await dbcontext.Categories.FindAsync(id);
            if (category == null) return false;

            dbcontext.Categories.Remove(category);
            await dbcontext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ExistsAsync(string name, string description)
        {
            return await dbcontext.Categories.AnyAsync(c => c.Name == name || c.Description == description);
        }


    }
}
