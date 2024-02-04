@echo off
echo DMC Compiler (Checksum Gen)
powershell.exe "Get-FileHash *Setup.exe -Algorithm SHA256" > checksum.txt
cls
echo DMC Compiler (Checksum Gen)
echo.
echo Checksum saved.
pause
exit
