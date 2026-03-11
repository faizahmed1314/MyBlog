# Requirement Document: Blazor WebAssembly Blog Site

## 1. Project Overview

**Project Name:** MyBlog  
**Technology:** Blazor WebAssembly (.NET 7/8)  
**Hosting:** GitHub Pages (static site)  
**Purpose:** Build a personal/professional blog platform using .NET technologies, deployable for free on GitHub, allowing users to read posts in an organized, visually appealing format.

## 2. Goals & Objectives

- Build a responsive, static blog site hosted on GitHub Pages.
- Use Blazor WebAssembly to build the site entirely in C#/.NET.
- Post content using Markdown files for simplicity and maintainability.
- Professional UI/UX for desktop and mobile devices.
- Simple update process for adding new blog posts via Markdown files.

## 3. Functional Requirements

| ID    | Requirement     | Description                                                            |
| ----- | --------------- | ---------------------------------------------------------------------- |
| FR-1  | Home Page       | Display blog posts with title, short description, date, and thumbnail. |
| FR-2  | Post Page       | Display full content of a post, rendered from Markdown.                |
| FR-3  | Navigation      | Top navigation bar: Home, About, Contact (optional).                   |
| FR-4  | Search          | Client-side search to find posts by title/keywords.                    |
| FR-5  | Tags/Categories | Optional filtering by tags/categories.                                 |
| FR-6  | Responsiveness  | Mobile-friendly and responsive design.                                 |
| FR-7  | Deployment      | Deployable to GitHub Pages as static files.                            |
| FR-8  | SEO & Metadata  | Include SEO meta tags.                                                 |
| FR-9  | Styling         | Use Bootstrap or Tailwind CSS for styling.                             |
| FR-10 | Error Handling  | Friendly “Page Not Found” page for invalid URLs.                       |

## 4. Non-Functional Requirements

| Category        | Requirement                                                  |
| --------------- | ------------------------------------------------------------ |
| Performance     | Pages load under 3 seconds on standard broadband.            |
| Security        | Static site; no server-side execution required.              |
| Maintainability | Blog posts in Markdown for easy updates.                     |
| Scalability     | Supports hundreds of posts without performance issues.       |
| Cross-browser   | Works on Chrome, Edge, Firefox, Safari, and mobile browsers. |

## 5. Technical Requirements

- Frontend: Blazor WebAssembly (.NET 7/8)
- Content: Markdown files for posts
- Routing: Blazor Router
- Hosting: GitHub Pages (static files from wwwroot)
- Styling: Bootstrap or Tailwind CSS
- Optional: Client-side search via JS interop
- Tooling: Visual Studio 2022/2023, Git, GitHub

## 6. Architecture Overview

**Pages:**

- `Index.razor` – Home page (list of posts)
- `Post.razor` – Single blog post page
- `About.razor` – About page (optional)
- `Contact.razor` – Contact page (optional)

**Components:**

- `PostCard.razor` – Blog post card for Home page
- `NavMenu.razor` – Top navigation bar
- `Footer.razor` – Site footer

**Data:**

- `Posts/` folder – Markdown files for blog posts
- `PostService.cs` – Reads Markdown files and converts to HTML

**Deployment:**

- Publish Blazor WebAssembly to `wwwroot`
- Push static files to GitHub repository
- Enable GitHub Pages

## 7. Site Architecture Diagram

```
+------------------+
|    Index.razor   |
|  (Home Page)     |
+--------+---------+
         |
 +-------+-------+
 |               |
+------+-------+ +------+------+
| PostCard     | | NavMenu     |
| Component    | | Component   |
+--------------+ +-------------+
         |
 +-------+------+
 | Post.razor    |
 | (Post Page)   |
 +---------------+
         |
 +-------+------+
 | PostService  |
 | (Markdown)   |
 +---------------+
         |
 +-------+------+
 | Posts Folder  |
 | (Markdown)    |
 +---------------+
```

## 8. Timeline & Milestones

| Milestone                                | Expected Duration |
| ---------------------------------------- | ----------------- |
| Project Setup & Blazor Template Creation | 1 day             |
| Home & Post Pages Development            | 3–4 days          |
| Markdown Integration                     | 2 days            |
| Styling & Responsiveness                 | 2 days            |
| Testing & Bug Fixing                     | 2 days            |
| Deployment to GitHub Pages               | 1 day             |

## 9. Deliverables

- Fully functional Blazor WebAssembly blog site
- Static files ready for GitHub Pages
- Documented workflow for adding new posts via Markdown
- Optional: SEO & responsive design report

### Authoring Workflow Reference

- See `POST_AUTHORING.md` for the complete post publishing workflow, including: - Markdown post creation - Thumbnail image setup - `posts.json` manifest fields (`slug`, `thumbnailUrl`, `keywords`, etc.) - Local verification and GitHub Pages publish command

## 10. UI/UX Design Guidelines

- **Theme Alignment:** Follow the official .NET design language for colors, typography, buttons, links, and components. Reference: https://dotnet.microsoft.com/
- **Responsiveness:** Ensure the design works seamlessly on desktop, tablet, and mobile devices.
- **Intuitive Navigation:** Clear and accessible navigation with a top menu, breadcrumbs if necessary, and consistent links.
- **Post Presentation:** Blog posts should use card-style previews with title, date, short description, and thumbnail.
- **Readability & Accessibility:** Use sufficient contrast, clear fonts, and scalable layouts.
- **Consistency:** Maintain consistent spacing, color usage, and component styling across all pages.
- **Modern Design Patterns:** Use minimalistic layouts, hover effects, and subtle animations where appropriate to enhance engagement.
- **User-Friendly:** Focus on ease of reading, scanning, and navigating content with minimal cognitive load.
