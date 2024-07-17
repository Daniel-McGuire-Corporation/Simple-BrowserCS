@echo off
title Renaming Release
pwsh ./rn.ps1
cls
title DMC Setup Checksum Generator (PWSH)
echo Writing checksum to checksum.txt
echo.
cd %~dp0
powershell.exe "Get-FileHash *Setup.exe -Algorithm SHA256" > SHA256.txt
echo Checksum saved...
pause
exit
