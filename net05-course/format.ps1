# Script format tất cả file C# trong project

Write-Host "Formatting all C# files..." -ForegroundColor Green

# Format từng file trong exercise_2/Exercises
Get-ChildItem -Path "exercise_2\Exercises\*.cs" | ForEach-Object {
    Write-Host "Formatting: $($_.Name)" -ForegroundColor Yellow
    dotnet format --include $_.FullName "exercise_2\exercise_2.csproj"
}

# Format Program.cs
Write-Host "Formatting: Program.cs" -ForegroundColor Yellow
dotnet format --include "exercise_2\Program.cs" "exercise_2\exercise_2.csproj"

Write-Host "`nDone! All files formatted." -ForegroundColor Green

