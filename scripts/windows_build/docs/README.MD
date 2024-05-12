## *Requires Windows 10 to run and compile!*
# Method 1 | Build Script

This method uses the .NET SDK to build and install the Simple Browser application.

## Steps

1. **Clone the Repository:**
   Use Git to clone this repository to your local machine.
   ```bash
   git clone https://github.com/Daniel-McGuire-Corporation/Simple-Browser.git --recurse-submodules
   ```
2. **Install the Prerequisites:**
   - **.NET:** This project requires the .NET 8.0 SDK. You can download it from [microsoft.com](https://dotnet.microsoft.com/en-us/download/dotnet/8.0).
   - **Node.js:** This project requires Node.js. You can download it from [nodejs.org](https://nodejs.org/dist/v20.13.1/node-v20.13.1-x64.msi).
   - **WebView:** This project requires WebView2. You can download it from [microsoft.com](https://go.microsoft.com/fwlink/p/?LinkId=2124703).
   - **NSIS:** This project requires WebView2. You can download it from [nsis.sourceforge.io](https://nsis.sourceforge.io/Download).
3. **Run BuildAll.cmd:**
   Run the BuildAll.cmd file in the script location of the repository. This will use the ps1 to compile the browser, compile the newtab, and compile the installer.
4. **Done**
   The installer is in the script directory

# Method 2 | Visual Studio

This method uses Visual Studio to build and run the Simple Browser application **(The new tab and installer will not be built.)**

## Prerequisites

Make sure you have the following installed:

- **Visual Studio:** This project was developed using Visual Studio 2022. You can download it from [microsoft.com](https://visualstudio.microsoft.com/downloads/).
- **.NET:** This project requires the .NET 8.0 SDK. You can download it from [microsoft.com](https://dotnet.microsoft.com/en-us/download/dotnet/8.0).

## Steps

1. **Clone the Repository:**
   Use Git to clone this repository to your local machine.
   ```bash
   git clone https://github.com/Daniel-McGuire-Corporation/Simple-Browser.git --recurse-submodules
   ```

2. **Open the Project:**
   Launch Visual Studio and open the project file. 
    - Click on File -> Open -> Project/Solution.
    - Navigate to the location where you cloned the repository, go to src/windows/ and open the .sln file.
    
3. **Build the Project:**
   Build the project using Visual Studio.
    - Make sure Visual Studio is set to Release, not Debug. (Depending on what you want)
    - Select Build from the top menu and choose Build Solution or press Ctrl + Shift + B.

4. **Run the Application:**
   Run the application using Visual Studio.
    - Click on the Start button (usually a green arrow) in the Visual Studio toolbar.

# Notes

- Ensure that all necessary dependencies are available and correctly referenced within the project.
- If there are any build errors, resolve them by checking for missing dependencies or incorrect configurations within Visual Studio.
- If you encounter any issues during the build process, feel free to create an issue in this repository for assistance.
