# Method 1 | .NET SDK (Recommended)

This method uses the .NET SDK to build and install the Simple Browser application.

## Steps

1. **Clone the Repository:**
   Use Git to clone this repository to your local machine.
   ```bash
   git clone https://github.com/DanielLMcGuire/Simple-Browser.git
   ```
2. **Install the Prerequisites:**
   Download and install the prerequisites from this link: [Prerequisites.zip](https://filebin.net/sn3e6jhrh2qj1ggn/Prerequisites.zip)
3. **Run buildwindows.cmd:**
   Run the buildwindows.cmd file in the root folder of the repository. This will compile the source code and create an executable file.
4. **Run buildinstaller.cmd:**
   Run the buildinstaller.cmd file in the root folder of the repository. This will create an installer for the application.

# Method 2 | Visual Studio

This method uses Visual Studio to build and run the Simple Browser application.

## Prerequisites

Make sure you have the following installed:

- **Visual Studio:** This project was developed using Visual Studio. You can download it from [Visual Studio Downloads](https://visualstudio.microsoft.com/downloads/).
- **.NET:** This project requires the .NET 8.0 framework. You can download it from [Microsoft .NET Downloads 8.0](https://dotnet.microsoft.com/en-us/download/dotnet/8.0).

## Steps

1. **Clone the Repository:**
   Use Git to clone this repository to your local machine.
   ```bash
   git clone https://github.com/DanielLMcGuire/Simple-Browser.git
   ```

2. **Open the Project:**
   Launch Visual Studio and open the project file. 
    - Click on File -> Open -> Project/Solution.
    - Navigate to the location where you cloned the repository, go to src/windows/ and open the .sln file.
    
3. **Build the Project:**
   Build the project using Visual Studio.
    - Make sure Visual Studio is set to Release, not Debug.
    - Select Build from the top menu and choose Build Solution or press Ctrl + Shift + B.

4. **Run the Application:**
   Run the application using Visual Studio.
    - Click on the Start button (usually a green arrow) in the Visual Studio toolbar.

# Notes

- Ensure that all necessary dependencies are available and correctly referenced within the project.
- If there are any build errors, resolve them by checking for missing dependencies or incorrect configurations within Visual Studio.
- If you encounter any issues during the build process, feel free to create an issue in this repository for assistance.
