@echo off
echo DMC Compiler (Windows .NET)
cd ..\..\src\windows\
dotnet build Simple-Browser.csproj --nologo -c Release -o bin\Release\net8.0-windows
pause