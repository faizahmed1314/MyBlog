# MyBlog Post Authoring Guide

This guide explains how to add blog posts to the Blazor WebAssembly blog.

## 1) Add a Markdown file

Create a new file in `wwwroot/Posts/`:

- Example: `wwwroot/Posts/my-new-post.md`
- File name should match the post `slug` you add in `posts.json`.

## 2) Add/update a thumbnail image

Place an image in `wwwroot/images/posts/`:

- Example: `wwwroot/images/posts/my-new-post.svg`
- Recommended aspect ratio: `1200x630` (good for cards and social previews)

## 3) Register the post in manifest

Edit `wwwroot/Posts/posts.json` and add an object like this:

```json
{
  "slug": "my-new-post",
  "title": "My New Post",
  "summary": "Short summary shown on the home page card.",
  "thumbnailUrl": "images/posts/my-new-post.svg",
  "publishedOn": "2026-03-11T00:00:00Z",
  "tags": ["Blazor", ".NET"],
  "keywords": ["blazor", "webassembly", "markdown"],
  "readingTimeMinutes": 5
}
```

### Field notes

- `slug`: must match markdown filename (without `.md`)
- `thumbnailUrl`: relative to `wwwroot` (do not include `wwwroot/`)
- `tags`: used for display
- `keywords`: used by home page client-side search

## 4) Verify locally

Run:

```powershell
dotnet run --project MyBlog.csproj
```

Then check:

- Home page card appears
- Search finds the post by title/summary/tag/keyword
- Post page opens at `/post/{slug}`

## 5) Publish for GitHub Pages

Use the publish script:

```powershell
./scripts/publish-gh-pages.ps1 -RepositoryName "<your-repo-name>"
```

This script:

- Publishes in Release mode
- Sets base path to `/<repo-name>`
- Creates `404.html` fallback for SPA routing

## Troubleshooting

- Post not visible: verify entry exists in `posts.json` and JSON is valid.
- 404 on post page: ensure `slug` equals markdown filename.
- Thumbnail missing: verify `thumbnailUrl` path and image file name/case.
- Search not matching: ensure expected terms exist in `title`, `summary`, `tags`, or `keywords`.
