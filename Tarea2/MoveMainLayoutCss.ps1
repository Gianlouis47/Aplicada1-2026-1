$src = "Tarea2\Components\Layout\MainLayout.razor.css"
$destDir = "Tarea2\Shared"
$dest = Join-Path $destDir "MainLayout.razor.css"

if (-not (Test-Path $src)) {
    Write-Error "Source file not found: $src"
    exit 1
}

if (-not (Test-Path $destDir)) {
    New-Item -ItemType Directory -Path $destDir | Out-Null
}

Move-Item -Path $src -Destination $dest -Force
Write-Output "Moved $src -> $dest"