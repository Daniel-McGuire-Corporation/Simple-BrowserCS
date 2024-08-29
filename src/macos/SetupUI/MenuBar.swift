//
//  MenuBar.swift
//  Installer
//
//  Created by Daniel McGuire on 8/28/24.
//

import Foundation
import SwiftUI

// Custom Menu Commands
struct MenuCommands: Commands {
    var body: some Commands {
        CommandMenu("Action") {
            Button("Install") {
                installPackage()
            }
            .keyboardShortcut("i", modifiers: [.command, .control])
        }
    }
}
