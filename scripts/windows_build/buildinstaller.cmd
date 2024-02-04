@echo off
echo Make Sure NSIS is installed.
echo (This is not an error, I just don't know batch very well)
pause
echo DMC Compiler (NSIS)
cd /d "C:\Program Files (x86)\NSIS\"
makensis.exe %~dp0\main.nsi
pause