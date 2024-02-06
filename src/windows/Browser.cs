// Copyright (C) Daniel McGuire Corporation
// Simple Browser (v2.3.0.2)
// THANKS FOR CONTRIBUTING (or Building from Source)
// This file is part of Simple Browser. (Obviously)
//
// Form1.cs
using Microsoft.Web.WebView2.WinForms;
using Microsoft.Web.WebView2.Core;
using System.Diagnostics;

namespace Webview2_Test
{
    public partial class Browser : Form
    {
        private WebView2 webView;
        private TextBox addressBar;

        public Browser()
        {
            InitializeComponent();
            // Line Below sets the title bar text to whatever you want it to be (Simple Web) in this case.
            this.Text = "Simple Web";

            Panel toolbar = new Panel()
            {
                Dock = DockStyle.Top,
                Height = 20,
                BackColor = ColorTranslator.FromHtml("#202124"),
            };
            this.Controls.Add(toolbar);

            addressBar = new TextBox()
            {
                Dock = DockStyle.Fill,
                Height = 10,
                BackColor = ColorTranslator.FromHtml("#171717"),
                ForeColor = ColorTranslator.FromHtml("#e8eae1")
            };

            toolbar.Controls.Add(addressBar);
            // This event is fired when the user presses Enter in the address bar.
            addressBar.KeyPress += (sender, e) =>
            {
                if (e.KeyChar == (char)13)
                {
                    if (webView != null && webView.CoreWebView2 != null)
                    {
                        string url = addressBar.Text;
                        if (url.Contains(GetAppDataHtmlFilePath()))
                        {
                            addressBar.Text = "simple://start";
                        }
                        else
                        {
                            webView.CoreWebView2.Navigate(url);

                        }
                    }

                }
            };


            InitializeAsync();
        }

        // This method is called when the form is loaded.
        private async void InitializeAsync()
        {
            webView = new WebView2
            {
                Dock = DockStyle.Fill,
            };

            webView.CreationProperties = new CoreWebView2CreationProperties()
            {
                UserDataFolder = $"C:\\Users\\{Environment.UserName}\\AppData\\Local\\SimpleBrowser"
            };

            await webView.EnsureCoreWebView2Async(null);

            this.Controls.Add(webView);
            this.Controls.SetChildIndex(webView, 0);

            webView.CoreWebView2.NavigationCompleted += CoreWebView2_NavigationCompleted;

            // This event is fired when the user presses the Back button.
            webView.CoreWebView2.SourceChanged += (sender, e) =>
            {
                string url = webView.CoreWebView2.Source.ToString();
                if (url.Contains("SimpleBrowser/Resources/NewTab/NewTab.html"))
                {
                    addressBar.Text = "simple://start";
                }
                else
                {
                    addressBar.Text = url;
                }
            };

            // This event is fired when the user presses the Back button.
            string defaultHtmlFilePath = GetDefaultHtmlFilePath();
            webView.CoreWebView2.Navigate(defaultHtmlFilePath);
        }


        // These methods art called when the user navigates to a new page.
        private string GetDefaultHtmlFilePath()
        {
            string filePath = @"C:\Program Files (x86)\SimpleBrowser\Resources\NewTab\NewTab.html";
            return filePath;
        }
        private string GetAppDataHtmlFilePath()
        {
            string filePath = @"C:///Program Files (x86)///SimpleBrowser///Resources///NewTab///NewTab.html";
            return filePath;
        }
        private void CoreWebView2_NavigationCompleted(object sender, CoreWebView2NavigationCompletedEventArgs e)
        {
            // Check if the navigation was successful
            if (e.IsSuccess)
            {
            }
            else
            {
                // Do something if the navigation failed
                MessageBox.Show("Navigation failed with error code: " + e.WebErrorStatus);
            }
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
            webView.CoreWebView2.Navigate("C:/Program Files (x86)/SimpleBrowser/Resources/NewTab/NewTab.html");
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Web Files|*.html;*.htm";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = dialog.FileName; // this is the file path of the selected file
                webView.CoreWebView2.Navigate(filePath); // this will pass the file path to the navigate method
            }


        }

        private void openNewWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("Simple-Browser.exe");
        }

        private void reportBugToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void inSimpleBrowserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webView.CoreWebView2.Navigate("https://github.com/DanielLMcGuire/Simple-Browser/issues/new/choose");
        }

        private void inDefaultBrowserToolStripMenuItem_Click(object sender, EventArgs e)
        {

            string url = "https://github.com/DanielLMcGuire/Simple-Browser/issues/new/choose";
            Process.Start(new ProcessStartInfo("cmd", $"/c start {url}"));

        }

        private void Browser_Load(object sender, EventArgs e)
        {

        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void aboutWindowsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo("winver"));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string url = "https://github.com/DanielLMcGuire/Simple-Browser/issues/new/choose";
            Process.Start(new ProcessStartInfo("cmd", $"/c start {url}"));
        }
    }
}
