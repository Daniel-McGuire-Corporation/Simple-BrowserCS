namespace Webview2_Test
{
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
            SuspendLayout();
            // 
            // ok
            // 
            ok.BackColor = Color.Transparent;
            ok.Location = new Point(253, 71);
            ok.Name = "ok";
            ok.Size = new Size(88, 23);
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
            label1.ForeColor = Color.White;
            label1.Location = new Point(76, 10);
            label1.Name = "label1";
            label1.Size = new Size(168, 21);
            label1.TabIndex = 1;
            label1.Text = "Simple Browser 2.2.0.5";
            // 
            // update
            // 
            update.Location = new Point(13, 71);
            update.Name = "update";
            update.Size = new Size(134, 23);
            update.TabIndex = 2;
            update.Text = "Check for Updates";
            update.UseVisualStyleBackColor = true;
            update.Click += update_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = Color.White;
            label2.Location = new Point(99, 44);
            label2.Name = "label2";
            label2.Size = new Size(141, 15);
            label2.TabIndex = 3;
            label2.Text = "Copyright (C) 2023 - 2024";
            // 
            // AboutBox
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(64, 64, 64);
            ClientSize = new Size(354, 107);
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
    }
}
