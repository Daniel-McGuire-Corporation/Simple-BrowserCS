// Form1.cs
using Microsoft.Web.WebView2.WinForms;
using Microsoft.Web.WebView2.Core;

namespace Webview2_Test
{
    public partial class Form1 : Form
    {
        private WebView2 webView;
        private Button backButton;
        private Button forwardButton;

        private TextBox addressBar;

        public Form1()
        {
            InitializeComponent();

            // Create a Panel that will act as our custom toolbar
            Panel toolbar = new Panel()
            {
                Dock = DockStyle.Top,
                Height = 30,  // Adjust as needed
                BackColor = ColorTranslator.FromHtml("#F3F3F3"),  // Set the color to #F3F3F3
            };
            this.Controls.Add(toolbar);

            // Initialize addressBar
            addressBar = new TextBox()
            {
                Dock = DockStyle.Fill,  // This will make the address bar fill the remaining space in the toolbar
                Height = 20,  // Adjust as needed
            };

            toolbar.Controls.Add(addressBar);

            // Move the addition of the other controls after the address bar
            // Create a Button for refresh
            Button refreshButton = new Button()
            {
                Text = "Refresh",
                Width = 70,  // Adjust as needed
                Height = 20,  // Adjust as needed
                Top = 5,  // Adjust as needed
                Dock = DockStyle.Left,  // This will dock the button to the left
            };
            toolbar.Controls.Add(refreshButton);
            // Create a Button for going forward
            forwardButton = new Button()
            {
                Text = "Forward",
                Width = 70,  // Adjust as needed
                Height = 20,  // Adjust as needed
                Top = 5,  // Adjust as needed
                Dock = DockStyle.Left,  // This will dock the button to the left
            };
            toolbar.Controls.Add(forwardButton);
            // Create a Button for going back
            backButton = new Button()
            {
                Text = "Back",
                Width = 60,  // Adjust as needed
                Height = 20,  // Adjust as needed
                Top = 5,  // Adjust as needed
                Dock = DockStyle.Left,  // This will dock the button to the left
            };
            toolbar.Controls.Add(backButton);
            /// Handle the KeyPress event to navigate to the URL when Enter is pressed
            addressBar.KeyPress += (sender, e) =>
            {
                if (e.KeyChar == (char)13)  // 13 is the ASCII value for Enter
                {
                    if (webView != null && webView.CoreWebView2 != null)
                    {
                        string url = addressBar.Text;
                        if (url == "browser://newpage")
                        {
                            url = "https://web.tabliss.io/";
                        }
                        else if (!url.StartsWith("http://") && !url.StartsWith("https://"))
                        {
                            url = "http://" + url;
                        }
                        webView.CoreWebView2.Navigate(url);
                    }
                }
            };




            this.Controls.Add(webView);

            InitializeAsync();
        }

        private async void InitializeAsync()
        {
            webView = new WebView2
            {
                Dock = DockStyle.Fill,
            };
            await webView.EnsureCoreWebView2Async(null);
            webView.CoreWebView2.Navigate("https://web.tabliss.io/");

            // Add the webView control to the parent control's Controls collection
            this.Controls.Add(webView);

            // Now you can set the child index
            this.Controls.SetChildIndex(webView, 0); // Ensure the WebView2 control is behind the toolbar

            // Subscribe to the NavigationCompleted event
            webView.CoreWebView2.NavigationCompleted += CoreWebView2_NavigationCompleted;

            // Subscribe to the SourceChanged event
            webView.CoreWebView2.SourceChanged += (sender, e) =>
            {
                // Update the address bar with the new URL
                string url = webView.CoreWebView2.Source.ToString();
                if (url == "https://web.tabliss.io/")
                {
                    addressBar.Text = "browser://newpage";
                }
                else
                {
                    addressBar.Text = url;
                }
            };
        }




        private void CoreWebView2_NavigationCompleted(object sender, CoreWebView2NavigationCompletedEventArgs e)
        {
            // Enable or disable the Back button depending on if navigation can go back
            backButton.Enabled = webView.CoreWebView2.CanGoBack;

            // Enable or disable the Forward button depending on if navigation can go forward
            forwardButton.Enabled = webView.CoreWebView2.CanGoForward;
        }

    }
}

