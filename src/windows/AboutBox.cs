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
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = "conhost.exe";
            startInfo.Arguments = "Updater.bat";
            Process.Start(startInfo);
            this.Close();
        }

        private void ok_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void license_Click(object sender, EventArgs e)
        {


            // Get the current assembly
            var assembly = Assembly.GetExecutingAssembly();

            // The name of the resource we want to access
            var resourceName = "Webview2_Test.LICENSE.txt";

            // Get the resource stream
            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            {
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

        private void label1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Full Version String: 24q2.4.0.0-1559_pc-mn                        (WinGet Version 2.4.0)" +
                "                                                                      GitHub Release: https://github.com/Daniel-McGuire-Corporation/Simple-Browser/releases/tag/v2.4.0.0", "Simple Browser | Advanced Version Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
