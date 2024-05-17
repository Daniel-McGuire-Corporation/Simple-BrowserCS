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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Browser));
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
            getUpdatesToolStripMenuItem = new ToolStripMenuItem();
            windowsPackageManagerToolStripMenuItem = new ToolStripMenuItem();
            gitHubToolStripMenuItem = new ToolStripMenuItem();
            builtInUpdateUtilityMayNotWorkOnWindows10AndEarlierToolStripMenuItem = new ToolStripMenuItem();
            updateUtilityRequiresWindows10ToolStripMenuItem = new ToolStripMenuItem();
            reportBugToolStripMenuItem = new ToolStripMenuItem();
            inSimpleBrowserToolStripMenuItem = new ToolStripMenuItem();
            inDefaultBrowserToolStripMenuItem = new ToolStripMenuItem();
            simpleWebV2ToolStripMenuItem = new ToolStripMenuItem();
            pictureBox1 = new PictureBox();
            label1 = new Label();
            label2 = new Label();
            resetBrowserToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = Color.FromArgb(23, 23, 23);
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, viewToolStripMenuItem, helpToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(858, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { openToolStripMenuItem, openNewWindowToolStripMenuItem, closeAltToolStripMenuItem, resetBrowserToolStripMenuItem });
            fileToolStripMenuItem.ForeColor = Color.FromArgb(232, 234, 225);
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(37, 20);
            fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            openToolStripMenuItem.Name = "openToolStripMenuItem";
            openToolStripMenuItem.Size = new Size(180, 22);
            openToolStripMenuItem.Text = "Open";
            openToolStripMenuItem.Click += openToolStripMenuItem_Click;
            // 
            // openNewWindowToolStripMenuItem
            // 
            openNewWindowToolStripMenuItem.Name = "openNewWindowToolStripMenuItem";
            openNewWindowToolStripMenuItem.Size = new Size(180, 22);
            openNewWindowToolStripMenuItem.Text = "Open New Window";
            openNewWindowToolStripMenuItem.Click += openNewWindowToolStripMenuItem_Click;
            // 
            // closeAltToolStripMenuItem
            // 
            closeAltToolStripMenuItem.Name = "closeAltToolStripMenuItem";
            closeAltToolStripMenuItem.Size = new Size(180, 22);
            closeAltToolStripMenuItem.Text = "Close (Alt+F4)";
            closeAltToolStripMenuItem.Click += closeAltToolStripMenuItem_Click;
            // 
            // viewToolStripMenuItem
            // 
            viewToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { returnToStartPageToolStripMenuItem });
            viewToolStripMenuItem.ForeColor = Color.FromArgb(232, 234, 225);
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
            helpToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { viewHelpToolStripMenuItem, aboutWindowsToolStripMenuItem, getUpdatesToolStripMenuItem, reportBugToolStripMenuItem, simpleWebV2ToolStripMenuItem });
            helpToolStripMenuItem.ForeColor = Color.FromArgb(232, 234, 225);
            helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            helpToolStripMenuItem.Size = new Size(52, 20);
            helpToolStripMenuItem.Text = "About";
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
            // getUpdatesToolStripMenuItem
            // 
            getUpdatesToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { windowsPackageManagerToolStripMenuItem, gitHubToolStripMenuItem, builtInUpdateUtilityMayNotWorkOnWindows10AndEarlierToolStripMenuItem, updateUtilityRequiresWindows10ToolStripMenuItem });
            getUpdatesToolStripMenuItem.Name = "getUpdatesToolStripMenuItem";
            getUpdatesToolStripMenuItem.Size = new Size(191, 22);
            getUpdatesToolStripMenuItem.Text = "Get Updates";
            getUpdatesToolStripMenuItem.Click += getUpdatesToolStripMenuItem_Click;
            // 
            // windowsPackageManagerToolStripMenuItem
            // 
            windowsPackageManagerToolStripMenuItem.Name = "windowsPackageManagerToolStripMenuItem";
            windowsPackageManagerToolStripMenuItem.Size = new Size(259, 22);
            windowsPackageManagerToolStripMenuItem.Text = "Built-In Update Utility ";
            windowsPackageManagerToolStripMenuItem.Click += windowsPackageManagerToolStripMenuItem_Click;
            // 
            // gitHubToolStripMenuItem
            // 
            gitHubToolStripMenuItem.Name = "gitHubToolStripMenuItem";
            gitHubToolStripMenuItem.Size = new Size(259, 22);
            gitHubToolStripMenuItem.Text = "GitHub";
            gitHubToolStripMenuItem.Click += gitHubToolStripMenuItem_Click;
            // 
            // builtInUpdateUtilityMayNotWorkOnWindows10AndEarlierToolStripMenuItem
            // 
            builtInUpdateUtilityMayNotWorkOnWindows10AndEarlierToolStripMenuItem.Name = "builtInUpdateUtilityMayNotWorkOnWindows10AndEarlierToolStripMenuItem";
            builtInUpdateUtilityMayNotWorkOnWindows10AndEarlierToolStripMenuItem.Size = new Size(259, 22);
            builtInUpdateUtilityMayNotWorkOnWindows10AndEarlierToolStripMenuItem.Text = "Click Here If Update Utility Failed";
            builtInUpdateUtilityMayNotWorkOnWindows10AndEarlierToolStripMenuItem.Click += builtInUpdateUtilityMayNotWorkOnWindows10AndEarlierToolStripMenuItem_Click;
            // 
            // updateUtilityRequiresWindows10ToolStripMenuItem
            // 
            updateUtilityRequiresWindows10ToolStripMenuItem.BackColor = SystemColors.ControlLight;
            updateUtilityRequiresWindows10ToolStripMenuItem.ForeColor = SystemColors.GrayText;
            updateUtilityRequiresWindows10ToolStripMenuItem.Name = "updateUtilityRequiresWindows10ToolStripMenuItem";
            updateUtilityRequiresWindows10ToolStripMenuItem.Size = new Size(259, 22);
            updateUtilityRequiresWindows10ToolStripMenuItem.Text = "Utility Requires Win11 22H2 or later";
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
            // simpleWebV2ToolStripMenuItem
            // 
            simpleWebV2ToolStripMenuItem.BackColor = SystemColors.ControlLight;
            simpleWebV2ToolStripMenuItem.ForeColor = SystemColors.GrayText;
            simpleWebV2ToolStripMenuItem.Name = "simpleWebV2ToolStripMenuItem";
            simpleWebV2ToolStripMenuItem.Size = new Size(191, 22);
            simpleWebV2ToolStripMenuItem.Text = "Simple Web 24Q3 ";
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = (Image)resources.GetObject("pictureBox1.BackgroundImage");
            pictureBox1.Location = new Point(196, 27);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(501, 507);
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20F);
            label1.ForeColor = Color.WhiteSmoke;
            label1.Location = new Point(0, 488);
            label1.Name = "label1";
            label1.Size = new Size(306, 37);
            label1.TabIndex = 2;
            label1.Text = "Simple Browser (C) 2024";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 50F);
            label2.ForeColor = Color.Snow;
            label2.Location = new Point(0, 72);
            label2.Name = "label2";
            label2.Size = new Size(197, 89);
            label2.TabIndex = 3;
            label2.Text = "24Q3";
            // 
            // resetBrowserToolStripMenuItem
            // 
            resetBrowserToolStripMenuItem.Name = "resetBrowserToolStripMenuItem";
            resetBrowserToolStripMenuItem.Size = new Size(180, 22);
            resetBrowserToolStripMenuItem.Text = "Reset Browser";
            resetBrowserToolStripMenuItem.Click += resetBrowserToolStripMenuItem_Click;
            // 
            // Browser
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(0, 30, 80);
            ClientSize = new Size(858, 525);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(menuStrip1);
            Controls.Add(pictureBox1);
            ForeColor = SystemColors.ControlText;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            Name = "Browser";
            Text = "Simple Web";
            Load += Browser_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
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
        private ToolStripMenuItem simpleWebV2ToolStripMenuItem;
        private ToolStripMenuItem getUpdatesToolStripMenuItem;
        private ToolStripMenuItem gitHubToolStripMenuItem;
        private ToolStripMenuItem windowsPackageManagerToolStripMenuItem;
        private ToolStripMenuItem builtInUpdateUtilityMayNotWorkOnWindows10AndEarlierToolStripMenuItem;
        private ToolStripMenuItem updateUtilityRequiresWindows10ToolStripMenuItem;
        private PictureBox pictureBox1;
        private Label label1;
        private Label label2;
        private ToolStripMenuItem resetBrowserToolStripMenuItem;
    }
}
