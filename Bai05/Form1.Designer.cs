﻿namespace Bai05
{
    partial class Form1
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            tbUrl = new TextBox();
            tbPassword = new TextBox();
            tbUsername = new TextBox();
            btConnect = new Button();
            rtbContent = new RichTextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(23, 23);
            label1.Name = "label1";
            label1.Size = new Size(50, 20);
            label1.TabIndex = 0;
            label1.Text = "URL";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(23, 76);
            label2.Name = "label2";
            label2.Size = new Size(50, 20);
            label2.TabIndex = 1;
            label2.Text = "Username";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(23, 118);
            label3.Name = "label3";
            label3.Size = new Size(50, 20);
            label3.TabIndex = 2;
            label3.Text = "Password";
            // 
            // tbUrl
            // 
            tbUrl.BorderStyle = BorderStyle.FixedSingle;
            tbUrl.Location = new Point(109, 23);
            tbUrl.Name = "tbUrl";
            tbUrl.Size = new Size(421, 27);
            tbUrl.TabIndex = 3;
            // 
            // tbPassword
            // 
            tbPassword.BorderStyle = BorderStyle.FixedSingle;
            tbPassword.Location = new Point(109, 116);
            tbPassword.Name = "tbPassword";
            tbPassword.Size = new Size(247, 27);
            tbPassword.TabIndex = 4;
            // 
            // tbUsername
            // 
            tbUsername.BorderStyle = BorderStyle.FixedSingle;
            tbUsername.Location = new Point(109, 69);
            tbUsername.Name = "tbUsername";
            tbUsername.Size = new Size(247, 27);
            tbUsername.TabIndex = 5;
            // 
            // btConnect
            // 
            btConnect.Location = new Point(394, 69);
            btConnect.Name = "btConnect";
            btConnect.Size = new Size(136, 74);
            btConnect.TabIndex = 6;
            btConnect.Text = "Connect";
            btConnect.UseVisualStyleBackColor = true;
            btConnect.Click += btConnect_Click_1;
            // 
            // rtbContent
            // 
            rtbContent.BorderStyle = BorderStyle.FixedSingle;
            rtbContent.Location = new Point(23, 168);
            rtbContent.Name = "rtbContent";
            rtbContent.Size = new Size(507, 213);
            rtbContent.TabIndex = 7;
            rtbContent.Text = "";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(547, 425);
            Controls.Add(rtbContent);
            Controls.Add(btConnect);
            Controls.Add(tbUsername);
            Controls.Add(tbPassword);
            Controls.Add(tbUrl);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox tbUrl;
        private TextBox tbPassword;
        private TextBox tbUsername;
        private Button btConnect;
        private RichTextBox rtbContent;
    }
}
