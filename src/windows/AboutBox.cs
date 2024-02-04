using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
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
    }
}
