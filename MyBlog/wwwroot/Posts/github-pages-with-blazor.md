# Deploying Blazor to GitHub Pages

Publishing a Blazor WebAssembly site to GitHub Pages is mostly a static file deployment process.

## Important Points

- Publish in `Release`
- Set the correct base path for the repository
- Copy `index.html` to `404.html` for SPA route fallback

## Suggested Workflow

Use a script so deployment steps are consistent across updates. Keeping this automated avoids common mistakes and keeps your publishing repeatable.
