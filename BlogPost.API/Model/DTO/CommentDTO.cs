public class CommentDTO
{
    public Guid Id { get; set; }
    public Guid BlogPostId { get; set; }
    public string AuthorName { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
}

public class CreateCommentDTO
{
    public Guid BlogPostId { get; set; }
    public string AuthorName { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
}

public class UpdateCommentDTO
{
    public string AuthorName { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
}
