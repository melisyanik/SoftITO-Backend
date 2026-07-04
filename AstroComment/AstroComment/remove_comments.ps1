$files = Get-ChildItem -Path "c:\Users\CASPER\source\repos\AstroComment\AstroComment" -Recurse -Filter "*.cs" | Where-Object { $_.FullName -notmatch "\\obj\\" -and $_.FullName -notmatch "\\bin\\" }

foreach ($file in $files) {
    $lines = [System.IO.File]::ReadAllLines($file.FullName, [System.Text.Encoding]::GetEncoding("iso-8859-9"))
    $newContent = @()
    foreach ($line in $lines) {
        if ($line -match "^\s*// Add services to the container" -or $line -match "^\s*// Configure the HTTP request pipeline") {
            $newContent += $line
            continue
        }
        
        if ($line -match "^\s*//") {
            continue
        }
        
        if ($line -match "(.*?)//.*") {
            $newLine = $matches[1].TrimEnd()
            if (-not [string]::IsNullOrWhiteSpace($newLine)) {
                $newContent += $newLine
            }
        } else {
            $newContent += $line
        }
    }
    [System.IO.File]::WriteAllLines($file.FullName, $newContent, [System.Text.Encoding]::GetEncoding("iso-8859-9"))
}
