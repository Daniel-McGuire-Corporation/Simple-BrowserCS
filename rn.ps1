# Get the current date in DD-MM-YY format
$dateSuffix = Get-Date -Format "dd-MM-yy"

# Get all files matching *Setup.exe in the current directory
$files = Get-ChildItem -Filter "*Setup.exe"

foreach ($file in $files) {
    # Construct the new file name with the date suffix
    $newName = $file.Name -replace "Setup.exe", "Setup-$dateSuffix.exe"

    # Rename the file
    Rename-Item -Path $file.FullName -NewName $newName
}
