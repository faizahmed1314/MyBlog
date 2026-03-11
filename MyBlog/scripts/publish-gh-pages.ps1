param(
    [Parameter(Mandatory = $true)]
    [string]$RepositoryName
)

$ErrorActionPreference = "Stop"

$projectPath = "./MyBlog.csproj"
$publishDir = "./bin/Release/net8.0/publish/wwwroot"

dotnet publish $projectPath -c Release -p:StaticWebAssetBasePath="/$RepositoryName"

if (-not (Test-Path $publishDir)) {
    throw "Publish output not found at '$publishDir'."
}

$indexPath = Join-Path $publishDir "index.html"
$notFoundPath = Join-Path $publishDir "404.html"

Copy-Item $indexPath $notFoundPath -Force

Write-Host "Publish complete. Output ready in: $publishDir"
Write-Host "Base path configured for repository: /$RepositoryName"
Write-Host "Created SPA fallback file: 404.html"
