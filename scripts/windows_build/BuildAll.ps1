param(
    [string]$Type = "Release",
    [switch]$Verbose
)

# Check if the help option is provided
if ($args -contains "-h" -or $args -contains "--help") {
    # Define the help message using a here-string
    $helpMessage = @"
Usage:
  .\BuildAll.cmd [-Type <Type>] [-Verbose]

Options:
  -Type, -t <Type>      Specifies the build configuration. Accepted values are 'Release' or 'Debug'. 
  (Defaults to 'Release' if not specified)
  
  -Verbose, -v          Indicates whether to display detailed build output
  
"@
    # Output the help message
    Write-Output $helpMessage
    # Exit the script
    exit
}

# Function to determine verbosity argument
function Get-Verbosity {
    if ($Verbose) {
        return '--verbosity detailed'
    } else {
        return ''
    }
}

# Map input type argument to dotnet build configuration
switch ($Type.ToLower()) {
    "release" { $buildConfig = "-c Release" }
    "debug" { $buildConfig = "-c Debug" }
    default { $buildConfig = "-c Release" } # Default to Release if an invalid option is provided
}
cd $PSScriptRoot
# Build command
$dotnetBuildCommand = "dotnet build Simple-Browser.csproj --nologo $buildConfig -o bin\$Type\net8.0-windows $(Get-Verbosity)"
Write-Output ""
Write-Host "Compiling Simple Browser" -ForegroundColor Yellow
Write-Output ""
cd ..\..\src\windows\
Invoke-Expression $dotnetBuildCommand
Write-Output ""
write-host "Application Compiled!" -ForegroundColor Green
clear
Write-Host "C# Non-Universal Compiling Script for Simple Browser"
Write-Output ""
Write-Host Installing Dependencies -ForegroundColor Yellow
cd $PSScriptRoot
cd ..\..\vendor\SBmue
# Installs yarn globally
npm install --global yarn
# Installs Dependencies
yarn 
Write-Host "Installed Dependencies" -ForegroundColor Green
clear
Write-Host "C# Non-Universal Compiling Script for Simple Browser"
Write-Output ""
Write-Host "Compiling New Tab" -ForegroundColor Yellow
Write-Output ""
# Compiles Mue
yarn run build
Write-Host Copying to Working Directory
# Makes the "src/windows/bin/Release/net8.0-windows/Resources/newtab" Directory (if it doesnt exist)
mkdir ..\..\src\windows\bin\Release\net8.0-windows\Resources\newtab
# Copys Mue to the appropriate folder
robocopy "build" ..\..\src\windows\bin\Release\net8.0-windows\Resources\newtab /E
cd ..\..\src\windows\bin\Release\net8.0-windows\
clear
Write-Host "C# Non-Universal Compiling Script for Simple Browser"
Write-Output ""
Write-Host "Compiling Simple Browser Installer" -ForegroundColor Yellow
Write-Output ""
# Compiles the installer
makensis.exe /V4 $PSScriptRoot\main.nsi
write-host "Installer Compiled!" -ForegroundColor Green
$continue = Read-Host -Prompt "Is this a release build [y/n] (Type n if unsure)"
if ($continue -eq 'n') {
	$continue = Read-Host -Prompt "Do you want to install Simple Browser? [y/n]"
	if ($continue -eq 'n') {
		Exit
	}
    
}
clear
# Generates the file hash 
write-host Computing Checksum to SHA256.txt
Get-FileHash $PSScriptRoot\SimpleBrowserSetup.exe -Algorithm SHA256 | Out-File -FilePath $PSScriptRoot\SHA256.txt
$continue = Read-Host -Prompt "Do you want to install Simple Browser? [y/n]"
if ($continue -eq 'n') {
    Exit
}
cd $PSScriptRoot
./SimpleBrowserSetup.exe
Exit