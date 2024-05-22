namespace Bai2
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
            rtbGetContent = new RichTextBox();
            btDownload = new Button();
            tbGetUrl = new TextBox();
            tbDownloadUrl = new TextBox();
            SuspendLayout();
            // 
            // rtbGetContent
            // 
            rtbGetContent.BorderStyle = BorderStyle.FixedSingle;
            rtbGetContent.Location = new Point(29, 123);
            rtbGetContent.Name = "rtbGetContent";
            rtbGetContent.Size = new Size(658, 303);
            rtbGetContent.TabIndex = 5;
            rtbGetContent.Text = "";
            // 
            // btDownload
            // 
            btDownload.Location = new Point(547, 12);
            btDownload.Name = "btDownload";
            btDownload.Size = new Size(140, 77);
            btDownload.TabIndex = 4;
            btDownload.Text = "Download";
            btDownload.UseVisualStyleBackColor = true;
            btDownload.Click += btDownload_Click;
            // 
            // tbGetUrl
            // 
            tbGetUrl.BorderStyle = BorderStyle.FixedSingle;
            tbGetUrl.Location = new Point(29, 12);
            tbGetUrl.Name = "tbGetUrl";
            tbGetUrl.Size = new Size(501, 27);
            tbGetUrl.TabIndex = 3;
            // 
            // tbDownloadUrl
            // 
            tbDownloadUrl.BorderStyle = BorderStyle.FixedSingle;
            tbDownloadUrl.Location = new Point(29, 62);
            tbDownloadUrl.Name = "tbDownloadUrl";
            tbDownloadUrl.Size = new Size(501, 27);
            tbDownloadUrl.TabIndex = 6;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(704, 450);
            Controls.Add(tbDownloadUrl);
            Controls.Add(rtbGetContent);
            Controls.Add(btDownload);
            Controls.Add(tbGetUrl);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RichTextBox rtbGetContent;
        private Button btDownload;
        private TextBox tbGetUrl;
        private TextBox tbDownloadUrl;
    }
}
