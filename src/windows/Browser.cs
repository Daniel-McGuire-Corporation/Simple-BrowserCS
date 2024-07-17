// Copyright (C) Daniel McGuire Corporation
// THANKS FOR CONTRIBUTING (or Building from Source)
// This file is part of Simple Browser. (Obviously)
//
// Form1.cs
using Microsoft.Web.WebView2.WinForms;
using Microsoft.Web.WebView2.Core;
using System.Diagnostics;
using System.Security.Policy;

namespace Webview2_Test
{
    public partial class Browser : Form
    {
        // Constants for file paths
        private const string DefaultHtmlFilePath = @"C:\Program Files (x86)\SimpleBrowser\Resources\newtab\index.html";
        private const string AppDataHtmlFilePath = @"C:\Program Files (x86)\SimpleBrowser\Resources\newtab\index.html";
        private readonly string UserDataFolderPath = $"C:\\Users\\{Environment.UserName}\\AppData\\Local\\SimpleBrowser";

        private WebView2 webView;
        private TextBox addressBar;

        public Browser()
        {
            InitializeComponent();
            InitializeUI(); // Initialize the user interface
            InitializeAsync(GetWebView()); // Initialize the WebView2 component asynchronously
        }

        private void InitializeUI()
        {
            this.Text = "Simple Web";

            // Create and configure the toolbar panel
            Panel toolbar = new Panel()
            {
                Dock = DockStyle.Top,
                Height = 20,
                BackColor = ColorTranslator.FromHtml("#202124"),
            };
            this.Controls.Add(toolbar);

            // Create and configure the address bar
            addressBar = new TextBox()
            {
                Dock = DockStyle.Fill,
                Height = 10,
                BackColor = ColorTranslator.FromHtml("#171717"),
                ForeColor = ColorTranslator.FromHtml("#e8eae1")
            };

            toolbar.Controls.Add(addressBar);
            addressBar.KeyPress += AddressBar_KeyPress; // Add event handler for address bar key press
        }

        private void AddressBar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13) // Check if Enter key is pressed
            {
                if (webView != null && webView.CoreWebView2 != null)
                {
                    string url = addressBar.Text;
                    if (url.Contains(AppDataHtmlFilePath))
                    {
                        addressBar.Text = "simple://start"; // Replace specific URL with custom scheme
                    }
                    else
                    {
                        webView.CoreWebView2.Navigate(url); // Navigate to the entered URL
                    }
                }
            }
        }

        private WebView2 GetWebView()
        {
            return webView; // Return the WebView2 instance
        }

        private async void InitializeAsync(WebView2 SimpleWeb)
        {
            // Create and configure the WebView2 instance
            SimpleWeb = new WebView2
            {
                Dock = DockStyle.Fill,
                CreationProperties = new CoreWebView2CreationProperties()
                {
                    UserDataFolder = UserDataFolderPath
                }
            };

            await SimpleWeb.EnsureCoreWebView2Async(null); // Initialize the WebView2 control

            Controls.Add(SimpleWeb);
            this.Controls.SetChildIndex(SimpleWeb, 0); // Set the WebView2 control as the first child
            SimpleWeb.CoreWebView2.NavigationCompleted += CoreWebView2_NavigationCompleted; // Add event handler for navigation completed
            SimpleWeb.CoreWebView2.SourceChanged += CoreWebView2_SourceChanged; // Add event handler for source changed

            SimpleWeb.CoreWebView2.Navigate(DefaultHtmlFilePath); // Navigate to the default HTML file
        }

        private void CoreWebView2_SourceChanged(object sender, CoreWebView2SourceChangedEventArgs e)
        {
            string url = ((CoreWebView2)sender).Source.ToString();
            // Update the address bar text based on the URL
            addressBar.Text = url.Contains("SimpleBrowser/Resources/newtab/index.html") ? "simple://start" : url;
        }

        private async void CoreWebView2_NavigationCompleted(object sender, CoreWebView2NavigationCompletedEventArgs e)
        {
            if (webView != null && webView.CoreWebView2 != null)
            {
                string title = await webView.CoreWebView2.ExecuteScriptAsync("document.title");
                title = title.Trim('"'); // Remove the surrounding quotes from the title
                this.Text = $"Simple Web - {title}";
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Open a file dialog to select an HTML file
            using (OpenFileDialog dialog = new OpenFileDialog { Filter = "HTML Documents|*.html;*.htm" })
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = dialog.FileName;
                    webView.CoreWebView2.Navigate(filePath); // Navigate to the selected file
                }
            }
        }

        private void openNewWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("Simple-Browser.exe"); // Open a new instance of the browser
        }

        private void inDefaultBrowserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string url = "https://github.com/Daniel-McGuire-Corporation/Simple-Browser/issues/new/choose";
            Process.Start(new ProcessStartInfo("cmd", $"/c start {url}") { CreateNoWindow = true }); // Open URL in default browser
        }

        private void aboutWindowsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo("winver")); // Open Windows version dialog
        }

        private void resetBrowserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Run a batch file to reset the browser
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = "conhost.exe",
                Arguments = "Reset.bat"
            };
            Process.Start(startInfo);
        }

        private void viewHelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Create a new instance of Form2
            AboutBox aboutBox = new AboutBox();
            aboutBox.ShowDialog();
        }

        private void closeAltToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void returnToStartPageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webView.CoreWebView2.Navigate("C:/Program Files (x86)/SimpleBrowser/Resources/newtab/index.html");
        }

        private void reportBugToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void inSimpleBrowserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webView.CoreWebView2.Navigate("https://github.com/Daniel-McGuire-Corporation/Simple-Browser/issues/new/choose");
        }

        private void Browser_Load(object sender, EventArgs e)
        {

        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string url = "https://github.com/Daniel-McGuire-Corporation/Simple-Browser/issues/new/choose";
            Process.Start(new ProcessStartInfo("cmd", $"/c start {url}") { CreateNoWindow = true });
        }

        private void getUpdatesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void windowsPackageManagerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string updatepath = "C:\\Program Files (x86)\\SimpleBrowser\\Updater.exe";
            Process.Start(new ProcessStartInfo(updatepath) { CreateNoWindow = false });
        }

        private void gitHubToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string url = "https://github.com/Daniel-McGuire-Corporation/Simple-Browser/releases/latest";
            Process.Start(new ProcessStartInfo("cmd", $"/c start {url}") { CreateNoWindow = true });
        }

        private void builtInUpdateUtilityMayNotWorkOnWindows10AndEarlierToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }
    }
}
