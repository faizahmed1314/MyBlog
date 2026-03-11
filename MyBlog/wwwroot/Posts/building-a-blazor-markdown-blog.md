# Building a Blazor Markdown Blog

Blazor WebAssembly is a strong option for a personal blog when you want static hosting and a .NET-first stack.

## Why Markdown

Markdown keeps authoring simple and portable:

- Easy to write in any editor
- Version control friendly
- Works well with static deployment

## Core Idea

Use a `posts.json` manifest for metadata and store each post as a `.md` file under `wwwroot/Posts`.

At runtime:

1. Load manifest with `HttpClient`
2. Resolve slug to markdown file
3. Render markdown to HTML with Markdig

This approach is straightforward, fast, and works well on GitHub Pages.
