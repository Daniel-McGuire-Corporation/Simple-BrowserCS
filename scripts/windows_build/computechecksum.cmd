@echo off
echo Writing checksum to checksum.txt
echo.
cd %~dp0
powershell.exe "Get-FileHash *Setup.exe -Algorithm SHA256" > SHA256.txt
echo Checksum saved.
pause
exit
