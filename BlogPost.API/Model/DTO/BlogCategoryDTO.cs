public class BlogCategoryDTO
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string UrlHandle { get; set; } = string.Empty;
    public string? Description { get; set; }
}

public class CreateBlogCategoryDTO
{
    public string Name { get; set; } = string.Empty;
    public string UrlHandle { get; set; } = string.Empty;
    public string? Description { get; set; }
}

public class UpdateBlogCategoryDTO
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string UrlHandle { get; set; } = string.Empty;
    public string? Description { get; set; }
}
