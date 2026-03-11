namespace MyBlog.Models;

public class PostSummary
{
    public string Slug { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string Summary { get; set; } = string.Empty;
    public string ThumbnailUrl { get; set; } = string.Empty;
    public DateTime PublishedOn { get; set; }
    public string[] Tags { get; set; } = [];
    public string[] Keywords { get; set; } = [];
    public int ReadingTimeMinutes { get; set; }
}
