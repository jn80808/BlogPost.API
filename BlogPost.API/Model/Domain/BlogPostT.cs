using System.ComponentModel.DataAnnotations.Schema;

namespace BlogPost.API.Model.Domain
{
    [Table("BlogPostT")]
    public class BlogPostT
    {
        public Guid Id { get; set; } // Primary Key
        public string Title { get; set; } = string.Empty;
        public string ShortDescription { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public string FeatureImageUrl { get; set; } = string.Empty;
        public string AuthorName { get; set; } = string.Empty;
        public string UrlHandle { get; set; } = string.Empty;

        public DateTime? PublishedDate { get; set; } // Nullable DateTime
        public bool IsVisible { get; set; } = false; // 

        public Guid? CategoryId { get; set; } // Nullable Foreign Key
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public bool IsPublished { get; set; } = false;

        // Navigation Properties
        [ForeignKey("CategoryId")]
        public virtual BlogCategory? Category { get; set; }

        public virtual List<Comment>? Comments { get; set; }
    }
}
