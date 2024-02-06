using System.Diagnostics;

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
            var uri = "https://github.com/DanielLMcGuire/Simple-Browser/releases/latest";
            var psi = new System.Diagnostics.ProcessStartInfo();
            psi.UseShellExecute = true;
            psi.FileName = uri;
            System.Diagnostics.Process.Start(psi);
        }

        private void ok_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void license_Click(object sender, EventArgs e)
        {
            string url = "https://github.com/DanielLMcGuire/Simple-Browser/blob/main/license";
            Process.Start(new ProcessStartInfo("cmd", $"/c start msedge --app={url}") { CreateNoWindow = true });
        }
    }
}
