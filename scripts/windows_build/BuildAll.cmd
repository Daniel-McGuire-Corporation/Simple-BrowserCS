::  _____ _                 _        ____                                  
:: / ____(_)               | |      |  _ \                                 
::| (___  _ _ __ ___  _ __ | | ___  | |_) |_ __ _____      _____  ___ _ __ 
:: \___ \| | '_ ` _ \| '_ \| |/ _ \ |  _ <| '__/ _ \ \ /\ / / __|/ _ \ '__|
:: ____) | | | | | | | |_) | |  __/ | |_) | | | (_) \ V  V /\__ \  __/ |   
::|_____/|_|_| |_| |_| .__/|_|\___| |____/|_|  \___/ \_/\_/ |___/\___|_|   
::        Graphic by|:| Andrew M          
::                  |_|     
:: This Script Builds Simple Browser from source.
@echo off                                                                                                                                         
cd %~dp0
set Company=Daniel McGuire Corporation
set App=SimpleBrowser
title %App% Compiler 
echo C# Non-Universal Compiling Script for %App%
echo (C) %Company%
echo.
echo Compiling %App%
echo.
cd ..\..\src\windows\
dotnet build Simple-Browser.csproj --nologo -c Release -o bin\Release\net8.0-windows
echo.
powershell.exe write-host "Application Compiled!" -ForegroundColor Green
echo.
echo Compiling %App% New Tab Page
echo.
cd %~dp0
cd ..\..\vendor\mue
mkdir ..\..\src\windows\bin\Release\net8.0-windows\Resources\newtab
robocopy "build" ..\..\src\windows\bin\Release\net8.0-windows\Resources\newtab /E
cd src\windows\bin\Release\net8.0-windows\
echo.
echo Compiling %App% Installer
echo.
cd /d "C:\Program Files (x86)\NSIS\"
makensis.exe %~dp0\main.nsi
echo.
powershell.exe write-host "Installer Compiled!" -ForegroundColor Green
pause
exit