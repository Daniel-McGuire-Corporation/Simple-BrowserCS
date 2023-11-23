// Copyright (C) Daniel McGuire Corporation
//
// WE ARE VERY CLOSE TO 1.2.0 (just need to add tabs)
//
// Simple Browser (v1.0.0) - A very simple browser based on the 
// Microsoft Edge (Chromium) WebView2 Framework
// Maybe I can make this using some sort of Chromium Base Framework?
// THANKS FOR CONTRIBUTING (ignore if building from source lmao)
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

            addressBar.KeyPress += (sender, e) =>
            {
                if (e.KeyChar == (char)13)
                {
                    if (webView != null && webView.CoreWebView2 != null)
                    {
                        string url = addressBar.Text;
                        if (url.Contains(GetAppDataHtmlFilePath()))
                        {
                            addressBar.Text = "simple://newtab";
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

        private async void InitializeAsync()
        {
            webView = new WebView2
            {
                Dock = DockStyle.Fill,
            };
            await webView.EnsureCoreWebView2Async(null);

            this.Controls.Add(webView);
            this.Controls.SetChildIndex(webView, 0);

            webView.CoreWebView2.NavigationCompleted += CoreWebView2_NavigationCompleted;

            webView.CoreWebView2.SourceChanged += (sender, e) =>
            {
                string url = webView.CoreWebView2.Source.ToString();
                if (url.Contains("SimpleBrowser/Resources/NewTab/NewTab.html"))
                {
                    addressBar.Text = "simple://newtab";
                }
                else
                {
                    addressBar.Text = url;
                }
            };

            // Navigate to the default index.html file
            string defaultHtmlFilePath = GetDefaultHtmlFilePath();
            webView.CoreWebView2.Navigate(defaultHtmlFilePath);
        }

        private string GetDefaultHtmlFilePath()
        {
            string filePath = @"C:\Program Files (x86)\SimpleBrowser\Resources\NewTab\NewTab.html";
            return filePath;
        }

        private string GetAppDataHtmlFilePath()
        {
            string filePath = @"C:\Program Files (x86)\SimpleBrowser\Resources\NewTab\NewTab.html";
            return filePath;
        }

        private void CoreWebView2_NavigationCompleted(object sender, CoreWebView2NavigationCompletedEventArgs e)
        {
            // Handle navigation completion if needed
        }
    }
}
