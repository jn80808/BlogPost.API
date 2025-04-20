using System.ComponentModel.DataAnnotations;

namespace BlogPost.API.DTOs
{
    public class BlogPostDTO
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string ShortDescription { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public string FeatureImageUrl { get; set; } = string.Empty;
        public string AuthorName { get; set; } = string.Empty;
        public string UrlHandle { get; set; } = string.Empty;
        public DateTime? PublishedDate { get; set; }
        public bool IsVisible { get; set; }
        public bool IsPublished { get; set; }
        public Guid? CategoryId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public List<BlogCategoryDTO> Categories { get; set; } = new List<BlogCategoryDTO>();
    }

    public class CreateBlogPostDTO
    {
        [Required(ErrorMessage = "Title is required.")]
        [StringLength(200, ErrorMessage = "Title cannot exceed 200 characters.")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Short Description is required.")]
        [StringLength(500, ErrorMessage = "Short Description cannot exceed 500 characters.")]
        public string ShortDescription { get; set; } = string.Empty;

        [Required(ErrorMessage = "Content is required.")]
        public string Content { get; set; } = string.Empty;

        public string FeatureImageUrl { get; set; } = string.Empty;

        [Required(ErrorMessage = "Author Name is required.")]
        [StringLength(100, ErrorMessage = "Author Name cannot exceed 100 characters.")]
        public string AuthorName { get; set; } = string.Empty;

        [Required(ErrorMessage = "UrlHandle is required.")]
        [StringLength(100, ErrorMessage = "UrlHandle cannot exceed 100 characters.")]
        public string UrlHandle { get; set; } = string.Empty;

        public DateTime? PublishedDate { get; set; }
        public bool IsVisible { get; set; }
        public bool IsPublished { get; set; }
        public Guid? CategoryId { get; set; }

        public Guid[] Categories { get; set; }

        
    }

    public class UpdateBlogPostDTO
    {
        [Required(ErrorMessage = "Title is required.")]
        [StringLength(200, ErrorMessage = "Title cannot exceed 200 characters.")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Short Description is required.")]
        [StringLength(500, ErrorMessage = "Short Description cannot exceed 500 characters.")]
        public string ShortDescription { get; set; } = string.Empty;

        [Required(ErrorMessage = "Content is required.")]
        public string Content { get; set; } = string.Empty;

        public string FeatureImageUrl { get; set; } = string.Empty;

        [Required(ErrorMessage = "Author Name is required.")]
        [StringLength(100, ErrorMessage = "Author Name cannot exceed 100 characters.")]
        public string AuthorName { get; set; } = string.Empty;

        [Required(ErrorMessage = "UrlHandle is required.")]
        [StringLength(100, ErrorMessage = "UrlHandle cannot exceed 100 characters.")]
        public string UrlHandle { get; set; } = string.Empty;

        public DateTime? PublishedDate { get; set; }
        public bool IsVisible { get; set; }
        public bool IsPublished { get; set; }
        public Guid? CategoryId { get; set; }

        public List<Guid> Categories { get; set; } = new List<Guid>();

    }
}
