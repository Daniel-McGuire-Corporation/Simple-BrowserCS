@echo off
echo Setting Title
title Simple Browser Compiler
echo Setting Config
set NPM_CONFIG_LOGLEVEL=verbose
set Path=%~dp0;C:\Program Files (x86)\NSIS\;%PATH%
echo Changing Directory
cd %~dp0
echo Launching
cls
echo C# Non-Universal Compiling Script for Simple Browser
powershell.exe -ExecutionPolicy Bypass -File BuildAll.ps1
