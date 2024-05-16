@echo off
cd %~dp0
echo Compiling Start Page
powershell.exe -ExecutionPolicy Bypass -File pb.ps1
echo Compiling Installer
set path=C:\Program Files (x86)\NSIS;%path%
cd %~dp0
makensis.exe main.nsi
