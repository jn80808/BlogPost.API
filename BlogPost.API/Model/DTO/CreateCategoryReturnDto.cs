namespace BlogPost.API.Model.DTO
{
    public class CreateCategoryReturnDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string UrlHandle { get; set; } = string.Empty;
        public string? Description { get; set; }
    }
}
