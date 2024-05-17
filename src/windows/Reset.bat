@echo off
title Checking for Permission
:: Check if the script is running with admin privileges
net session >nul 2>&1
if %errorLevel% == 0 (
	title Simple Browser
    goto Script
) else (
    echo Admin privileges not detected. Requesting elevation...
    :: Prompt for UAC elevation
    powershell -Command "Start-Process '%~0' -Verb RunAs"
    exit /b
)
::END Check if the script is running with admin privileges
:Script
echo Are you sure you want to reset Simple Browser? (Y/N)
echo This will reset homepage customization and site data.
choice /c yn /m "Enter your choice:"

if errorlevel 2 (
    cls
    echo Canceled.
    exit /b
) else (
    goto Script2
)
:Script2
cls
cd /d %UserProfile%\AppData\Local\SimpleBrowser
rd /s /q EBWebView
echo Removed data
echo.
echo Restarting SimpleBrowser
taskkill /im Simple-Browser.exe
cd %~dp0
start Simple-Browser.exe
exit
