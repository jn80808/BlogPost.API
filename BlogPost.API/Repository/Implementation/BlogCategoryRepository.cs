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

        public async Task<IEnumerable<BlogCategory>> GetAllAsync(
            string? query = null, 
            string? sortBy = null, 
            string? sortDirection = null,
            int? pageNumber = 1,
            int? pageSize = 100
            ) 
        {
            //Querry 
            var categories = dbcontext.Categories.AsQueryable();

            //Filtering 
            if (string.IsNullOrWhiteSpace(query) == false)
            {
                categories = categories.Where(x => x.Name.Contains(query));
            }

            //Sorting 
            if (string.IsNullOrWhiteSpace(sortBy) == false) 
            {      
                if(string.Equals(sortBy,"Name",StringComparison.OrdinalIgnoreCase))
                {
                    var isAsc = string.Equals(sortDirection,"asc", StringComparison.OrdinalIgnoreCase)? true: false;

                    categories = isAsc ? categories.OrderBy(x => x.Name) : categories.OrderByDescending(x => x.Name);
                }
            }

            if (string.IsNullOrWhiteSpace(sortBy) == false)
            {
                if (string.Equals(sortBy, "UrlHandle", StringComparison.OrdinalIgnoreCase))
                {
                    var isAsc = string.Equals(sortDirection, "asc", StringComparison.OrdinalIgnoreCase) ? true : false;

                    categories = isAsc ? categories.OrderBy(x => x.UrlHandle) : categories.OrderByDescending(x => x.UrlHandle);
                }
            }

            // Pagination 
            // Pagenumber 1 pagesize 5 -skip 0,  take 5 results 
            // Pagenumber 2 pagesize 5 -skip 5,  take 5 results [6,7,8,9,10]
            // Pagenumber 3 pagesize 5 -skip 10, take 5 results 

            var skipResults = (pageNumber - 1) * pageSize;
            categories = categories.Skip(skipResults ?? 0).Take(pageSize ?? 100);



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
