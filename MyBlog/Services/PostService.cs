using Markdig;
using MyBlog.Models;
using System.Net.Http.Json;

namespace MyBlog.Services;

public class PostService(HttpClient httpClient)
{
    private readonly MarkdownPipeline _markdownPipeline = new MarkdownPipelineBuilder()
        .UseAdvancedExtensions()
        .Build();

    private IReadOnlyList<PostSummary>? _cachedSummaries;

    public async Task<IReadOnlyList<PostSummary>> GetPostSummariesAsync()
    {
        if (_cachedSummaries is not null)
        {
            return _cachedSummaries;
        }

        var manifest = await httpClient.GetFromJsonAsync<List<PostManifestItem>>($"Posts/posts.json?v={DateTime.UtcNow.Ticks}") ?? [];

        _cachedSummaries = manifest
            .OrderByDescending(post => post.PublishedOn)
            .Select(post => new PostSummary
            {
                Slug = post.Slug,
                Title = post.Title,
                Summary = post.Summary,
                ThumbnailUrl = post.ThumbnailUrl,
                PublishedOn = post.PublishedOn,
                Tags = post.Tags ?? [],
                Keywords = post.Keywords ?? [],
                ReadingTimeMinutes = post.ReadingTimeMinutes
            })
            .ToList();

        return _cachedSummaries;
    }

    public async Task<BlogPost?> GetPostBySlugAsync(string slug)
    {
        var posts = await GetPostSummariesAsync();
        var summary = posts.FirstOrDefault(post => post.Slug.Equals(slug, StringComparison.OrdinalIgnoreCase));
        if (summary is null)
        {
            return null;
        }

        var markdown = await httpClient.GetStringAsync($"Posts/{summary.Slug}.md?v={DateTime.UtcNow.Ticks}");
        var html = Markdown.ToHtml(markdown, _markdownPipeline);

        return new BlogPost
        {
            Slug = summary.Slug,
            Title = summary.Title,
            Summary = summary.Summary,
            ThumbnailUrl = summary.ThumbnailUrl,
            PublishedOn = summary.PublishedOn,
            Tags = summary.Tags,
            Keywords = summary.Keywords,
            ReadingTimeMinutes = summary.ReadingTimeMinutes,
            ContentHtml = html
        };
    }

    private sealed class PostManifestItem
    {
        public string Slug { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Summary { get; set; } = string.Empty;
        public string ThumbnailUrl { get; set; } = string.Empty;
        public DateTime PublishedOn { get; set; }
        public string[]? Tags { get; set; }
        public string[]? Keywords { get; set; }
        public int ReadingTimeMinutes { get; set; }
    }
}
