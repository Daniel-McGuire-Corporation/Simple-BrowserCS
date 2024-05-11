@echo off
cd %~dp0
set App=SimpleBrowser
title %App% Compiler 
echo DMC C# Universal Compiling Script for %App%
echo.
echo Compiling %App%
echo.
cd ..\..\src\windows\
dotnet build Simple-Browser.csproj --nologo -c Release -o bin\Release\net8.0-windows
echo.
echo Application Compiled!
echo.
echo Compiling %App% Installer
echo.
cd /d "C:\Program Files (x86)\NSIS\"
makensis.exe %~dp0\main.nsi
echo.
echo Installer Compiled!
pause
exit