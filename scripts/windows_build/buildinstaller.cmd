@echo off
echo Make Sure NSIS is installed.
pause
cd /d "C:\Program Files (x86)\NSIS\"
makensis.exe %~dp0\main.nsi
pause