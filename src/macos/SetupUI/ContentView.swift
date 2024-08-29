//
//  MenuBar.swift
//  Installer
//
//  Created by Daniel McGuire on 8/27/24.
//
import SwiftUI

struct ContentView: View {
    @State private var infoText: String = "Loading..."
    @State private var titleText: String = "Title"

    var body: some View {
        VStack {
            Text(titleText)
                .font(.title)
                .padding()

            ScrollView {
                Text(infoText)
                    .frame(maxWidth: .infinity, alignment: .leading)
                    .padding()
            }

            Button(action: installPackage) {
                Text("Install")
                    .foregroundColor(.white)
                    .frame(maxWidth: .infinity)
                    .padding()
                    .background(Color.blue)
                    .cornerRadius(8)
            }
            .padding(.horizontal)
        }
        .onAppear {
            loadTitleText()
            loadInfoText()
        }
    }

    private func loadTitleText() {
        if let titlePath = Bundle.main.path(forResource: "title", ofType: "txt") {
            do {
                titleText = try String(contentsOfFile: titlePath)
            } catch {
                titleText = "Error loading title"
            }
        } else {
            titleText = "Title not found"
        }
    }

    private func loadInfoText() {
        if let descPath = Bundle.main.path(forResource: "desc", ofType: "txt") {
            do {
                infoText = try String(contentsOfFile: descPath)
            } catch {
                infoText = "Error loading desc.txt"
            }
        } else {
            infoText = "Description not found"
        }
    }

        func installPackage() {
        if let resourcePath = Bundle.main.resourcePath {
            let pkgPath = "\(resourcePath)/install.pkg"
            let process = Process()
            process.executableURL = URL(fileURLWithPath: "/usr/bin/open")
            process.arguments = [pkgPath]

            do {
                try process.run()
                // Close the window instead of quitting the app
                NSApp.windows.first?.close()
            } catch {
                print("Failed to launch installer: \(error.localizedDescription)")
            }
        }
    }
}

func installPackage() {
    if let resourcePath = Bundle.main.resourcePath {
        let pkgPath = "\(resourcePath)/install.pkg"
        let process = Process()
        process.executableURL = URL(fileURLWithPath: "/usr/bin/open")
        process.arguments = [pkgPath]
        
        do {
            try process.run()
            // Close the window instead of quitting the app
            NSApp.windows.first?.close()
        } catch {
            print("Failed to launch installer: \(error.localizedDescription)")
        }
    }
}
#Preview {
    ContentView()
}
