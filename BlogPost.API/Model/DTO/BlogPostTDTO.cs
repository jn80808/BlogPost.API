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
    }
}
