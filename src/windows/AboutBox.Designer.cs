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
            ok.Location = new Point(188, 71);
            ok.Name = "ok";
            ok.Size = new Size(88, 23);
            ok.TabIndex = 0;
            ok.Text = "OK";
            ok.UseVisualStyleBackColor = true;
            ok.Click += ok_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(17, 16);
            label1.Name = "label1";
            label1.Size = new Size(136, 15);
            label1.TabIndex = 1;
            label1.Text = "Simple Browser 2.0.0.257";
            // 
            // update
            // 
            update.Location = new Point(13, 71);
            update.Name = "update";
            update.Size = new Size(169, 23);
            update.TabIndex = 2;
            update.Text = "Check GitHub for Updates";
            update.UseVisualStyleBackColor = true;
            update.Click += update_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(17, 40);
            label2.Name = "label2";
            label2.Size = new Size(141, 15);
            label2.TabIndex = 3;
            label2.Text = "Copyright (C) 2023 - 2024";
            // 
            // AboutBox
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(284, 107);
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
