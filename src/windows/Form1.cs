// Copyright (C) Daniel McGuire Corporation
// Simple Browser (v1.1.0)
// THANKS FOR CONTRIBUTING (or Building from Source)
// This file is part of Simple Browser. (Obviously)
//
// Form1.cs
using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Web.WebView2.WinForms;
using Microsoft.Web.WebView2.Core;

namespace Webview2_Test
{
    public partial class Form1 : Form
    {
        private WebView2 webView;
        private TextBox addressBar;
        
        public Form1()
        {
            InitializeComponent();
            // Line Below sets the title bar text to whatever you want it to be (Simple Web) in this case.
            this.Text = "Simple Web";

            Panel toolbar = new Panel()
            {
                Dock = DockStyle.Top,
                Height = 30,
                BackColor = ColorTranslator.FromHtml("#F3F3F3"),
            };
            this.Controls.Add(toolbar);
            
            addressBar = new TextBox()
            {
                Dock = DockStyle.Fill,
                Height = 20,
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


        // This method is called when the user navigates to a new page.
        private string GetDefaultHtmlFilePath()
        {
            string filePath = @"C:\Program Files (x86)\SimpleBrowser\Resources\NewTab\NewTab.html";
            return filePath;
        }
        // This method is called when the user navigates to a new page.
        private string GetAppDataHtmlFilePath()
        {
            string filePath = @"C:///Program Files (x86)///SimpleBrowser///Resources///NewTab///NewTab.html";
            return filePath;
        }

        private void CoreWebView2_NavigationCompleted(object sender, CoreWebView2NavigationCompletedEventArgs e)
        {
            // No clue what this is for.
        }
    }
}
