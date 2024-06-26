using System.Diagnostics;
using System.Reflection;
using System.IO;
using System.Windows.Forms;

namespace Webview2_Test
{
    partial class AboutBox : Form
    {
        public AboutBox()
        {
            InitializeComponent();
        }
        
        private void update_Click(object sender, EventArgs e)
        {
            try
            {
                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    FileName = "conhost.exe",
                    Arguments = "Updater.bat"
                };
                Process.Start(startInfo);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to start the update process: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Close();
            }
        }

        private void ok_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void license_Click(object sender, EventArgs e)
        {
            try
            {
                // Get the current assembly
                var assembly = Assembly.GetExecutingAssembly();

                // The name of the resource we want to access
                var resourceName = "Webview2_Test.LICENSE.txt";

                // Get the resource stream
                using (Stream stream = assembly.GetManifestResourceStream(resourceName))
                {
                    if (stream == null)
                    {
                        MessageBox.Show("License file not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Read the stream
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        // Get the content of the file
                        string result = reader.ReadToEnd();

                        // Show the content in a message box
                        MessageBox.Show(result, "MIT License");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load the license: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Full Version String: 24Q3-2.5.1.2-2420_bg-fx (WinGet Version 2.5.1)\nGitHub Release: https://github.com/Daniel-McGuire-Corporation/Simple-Browser/releases/tag/v2.5.1.2", 
                "Simple Browser | Advanced Version Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
