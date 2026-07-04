$files = Get-ChildItem -Path "c:\Users\CASPER\source\repos\AstroComment\AstroComment" -Recurse -Filter "*.cshtml" | Where-Object { $_.FullName -notmatch "\\obj\\" -and $_.FullName -notmatch "\\bin\\" }

foreach ($file in $files) {
    $content = [System.IO.File]::ReadAllText($file.FullName, [System.Text.Encoding]::UTF8)
    
    # Remove HTML comments (<!-- ... -->)
    $newContent = $content -replace '(?s)<!--.*?-->', ''
    
    # Write back without BOM or with BOM depending on how it was read. 
    # Usually UTF8 string writing works.
    [System.IO.File]::WriteAllText($file.FullName, $newContent, [System.Text.Encoding]::UTF8)
}
