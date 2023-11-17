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

        // Declare addressBar at the class level
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
                            url = "file:///C:/SimpleBrowser/Resources/NewPage/index.html";
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
            webView.CoreWebView2.Navigate("file:///C:/SimpleBrowser/Resources/NewPage/index.html");

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
                if (url == "file:///C:/SimpleBrowser/Resources/NewPage/index.html")
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
        }

    }
}

