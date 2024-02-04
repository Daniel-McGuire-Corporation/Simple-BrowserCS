// Form1.Designer.cs
using System.Windows.Forms;

namespace Webview2_Test
{
    partial class Browser : Form
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            openToolStripMenuItem = new ToolStripMenuItem();
            openNewWindowToolStripMenuItem = new ToolStripMenuItem();
            closeAltToolStripMenuItem = new ToolStripMenuItem();
            viewToolStripMenuItem = new ToolStripMenuItem();
            returnToStartPageToolStripMenuItem = new ToolStripMenuItem();
            helpToolStripMenuItem = new ToolStripMenuItem();
            viewHelpToolStripMenuItem = new ToolStripMenuItem();
            aboutWindowsToolStripMenuItem = new ToolStripMenuItem();
            reportBugToolStripMenuItem = new ToolStripMenuItem();
            inSimpleBrowserToolStripMenuItem = new ToolStripMenuItem();
            inDefaultBrowserToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = Color.FromArgb(32, 32, 32);
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, viewToolStripMenuItem, helpToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { openToolStripMenuItem, openNewWindowToolStripMenuItem, closeAltToolStripMenuItem });
            fileToolStripMenuItem.ForeColor = Color.Silver;
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(37, 20);
            fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            openToolStripMenuItem.Name = "openToolStripMenuItem";
            openToolStripMenuItem.Size = new Size(177, 22);
            openToolStripMenuItem.Text = "Open";
            openToolStripMenuItem.Click += openToolStripMenuItem_Click;
            // 
            // openNewWindowToolStripMenuItem
            // 
            openNewWindowToolStripMenuItem.Name = "openNewWindowToolStripMenuItem";
            openNewWindowToolStripMenuItem.Size = new Size(177, 22);
            openNewWindowToolStripMenuItem.Text = "Open New Window";
            openNewWindowToolStripMenuItem.Click += openNewWindowToolStripMenuItem_Click;
            // 
            // closeAltToolStripMenuItem
            // 
            closeAltToolStripMenuItem.Name = "closeAltToolStripMenuItem";
            closeAltToolStripMenuItem.Size = new Size(177, 22);
            closeAltToolStripMenuItem.Text = "Close (Alt+F4)";
            closeAltToolStripMenuItem.Click += closeAltToolStripMenuItem_Click;
            // 
            // viewToolStripMenuItem
            // 
            viewToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { returnToStartPageToolStripMenuItem });
            viewToolStripMenuItem.ForeColor = Color.Silver;
            viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            viewToolStripMenuItem.Size = new Size(44, 20);
            viewToolStripMenuItem.Text = "View";
            // 
            // returnToStartPageToolStripMenuItem
            // 
            returnToStartPageToolStripMenuItem.Name = "returnToStartPageToolStripMenuItem";
            returnToStartPageToolStripMenuItem.Size = new Size(179, 22);
            returnToStartPageToolStripMenuItem.Text = "Return to Start Page";
            returnToStartPageToolStripMenuItem.Click += returnToStartPageToolStripMenuItem_Click;
            // 
            // helpToolStripMenuItem
            // 
            helpToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { viewHelpToolStripMenuItem, aboutWindowsToolStripMenuItem, reportBugToolStripMenuItem });
            helpToolStripMenuItem.ForeColor = Color.Silver;
            helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            helpToolStripMenuItem.Size = new Size(44, 20);
            helpToolStripMenuItem.Text = "Help";
            helpToolStripMenuItem.Click += helpToolStripMenuItem_Click;
            // 
            // viewHelpToolStripMenuItem
            // 
            viewHelpToolStripMenuItem.Name = "viewHelpToolStripMenuItem";
            viewHelpToolStripMenuItem.Size = new Size(191, 22);
            viewHelpToolStripMenuItem.Text = "About Simple Browser";
            viewHelpToolStripMenuItem.Click += viewHelpToolStripMenuItem_Click;
            // 
            // aboutWindowsToolStripMenuItem
            // 
            aboutWindowsToolStripMenuItem.Name = "aboutWindowsToolStripMenuItem";
            aboutWindowsToolStripMenuItem.Size = new Size(191, 22);
            aboutWindowsToolStripMenuItem.Text = "About Windows";
            aboutWindowsToolStripMenuItem.Click += aboutWindowsToolStripMenuItem_Click;
            // 
            // reportBugToolStripMenuItem
            // 
            reportBugToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { inSimpleBrowserToolStripMenuItem, inDefaultBrowserToolStripMenuItem });
            reportBugToolStripMenuItem.Name = "reportBugToolStripMenuItem";
            reportBugToolStripMenuItem.Size = new Size(191, 22);
            reportBugToolStripMenuItem.Text = "Report Bug";
            reportBugToolStripMenuItem.Click += reportBugToolStripMenuItem_Click;
            // 
            // inSimpleBrowserToolStripMenuItem
            // 
            inSimpleBrowserToolStripMenuItem.Name = "inSimpleBrowserToolStripMenuItem";
            inSimpleBrowserToolStripMenuItem.Size = new Size(170, 22);
            inSimpleBrowserToolStripMenuItem.Text = "In Simple Browser";
            inSimpleBrowserToolStripMenuItem.Click += inSimpleBrowserToolStripMenuItem_Click;
            // 
            // inDefaultBrowserToolStripMenuItem
            // 
            inDefaultBrowserToolStripMenuItem.Name = "inDefaultBrowserToolStripMenuItem";
            inDefaultBrowserToolStripMenuItem.Size = new Size(170, 22);
            inDefaultBrowserToolStripMenuItem.Text = "In Default Browser";
            inDefaultBrowserToolStripMenuItem.Click += inDefaultBrowserToolStripMenuItem_Click;
            // 
            // Browser
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(menuStrip1);
            ForeColor = SystemColors.ControlText;
            MainMenuStrip = menuStrip1;
            Name = "Browser";
            ShowIcon = false;
            Text = "Simple Web";
            Load += Browser_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem helpToolStripMenuItem;
        private ToolStripMenuItem viewHelpToolStripMenuItem;
        private ToolStripMenuItem closeAltToolStripMenuItem;
        private ToolStripMenuItem viewToolStripMenuItem;
        private ToolStripMenuItem returnToStartPageToolStripMenuItem;
        private ToolStripMenuItem openToolStripMenuItem;
        private ToolStripMenuItem openNewWindowToolStripMenuItem;
        private ToolStripMenuItem reportBugToolStripMenuItem;
        private ToolStripMenuItem inSimpleBrowserToolStripMenuItem;
        private ToolStripMenuItem inDefaultBrowserToolStripMenuItem;
        private ToolStripMenuItem aboutWindowsToolStripMenuItem;
    }
}
