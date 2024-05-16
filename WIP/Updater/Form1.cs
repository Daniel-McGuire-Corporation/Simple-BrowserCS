//   _____ _                 _        _    _           _       _            
//  / ____(_)               | |      | |  | |         | |     | |           
// | (___  _ _ __ ___  _ __ | | ___  | |  | |_ __   __| | __ _| |_ ___ _ __ 
//  \___ \| | '_ ` _ \| '_ \| |/ _ \ | |  | | '_ \ / _` |/ _` | __/ _ \ '__|
//  ____) | | | | | | | |_) | |  __/ | |__| | |_) | (_| | (_| | ||  __/ |   
// |_____/|_|_| |_| |_| .__/|_|\___|  \____/| .__/ \__, _|\__, _|\__\___|_|   
//                    | |         Graphic by|:| Andrew M                             
//                    |_|                   |_|
// Copyright (C) Daniel McGuire Corporation
// Simple Browser (v2.4.1.0) (Updater v0.1.0)
// THANKS FOR CONTRIBUTING (or Building from Source)
// This file is part of Simple Browser Updater
//
// Form1.cs
using System;
using System.Windows.Forms;
using System.Net;
using Newtonsoft.Json;
using System.Diagnostics;
using System.IO;

namespace Updater
{
    public partial class UpdaterForm : Form
    {
        // GitHub API URL and repository information
        private const string GitHubRepoUrl = "https://api.github.com/repos/{owner}/{repo}/releases/latest";
        private const string Owner = "Daniel-McGuire-Corporation";
        private const string Repo = "Simple-Browser";
        private const string CurrentVersion = "2.4.1.0"; // Update this with your current version number

        private ProgressBar progressBar2;
        private Label label1;

        // Add your personal access token here
        // You will need one, as i cannot release mine
        private const string PersonalAccessToken = "<TOKEN>";

        public UpdaterForm()
        {
            InitializeComponent();

            // Customize form appearance for a custom title bar
            this.FormBorderStyle = FormBorderStyle.None;
            this.BackColor = System.Drawing.Color.FromArgb(32, 33, 36); // Dark background color
            this.ForeColor = System.Drawing.Color.White; // White text color
            this.Paint += (s, e) =>
            {
                e.Graphics.FillRectangle(new System.Drawing.SolidBrush(System.Drawing.Color.FromArgb(32, 33, 36)), e.ClipRectangle);
            };

            // Add drag functionality to move the form
            this.MouseDown += (s, e) =>
            {
                if (e.Button == MouseButtons.Left)
                {
                    ReleaseCapture();
                    SendMessage(this.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
                }
            };
        }

        // Import Win32 API functions for dragging the form without a title bar
        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        private static extern bool ReleaseCapture();

        private void UpdaterForm_Load(object sender, EventArgs e)
        {
            // Check for updates when the form loads
            CheckForUpdates();
        }

        private void CheckForUpdates()
        {
            using (WebClient wc = new WebClient())
            {
                try
                {
                    // Add personal access token to the request headers
                    wc.Headers.Add("Authorization", "token " + PersonalAccessToken);

                    // Fetch release information from GitHub
                    string json = wc.DownloadString(GitHubRepoUrl.Replace("{owner}", Owner).Replace("{repo}", Repo));
                    dynamic release = JsonConvert.DeserializeObject(json);
                    string latestVersion = release.tag_name;

                    // Compare versions
                    Version currentVersion = new Version(CurrentVersion);
                    Version latest = new Version(latestVersion);

                    // Check if update is available
                    if (latest > currentVersion)
                    {
                        // Update available logic

                        // Download the update file asynchronously
                        string downloadUrl = release.assets[0].browser_download_url; // Assuming the first asset is the installer
                        string tempFilePath = Path.GetTempFileName();

                        // Update download progress and file info display
                        wc.DownloadProgressChanged += (s, args) =>
                        {
                            // Update progress bar
                            progressBar2.Value = args.ProgressPercentage;
                            // Show file info
                            label1.Text = $"{(args.BytesReceived / 1024.0 / 1024.0).ToString("0.00")}MB of {(args.TotalBytesToReceive / 1024.0 / 1024.0).ToString("0.00")}MB";
                        };

                        // After download completion, install the update and exit
                        wc.DownloadFileCompleted += (s, args) =>
                        {
                            // Install update
                            Process.Start(tempFilePath);
                            Application.Exit(); // Close the updater immediately
                        };

                        // Start downloading the update file asynchronously
                        wc.DownloadFileAsync(new Uri(downloadUrl), tempFilePath);
                    }
                    else
                    {
                        // No update available, open main program

                        // Inform the user
                        MessageBox.Show("You are already using the latest version.", "No Updates", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Open main program
                        // Replace "YourMainProgram.exe" with your main program's executable file name
                        Process.Start("YourMainProgram.exe");

                        // Close the updater immediately
                        Application.Exit();
                    }
                }
                catch (Exception ex)
                {
                    // Error handling for update check
                    MessageBox.Show("An error occurred while checking for updates: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void InitializeComponent()
        {
            this.progressBar2 = new ProgressBar();
            this.label1 = new Label();
            this.SuspendLayout();
            // 
            // progressBar2
            // 
            this.progressBar2.Location = new System.Drawing.Point(12, 198);
            this.progressBar2.Name = "progressBar2";
            this.progressBar2.Size = new System.Drawing.Size(260, 23);
            this.progressBar2.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 224);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 15);
            this.label1.TabIndex = 1;
            // 
            // UpdaterForm
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.progressBar2);
            this.Name = "UpdaterForm";
            this.ShowIcon = false;
            this.Load += new System.EventHandler(this.UpdaterForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
