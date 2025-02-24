using BlogPost.API.Model.Domain;
using Microsoft.EntityFrameworkCore;

namespace BlogPost.API.Data
{
    public static class SeedData
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
        // Seed Categories
        var categories = new List<BlogCategory>
        {
            new BlogCategory
            { 
                Id = Guid.NewGuid(), 
                Name = "Technology", 
                UrlHandle = "technology", 
                Description = "Latest tech trends and news" 
            },
            new BlogCategory
            { 
                Id = Guid.NewGuid(), 
                Name = "Lifestyle", 
                UrlHandle = "lifestyle", 
                Description = "Health, wellness, and daily life tips" 
            },
            new BlogCategory
            { 
                Id = Guid.NewGuid(), 
                Name = "Finance", 
                UrlHandle = "finance", 
                Description = "Money management and investment advice" 
            }
        };


            modelBuilder.Entity<BlogCategory>().HasData(categories);

            // Seed Blog Posts
            var blogPosts = new List<BlogPostT>
            {
                new BlogPostT
                {
                    Id = Guid.NewGuid(),
                    Title = "The Future of AI",
                    ShortDescription = "Exploring AI advancements",
                    Content = "AI is evolving rapidly...",
                    FeatureImageUrl = "ai.jpg",
                    AuthorName = "John Doe",
                    UrlHandle = "future-of-ai",
                    PublishedDate = DateTime.UtcNow, // Fix: Use DateTime instead of string
                    IsVisible = true, // Fix: Use bool instead of string
                    CategoryId = categories[0].Id,
                    CreatedAt = DateTime.UtcNow,
                    IsPublished = true
                },
                new BlogPostT
                {
                    Id = Guid.NewGuid(),
                    Title = "Best Productivity Hacks",
                    ShortDescription = "Increase your efficiency",
                    Content = "Here are some productivity hacks...",
                    FeatureImageUrl = "productivity.jpg",
                    AuthorName = "Jane Smith",
                    UrlHandle = "best-productivity-hacks",
                    PublishedDate = DateTime.UtcNow, // Fix
                    IsVisible = true, // Fix
                    CategoryId = categories[1].Id,
                    CreatedAt = DateTime.UtcNow,
                    IsPublished = true
                },
                new BlogPostT
                {
                    Id = Guid.NewGuid(),
                    Title = "How to Save Money",
                    ShortDescription = "Smart saving tips",
                    Content = "Managing your finances is important...",
                    FeatureImageUrl = "finance.jpg",
                    AuthorName = "Mark Brown",
                    UrlHandle = "how-to-save-money",
                    PublishedDate = DateTime.UtcNow, // Fix
                    IsVisible = true, // Fix
                    CategoryId = categories[2].Id,
                    CreatedAt = DateTime.UtcNow,
                    IsPublished = true
                }
            };


            modelBuilder.Entity<BlogPostT>().HasData(blogPosts);

            // Seed Comments
            var comments = new List<Comment>
            {
                new Comment
                {
                    Id = Guid.NewGuid(),
                    BlogPostId = blogPosts[0].Id,
                    AuthorName = "Alice",
                    Content = "Great insights on AI!",
                    CreatedAt = DateTime.UtcNow
                },
                new Comment
                {
                    Id = Guid.NewGuid(),
                    BlogPostId = blogPosts[1].Id,
                    AuthorName = "Bob",
                    Content = "These hacks really helped!",
                    CreatedAt = DateTime.UtcNow
                },
                new Comment
                {
                    Id = Guid.NewGuid(),
                    BlogPostId = blogPosts[2].Id,
                    AuthorName = "Charlie",
                    Content = "Thanks for the tips!",
                    CreatedAt = DateTime.UtcNow
                }
            };


            modelBuilder.Entity<Comment>().HasData(comments);
        }
    }
}
