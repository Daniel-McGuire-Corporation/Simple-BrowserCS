@echo off
title Simple Browser Updater Utility v1
cls
echo =========================================
echo = Simple Browser Updater Utility v1.2.0 =
echo =========================================
echo Copyright (C) 2024 Daniel McGuire Corporation
echo.
echo This Program uses the Windows Package Manager to Update to the
echo latest version of Simple Browser.
echo.
echo Please Close ALL Windows of Simple Browser.
echo.
echo Press any key to check for and install updates...
pause > nul
cls
echo =========================================
echo = Simple Browser Updater Utility v1.2.0 =
echo =========================================
echo Copyright (C) 2024 Daniel McGuire Corporation
echo. 
echo This will uninstall the current version then install 
echo the latest version (Browsing Data is kept)
echo.
echo If the updater says 'No available upgrade found',
echo then you can close this window and return to the browser.
echo.
winget update --uninstall-previous DanielMcGuireCorporation.SimpleBrowser --accept-package-agreements
echo. 
echo =======================================
echo Done! Press any key to exit the updater
pause > nul
exit