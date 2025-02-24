using System.ComponentModel.DataAnnotations.Schema;

namespace BlogPost.API.Model.Domain
{
    [Table("Comment")]
    public class Comment
    {
        public Guid Id { get; set; } // Primary Key
        public Guid BlogPostId { get; set; } // Foreign Key
        public string AuthorName { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navigation Property
        [ForeignKey("BlogPostId")]
        public virtual BlogPostT? BlogPost { get; set; }
    }
}
