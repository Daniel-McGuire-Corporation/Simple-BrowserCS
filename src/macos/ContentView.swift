import SwiftUI
import WebKit

struct ContentView: View {
    @State private var urlString: String = "https://www.google.com"
    private var webView: WKWebView = {
        let configuration = WKWebViewConfiguration()
        let webView = WKWebView(frame: .zero, configuration: configuration)
        webView.customUserAgent = "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_15_7) AppleWebKit/605.1.15 (KHTML, like Gecko) Version/14.0 Safari/605.1.15"
        return webView
    }()

    var body: some View {
        VStack {
            HStack {
                TextField("Enter URL", text: $urlString, onCommit: loadURL)
                    .textFieldStyle(RoundedBorderTextFieldStyle())
                    .padding()
                Button(action: loadURL) {
                    Text("Go")
                }
                .padding(.trailing)
            }

            WebViewWrapper(webView: webView)
        }
        .frame(minWidth: 800, minHeight: 600)
    }

    private func loadURL() {
        if let url = URL(string: urlString) {
            webView.load(URLRequest(url: url))
        }
    }
}

struct WebViewWrapper: NSViewRepresentable {
    let webView: WKWebView

    func makeNSView(context: Context) -> WKWebView {
        return webView
    }

    func updateNSView(_ nsView: WKWebView, context: Context) {}
}

#Preview {
    ContentView()
}
