
# Simple Browser

## Overview

Simple Browser is a lightweight, user-friendly web browser designed for simplicity and efficiency. This repository includes the main browser application and an WIP updater application to soon ensure users always have the latest version.

## Features

### Simple Browser
- **Lightweight**: Minimalistic design for fast performance.
- **User-Friendly Interface**: Easy to navigate and use.
- **Customizable**: Options to customize the appearance and behavior.
- **Secure**: Built with security in mind to protect user data.

### Updater *WIP!!* (Requires Config and must be built from source!)
- **GitHub Integration**: Checks for the latest release from a specified GitHub repository.
- **Version Comparison**: Compares the current version with the latest version available on GitHub.
- **Download and Install**: Downloads the latest version and installs it automatically.
- **Custom Title Bar**: Customizes the appearance of the title bar.
- **Taskbar Progress Indicator**: Displays download progress on the taskbar icon.

## Requirements
- .NET Framework 8.0.0 (and 4.7.0 for updater) or later
## Updater-Only Requirements *WIP!!* 
- GitHub Personal Access Token
- `Microsoft.WindowsAPICodePack-Shell` NuGet package (Build-Source Requirement)


## Usage

### Simple Browser

1. Run the `SimpleBrowser` application.
2. Use the browser to navigate the web with a simple and efficient interface.

### Updater *WIP!!*

1. Run the `UpdaterForm` application.
2. The application will automatically check for updates when it loads.
3. If an update is available, it will download and install the latest version. The progress will be displayed on the taskbar icon and in the application window.
4. If no update is available, the main program will be launched.

## Contributing

1. Fork the repository.
2. Create a new branch (`git checkout -b feature-branch`).
3. Make your changes.
4. Commit your changes (`git commit -am 'Add new feature'`).
5. Push to the branch (`git push origin feature-branch`).
6. Create a new Pull Request.

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## Acknowledgements

- Thanks to everyone who has helped improve this project.
- Special thanks to our DMC Developer MVPs!
