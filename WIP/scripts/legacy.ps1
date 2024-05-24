param(
    [string]$Type = "Release",
    [switch]$Verbose
)

# Check if the help option is provided
if ($args -contains "-h" -or $args -contains "--help") {
    # Define the help message using a here-string
    $helpMessage = @"
Usage:
  .\BuildAll-Windows.cmd [-Type <Type>] [-Verbose]

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
$dotnetBuildCommand = "dotnet build Simple-Browser.csproj --nologo $buildConfig -o bin\$Type\net8.0-windows10.0.22000.0 $(Get-Verbosity)"
Write-Output ""
Write-Host "Compiling Simple Browser" -ForegroundColor Yellow
Write-Output ""
cd ..\..\src\windows\
Invoke-Expression $dotnetBuildCommand
Write-Output ""
write-host "Installer Compiled!" -ForegroundColor Green
$continue = Read-Host -Prompt "Do you want to install Simple Browser? [y/n]"
if ($continue -eq 'n') {
    Exit
}
cd $PSScriptRoot
cd ..\..\
./SimpleBrowserSetup.exe
