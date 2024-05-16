namespace Webview2_Test;

partial class AboutBox
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
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
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        ok = new Button();
        label1 = new Label();
        update = new Button();
        label2 = new Label();
        license = new Button();
        label3 = new Label();
        label4 = new Label();
        label6 = new Label();
        SuspendLayout();
        // 
        // ok
        // 
        ok.BackColor = Color.Transparent;
        ok.Location = new Point(297, 101);
        ok.Name = "ok";
        ok.Size = new Size(44, 23);
        ok.TabIndex = 0;
        ok.Text = "OK";
        ok.UseVisualStyleBackColor = false;
        ok.Click += ok_Click;
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.BackColor = Color.Transparent;
        label1.Font = new Font("Segoe UI", 12F);
        label1.ForeColor = Color.FromArgb(232, 234, 225);
        label1.ImageAlign = ContentAlignment.TopCenter;
        label1.Location = new Point(100, 12);
        label1.Name = "label1";
        label1.Size = new Size(162, 21);
        label1.TabIndex = 1;
        label1.Text = "Simple Browser 24Q3";
        label1.Click += label1_Click;
        // 
        // update
        // 
        update.Location = new Point(13, 101);
        update.Name = "update";
        update.Size = new Size(116, 23);
        update.TabIndex = 2;
        update.Text = "Check for Updates";
        update.UseVisualStyleBackColor = true;
        update.Click += update_Click;
        // 
        // label2
        // 
        label2.AutoSize = true;
        label2.ForeColor = Color.FromArgb(232, 234, 225);
        label2.Location = new Point(114, 41);
        label2.Name = "label2";
        label2.Size = new Size(141, 15);
        label2.TabIndex = 3;
        label2.Text = "Copyright (C) 2023 - 2024";
        // 
        // license
        // 
        license.Location = new Point(161, 101);
        license.Name = "license";
        license.Size = new Size(111, 23);
        license.TabIndex = 4;
        license.Text = "View License";
        license.UseVisualStyleBackColor = true;
        license.Click += license_Click;
        // 
        // label3
        // 
        label3.AutoSize = true;
        label3.ForeColor = Color.FromArgb(232, 234, 225);
        label3.Location = new Point(55, 56);
        label3.Name = "label3";
        label3.Size = new Size(254, 15);
        label3.TabIndex = 5;
        label3.Text = "Daniel McGuire Corporation (and contributors)";
        label3.Click += label3_Click;
        // 
        // label4
        // 
        label4.AutoSize = true;
        label4.ForeColor = SystemColors.Control;
        label4.Location = new Point(67, 83);
        label4.Name = "label4";
        label4.Size = new Size(234, 15);
        label4.TabIndex = 6;
        label4.Text = "Runs on the Microsoft Edge (C) Framework";
        // 
        // label6
        // 
        label6.AutoSize = true;
        label6.Font = new Font("Segoe UI", 7F);
        label6.ForeColor = Color.FromArgb(232, 234, 225);
        label6.Location = new Point(263, 19);
        label6.Name = "label6";
        label6.Size = new Size(78, 12);
        label6.TabIndex = 8;
        label6.Text = "Build 2.5.1.2.2420";
        label6.Click += label6_Click;
        // 
        // AboutBox
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.FromArgb(32, 33, 36);
        ClientSize = new Size(354, 136);
        Controls.Add(label6);
        Controls.Add(label4);
        Controls.Add(label3);
        Controls.Add(license);
        Controls.Add(label2);
        Controls.Add(update);
        Controls.Add(label1);
        Controls.Add(ok);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        Margin = new Padding(4, 3, 4, 3);
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "AboutBox";
        Padding = new Padding(10);
        ShowIcon = false;
        ShowInTaskbar = false;
        StartPosition = FormStartPosition.CenterParent;
        Text = "About Simple Browser";
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Button ok;
    private Label label1;
    private Button update;
    private Label label2;
    private Button license;
    private Label label3;
    private Label label4;
    private Label label6;
}
