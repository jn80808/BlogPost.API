namespace BlogPost.API.DTOs
{
    public class CommentDTO
    {
        public Guid Id { get; set; }
        public Guid BlogPostId { get; set; }
        public string AuthorName { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
