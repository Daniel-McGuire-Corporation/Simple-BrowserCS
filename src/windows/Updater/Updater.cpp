// Copyright (C) Daniel McGuire Corporation
// THANKS FOR CONTRIBUTING (or Building from Source)
// This file is part of Simple Browser Updater
//
// Updater.cpp

#include <iostream>
#include <fstream>
#include <string>
#include <vector>
#include <windows.h>
#include <shobjidl.h>
#include <curl/curl.h>
#include <json/json.h> 

// Function to write data received by libcurl
static size_t WriteCallback(void* contents, size_t size, size_t nmemb, void* userp) {
    ((std::string*)userp)->append((char*)contents, size * nmemb);
    return size * nmemb;
}

// Global variable for taskbar interface
ITaskbarList3* pTaskbarList = nullptr;

// Function to display the progress bar
int ProgressCallback(void* ptr, curl_off_t totalToDownload, curl_off_t nowDownloaded, curl_off_t, curl_off_t) {
    if (totalToDownload <= 0) return 0;

    double fractionDownloaded = (double)nowDownloaded / totalToDownload;
    int barWidth = 50;
    std::cout << "\r" << "Downloading: " << nowDownloaded / (1024 * 1024) << "MB of " << totalToDownload / (1024 * 1024) << "MB [";
    int pos = static_cast<int>(barWidth * fractionDownloaded);  // Explicit cast to int
    for (int i = 0; i < barWidth; ++i) {
        if (i < pos) std::cout << "=";
        else if (i == pos) std::cout << ">";
        else std::cout << " ";
    }
    std::cout << "] " << int(fractionDownloaded * 100.0) << " %";
    std::cout.flush();

    // Update taskbar progress
    if (pTaskbarList) {
        HWND hwnd = GetConsoleWindow();
        pTaskbarList->SetProgressValue(hwnd, nowDownloaded, totalToDownload);
    }

    return 0;
}

// Function to download a file using libcurl
bool DownloadFile(const std::string& url, const std::string& output_path) {
    CURL* curl;
    FILE* fp;
    CURLcode res;
    curl = curl_easy_init();
    if (curl) {
        // Use fopen_s instead of fopen for better security
        if (fopen_s(&fp, output_path.c_str(), "wb") != 0) {
            std::cerr << "Failed to open file for writing: " << output_path << std::endl;
            curl_easy_cleanup(curl);
            return false;
        }
        curl_easy_setopt(curl, CURLOPT_URL, url.c_str());
        curl_easy_setopt(curl, CURLOPT_WRITEFUNCTION, NULL);
        curl_easy_setopt(curl, CURLOPT_WRITEDATA, fp);
        curl_easy_setopt(curl, CURLOPT_NOPROGRESS, 0L);
        curl_easy_setopt(curl, CURLOPT_XFERINFOFUNCTION, ProgressCallback);
        res = curl_easy_perform(curl);
        curl_easy_cleanup(curl);
        fclose(fp);
        std::cout << std::endl; // Move to the next line after the progress bar
        return (res == CURLE_OK);
    }
    return false;
}

// Function to compare semantic versions
bool IsNewerVersion(const std::string& current, const std::string& latest) {
    std::istringstream currentStream(current);
    std::istringstream latestStream(latest);
    int currentMajor, currentMinor, currentPatch;
    int latestMajor, latestMinor, latestPatch;
    char dot;

    currentStream >> currentMajor >> dot >> currentMinor >> dot >> currentPatch;

    // Strip leading 'v' from latest version if present
    if (latest[0] == 'v') {
        latestStream.str(latest.substr(1));
    } else {
        latestStream.str(latest);
    }
    latestStream >> latestMajor >> dot >> latestMinor >> dot >> latestPatch;

    if (latestMajor > currentMajor) return true;
    if (latestMajor == currentMajor && latestMinor > currentMinor) return true;
    if (latestMajor == currentMajor && latestMinor == currentMinor && latestPatch > currentPatch) return true;

    return false;
}

// Helper function to convert std::string to std::wstring
std::wstring StringToWString(const std::string& str) {
    int size_needed = MultiByteToWideChar(CP_UTF8, 0, &str[0], (int)str.size(), NULL, 0);
    std::wstring wstrTo(size_needed, 0);
    MultiByteToWideChar(CP_UTF8, 0, &str[0], (int)str.size(), &wstrTo[0], size_needed);
    return wstrTo;
}

int main(int argc, char* argv[]) {
    bool verbose = false;

    // Check for verbose flag in command-line arguments
    for (int i = 1; i < argc; ++i) {
        if (std::string(argv[i]) == "--verbose" || std::string(argv[i]) == "-v") {
            verbose = true;
            break;
        }
    }

    // Standard output for checking updates
    std::cout << "Checking for updates..." << std::endl;

    // Initialize COM library
    if (verbose) std::cout << "Initializing COM library..." << std::endl;
    HRESULT hr = CoInitialize(NULL);
    if (FAILED(hr)) {
        std::cerr << "Failed to initialize COM library." << std::endl;
        return 1;
    }
    if (verbose) std::cout << "COM library initialized successfully." << std::endl;

    // Create taskbar interface
    if (verbose) std::cout << "Creating taskbar interface..." << std::endl;
    hr = CoCreateInstance(CLSID_TaskbarList, NULL, CLSCTX_INPROC_SERVER, IID_PPV_ARGS(&pTaskbarList));
    if (SUCCEEDED(hr)) {
        pTaskbarList->HrInit();
        if (verbose) std::cout << "Taskbar interface created successfully." << std::endl;
    } else {
        std::cerr << "Failed to create taskbar interface." << std::endl;
        CoUninitialize();
        return 1;
    }

    // Read the current version from update.ini
    if (verbose) std::cout << "Reading current version from update.ini..." << std::endl;
    std::ifstream versionFile("update.ini");
    std::string currentVersion;
    if (versionFile.is_open()) {
        std::getline(versionFile, currentVersion);
        versionFile.close();
        if (verbose) std::cout << "Current version: " << currentVersion << std::endl;
    } else {
        std::cerr << "Failed to open update.ini." << std::endl;
        return 1;
    }

    // Step 1: Get the latest release tag from GitHub
    std::string repo = "Daniel-McGuire-Corporation/Simple-BrowserCS";  // Replace with your repository
    std::string url = "https://api.github.com/repos/" + repo + "/releases/latest";
    std::string readBuffer;

    // Initialize CURL for HTTP request
    if (verbose) std::cout << "Fetching latest release information from GitHub..." << std::endl;
    CURL* curl;
    CURLcode res;
    curl = curl_easy_init();
    if (curl) {
        // Set CURL options for the request
        curl_easy_setopt(curl, CURLOPT_URL, url.c_str());
        curl_easy_setopt(curl, CURLOPT_WRITEFUNCTION, WriteCallback);
        curl_easy_setopt(curl, CURLOPT_WRITEDATA, &readBuffer);
        curl_easy_setopt(curl, CURLOPT_USERAGENT, "libcurl-agent/1.0");

        // Disable SSL certificate verification (not recommended for production)
        curl_easy_setopt(curl, CURLOPT_SSL_VERIFYPEER, 0L);
        curl_easy_setopt(curl, CURLOPT_SSL_VERIFYHOST, 0L);

        // Set headers
        struct curl_slist *headers = NULL;
        headers = curl_slist_append(headers, "Accept: application/vnd.github.v3+json");
        curl_easy_setopt(curl, CURLOPT_HTTPHEADER, headers);

        // Perform the request
        res = curl_easy_perform(curl);

        // Check for errors
        if (res != CURLE_OK) {
            std::cerr << "CURL request failed: " << curl_easy_strerror(res) << std::endl;
        } else {
            if (verbose) std::cout << "Latest release information fetched successfully." << std::endl;
        }

        // Clean up CURL
        curl_easy_cleanup(curl);
        curl_slist_free_all(headers);
    } else {
        std::cerr << "Failed to initialize CURL." << std::endl;
    }

    // Parse the JSON response
    if (verbose) std::cout << "Parsing JSON response..." << std::endl;
    Json::CharReaderBuilder readerBuilder;
    Json::Value jsonData;
    std::string errs;
    std::istringstream s(readBuffer);
    std::string tag_name;
    std::string updater_url;

    // Check if JSON parsing was successful
    if (Json::parseFromStream(readerBuilder, s, &jsonData, &errs)) {
        // Extract the tag name
        tag_name = jsonData["tag_name"].asString();
        const Json::Value assets = jsonData["assets"];

        // Find the updater.exe in the assets
        for (const auto& asset : assets) {
            if (asset["name"].asString() == "updater.exe") {
                updater_url = asset["browser_download_url"].asString();
                break;
            }
        }
        if (verbose) std::cout << "Latest version: " << tag_name << std::endl;
    } else {
        std::cerr << "Failed to parse JSON: " << errs << std::endl;
    }

    // If updater.exe URL is not found, exit with an error
    if (updater_url.empty()) {
        std::cerr << "Updater not found in the latest release." << std::endl;
        return 1;
    }

    // Compare versions
    if (IsNewerVersion(currentVersion, tag_name)) {
        if (verbose) std::cout << "A newer version is available. Updating..." << std::endl;

        // Standard output for downloading
        std::cout << "Downloading..." << std::endl;

        // Step 2: Quit the main app
        if (verbose) std::cout << "Closing the main application..." << std::endl;
        system("taskkill /f /im SimpleBrowser.exe");

        // Step 3: Download the updater.exe
        std::string updater_path = "updater.exe";
        if (verbose) std::cout << "Downloading updater.exe from " << updater_url << "..." << std::endl;
        if (!DownloadFile(updater_url, updater_path)) {
            std::cerr << "Failed to download updater.exe." << std::endl;
            return 1;
        }
        if (verbose) std::cout << "Updater.exe downloaded successfully." << std::endl;

        // Standard output for installing
        std::cout << "Installing..." << std::endl;

        // Step 4: Run the updater.exe
        std::wstring updater_path_w = StringToWString(updater_path);
        STARTUPINFO si = { sizeof(si) };
        PROCESS_INFORMATION pi;
        if (verbose) std::cout << "Starting updater.exe..." << std::endl;
        if (!CreateProcess(updater_path_w.c_str(), NULL, NULL, NULL, FALSE, 0, NULL, NULL, &si, &pi)) {
            std::cerr << "Failed to start updater.exe." << std::endl;
            return 1;
        }

        // Close process and thread handles
        CloseHandle(pi.hProcess);
        CloseHandle(pi.hThread);
    }
    else {
        // Standard output for no update needed
        std::cout << "No update needed." << std::endl;

        // Run the main app if no update is needed
        std::wstring main_app_path = L"SimpleBrowser.exe";
        STARTUPINFO si = { sizeof(si) };
        PROCESS_INFORMATION pi;
        if (!CreateProcess(main_app_path.c_str(), NULL, NULL, NULL, FALSE, 0, NULL, NULL, &si, &pi)) {
            std::cerr << "Failed to start SimpleBrowser.exe." << std::endl;
            return 1;
        }

        // Close process and thread handles
        CloseHandle(pi.hProcess);
        CloseHandle(pi.hThread);
    }

    // Clean up taskbar interface
    if (pTaskbarList) {
        pTaskbarList->Release();
    }

    // Uninitialize COM library
    CoUninitialize();

    return 0;
}
