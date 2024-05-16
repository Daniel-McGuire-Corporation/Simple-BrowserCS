@echo off
echo Setting Title
title Simple Browser Compiler
echo Setting Config
:: Sets NPM to verbose
set NPM_CONFIG_LOGLEVEL=verbose
:: Sets path variable
set Path=%~dp0;C:\Program Files (x86)\NSIS\;%PATH%
echo Changing Directory
cd %~dp0
echo Launching
cls
echo C# Non-Universal Compiling Script for Simple Browser
:: Argument Handler
if "%~1"=="" (
    :: If no arguments are provided, just execute the PowerShell script as Release
    powershell.exe -ExecutionPolicy Bypass -File BuildAll.ps1 release
) else (
    :: If arguments are provided, pass them to the PowerShell script
    powershell.exe -ExecutionPolicy Bypass -File BuildAll.ps1 %*
)
