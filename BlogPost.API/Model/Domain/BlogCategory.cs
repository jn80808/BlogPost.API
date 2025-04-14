using System.ComponentModel.DataAnnotations.Schema;

namespace BlogPost.API.Model.Domain
{
    [Table("BlogCategory")]
    public class BlogCategory
    {
        public Guid Id { get; set; } // Primary Key
        public string Name { get; set; } = string.Empty;
        public string UrlHandle { get; set; } = string.Empty;
        public string? Description { get; set; }

        // Navigation Property
        public virtual List<BlogPostT>? BlogPosts { get; set; }

        //Category that will have collection of BlogPost 
        public ICollection<BlogPostT> BlogPost { get; set; }

    }
}
