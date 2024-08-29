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

:: Check if Python or Python3 is available
where python > nul 2>&1
if %errorlevel% equ 0 (
    set PYTHON_EXECUTABLE=python
) else (
    where python3 > nul 2>&1
    if %errorlevel% equ 0 (
        set PYTHON_EXECUTABLE=python3
    ) else (
        echo Python is not found in your PATH.
        echo Please install Python and make sure it's added to the PATH.
        pause
        exit /b
    )
)

:: Argument Handler
if "%~1"=="" (
    :: If no arguments are provided, execute the python script as Release
    %PYTHON_EXECUTABLE% windows.py release
) else (
    :: If arguments are provided, pass them to the python script
    %PYTHON_EXECUTABLE% windows.py %*
)
