using Microsoft.EntityFrameworkCore;
using BlogPost.API.Model.Domain;
using BlogPost.API.Data;

namespace BlogPostSystem  
{
    public class BlogPostDbContext : DbContext
    {
        public BlogPostDbContext(DbContextOptions<BlogPostDbContext> options) : base(options) { }

        public DbSet<BlogPostT> BlogPosts { get; set; }
        public DbSet<BlogCategory> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Apply Seeding
            SeedData.Seed(modelBuilder);

            modelBuilder.Entity<BlogPostT>()
                .HasOne(bp => bp.Category)
                .WithMany(c => c.BlogPosts)
                .HasForeignKey(bp => bp.CategoryId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);



            modelBuilder.Entity<Comment>()
                .HasOne(c => c.BlogPost)
                .WithMany(bp => bp.Comments)
                .HasForeignKey(c => c.BlogPostId)
                .OnDelete(DeleteBehavior.Restrict);
        }


    }
}
