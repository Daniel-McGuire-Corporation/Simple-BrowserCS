@echo off
cd %~dp0

REM Check if ConfigurationName argument is provided
IF "%~1"=="" (
    echo ConfigurationName argument is missing!
    exit /b 1
)

REM Set ConfigurationName variable
set "ConfigurationName=%~1"

IF "%ConfigurationName%"=="Release" (
    echo Compiling Start Page
    powershell.exe -ExecutionPolicy Bypass -File pb.ps1
    echo Compiling Installer
    set "path=C:\Program Files (x86)\NSIS;%path%"
    cd %~dp0
    makensis.exe main.nsi
) ELSE (
    echo PostBuild Not Executed.
)


