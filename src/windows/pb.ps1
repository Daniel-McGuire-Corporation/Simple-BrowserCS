cd ..\..\vendor\SBmue
npm install --global yarn
yarn 
yarn run build
mkdir ..\..\src\windows\bin\Release\net8.0-windows\Resources\newtab
write-host "Ignore Error" -ForegroundColor Green
robocopy "build" ..\..\src\windows\bin\Release\net8.0-windows\Resources\newtab /E
