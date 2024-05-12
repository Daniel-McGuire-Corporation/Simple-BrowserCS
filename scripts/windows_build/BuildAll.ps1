cd $PSScriptRoot
Write-Output ""
Write-Host "Compiling Simple Browser" -ForegroundColor Yellow
Write-Output ""
cd ..\..\src\windows\
dotnet build Simple-Browser.csproj --nologo -c Release -o bin\Release\net8.0-windows
Write-Output ""
write-host "Application Compiled!" -ForegroundColor Green
Write-Output ""
Write-Host Installing Dependencies
cd $PSScriptRoot
cd ..\..\vendor\SBmue
npm install --global yarn
yarn 
Write-Output ""
Write-Host "Compiling New Tab" -ForegroundColor Yellow
Write-Output ""
yarn run build
Write-Host Copying to Working Directory
mkdir ..\..\src\windows\bin\Release\net8.0-windows\Resources\newtab
robocopy "build" ..\..\src\windows\bin\Release\net8.0-windows\Resources\newtab /E
cd ..\..\src\windows\bin\Release\net8.0-windows\
Write-Output ""
Write-Host Compiling Simple Browser Installer
Write-Output ""
makensis.exe $PSScriptRoot\main.nsi
Get-FileHash $PSScriptRoot\SimpleBrowserSetup.exe -Algorithm SHA256 | Out-File -FilePath $PSScriptRoot\SHA256.txt
Write-Output ""
write-host "Installer Compiled!" -ForegroundColor Green
$continue = Read-Host -Prompt "Do you want to install Simple Browser? [y/n]"
if ($continue -eq 'n') {
    Exit
}
cd $PSScriptRoot
./SimpleBrowserSetup.exe

