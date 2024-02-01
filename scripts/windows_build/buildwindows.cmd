@echo off
cd ..\..\src\windows\
dotnet build -c Release -o bin\Release\net8.0-windows
pause