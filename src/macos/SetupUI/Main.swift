//
//  Main.swift
//  Installer
//
//  Created by Daniel McGuire on 8/28/24.
//

import Foundation
import AppKit
import SwiftUI

@main
struct MyApp: App {
    @NSApplicationDelegateAdaptor(AppDelegate.self) var appDelegate

    var body: some Scene {
        WindowGroup {
            ContentView()
        }
        .commands {
            MenuCommands()
        }
    }
}
