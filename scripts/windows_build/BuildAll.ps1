cd $PSScriptRoot
Write-Output ""
Write-Host "Compiling Simple Browser" -ForegroundColor Yellow
Write-Output ""
cd ..\..\src\windows\
dotnet build Simple-Browser.csproj --nologo -c Release -o bin\Release\net8.0-windows --verbosity detailed
Write-Output ""
write-host "Application Compiled!" -ForegroundColor Green
clear
Write-Host "C# Non-Universal Compiling Script for Simple Browser"
Write-Output ""
Write-Host Installing Dependencies -ForegroundColor Yellow
cd $PSScriptRoot
cd ..\..\vendor\SBmue
npm install --global yarn
yarn 
Write-Host "Installed Dependencies" -ForegroundColor Green
clear
Write-Host "C# Non-Universal Compiling Script for Simple Browser"
Write-Output ""
Write-Host "Compiling New Tab" -ForegroundColor Yellow
Write-Output ""
yarn run build
Write-Host Copying to Working Directory
mkdir ..\..\src\windows\bin\Release\net8.0-windows\Resources\newtab
robocopy "build" ..\..\src\windows\bin\Release\net8.0-windows\Resources\newtab /E
cd ..\..\src\windows\bin\Release\net8.0-windows\
clear
Write-Host "C# Non-Universal Compiling Script for Simple Browser"
Write-Output ""
Write-Host "Compiling Simple Browser Installer" -ForegroundColor Yellow
Write-Output ""
cd "C:\Program Files (x86)\NSIS\"
./makensis.exe /V4 $PSScriptRoot\main.nsi
Get-FileHash $PSScriptRoot\SimpleBrowserSetup.exe -Algorithm SHA256 | Out-File -FilePath $PSScriptRoot\SHA256.txt
Write-Output ""
write-host "Installer Compiled!" -ForegroundColor Green
clear
Write-Host "C# Non-Universal Compiling Script for Simple Browser"
Write-Output ""
Write-Output ""
Write-Host "Everything has compiled successfully!" -ForegroundColor Green
Write-Output ""
$continue = Read-Host -Prompt "Do you want to install Simple Browser? [y/n]"
if ($continue -eq 'n') {
    Exit
}
cd $PSScriptRoot
./SimpleBrowserSetup.exe
Exit