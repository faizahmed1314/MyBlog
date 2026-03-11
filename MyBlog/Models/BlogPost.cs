namespace MyBlog.Models;

public class BlogPost : PostSummary
{
    public string ContentHtml { get; set; } = string.Empty;
}
