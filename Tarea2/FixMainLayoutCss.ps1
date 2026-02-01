$componentsFile = "Tarea2\Components\Layout\MainLayout.razor.css"
$sharedTypo   = "Tarea2\Shared\MainLayout.azor.css"
$sharedTarget = "Tarea2\Shared\MainLayout.razor.css"

# Rename typo'd file if present
if (Test-Path $sharedTypo) {
    Move-Item -Path $sharedTypo -Destination $sharedTarget -Force
    Write-Output "Renamed $sharedTypo -> $sharedTarget"
}

# Remove the duplicate scoped CSS that doesn't have a matching .razor in the same folder
if (Test-Path $componentsFile) {
    Remove-Item -Path $componentsFile -Force
    Write-Output "Removed duplicate scoped file $componentsFile"
}