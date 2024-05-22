namespace Bai03
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            webView21 = new Microsoft.Web.WebView2.WinForms.WebView2();
            tbConnectUrl = new TextBox();
            btConnect = new Button();
            btDownloadHTMLContent = new Button();
            btDownloadResource = new Button();
            ((System.ComponentModel.ISupportInitialize)webView21).BeginInit();
            SuspendLayout();
            // 
            // webView21
            // 
            webView21.AllowExternalDrop = true;
            webView21.CreationProperties = null;
            webView21.DefaultBackgroundColor = Color.White;
            webView21.Location = new Point(-1, 85);
            webView21.Name = "webView21";
            webView21.Size = new Size(1086, 451);
            webView21.Source = new Uri("https://www.uit.edu.vn/", UriKind.Absolute);
            webView21.TabIndex = 0;
            webView21.ZoomFactor = 1D;
            // 
            // tbConnectUrl
            // 
            tbConnectUrl.BorderStyle = BorderStyle.FixedSingle;
            tbConnectUrl.Location = new Point(12, 8);
            tbConnectUrl.Name = "tbConnectUrl";
            tbConnectUrl.Size = new Size(907, 27);
            tbConnectUrl.TabIndex = 1;
            // 
            // btConnect
            // 
            btConnect.Location = new Point(932, 7);
            btConnect.Name = "btConnect";
            btConnect.Size = new Size(153, 29);
            btConnect.TabIndex = 2;
            btConnect.Text = "Go";
            btConnect.UseVisualStyleBackColor = true;
            btConnect.Click += btConnect_Click;
            // 
            // btDownloadHTMLContent
            // 
            btDownloadHTMLContent.Location = new Point(711, 41);
            btDownloadHTMLContent.Name = "btDownloadHTMLContent";
            btDownloadHTMLContent.Size = new Size(180, 29);
            btDownloadHTMLContent.TabIndex = 3;
            btDownloadHTMLContent.Text = "Download HTML FIle";
            btDownloadHTMLContent.UseVisualStyleBackColor = true;
            btDownloadHTMLContent.Click += btDownloadHTMLContent_Click;
            // 
            // btDownloadResource
            // 
            btDownloadResource.Location = new Point(897, 41);
            btDownloadResource.Name = "btDownloadResource";
            btDownloadResource.Size = new Size(180, 29);
            btDownloadResource.TabIndex = 4;
            btDownloadResource.Text = "Download Resource";
            btDownloadResource.UseVisualStyleBackColor = true;
            btDownloadResource.Click += btDownloadResource_Click;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1089, 532);
            Controls.Add(btDownloadResource);
            Controls.Add(btDownloadHTMLContent);
            Controls.Add(btConnect);
            Controls.Add(tbConnectUrl);
            Controls.Add(webView21);
            Name = "Form2";
            Text = "Form2";
            ((System.ComponentModel.ISupportInitialize)webView21).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Microsoft.Web.WebView2.WinForms.WebView2 webView21;
        private TextBox tbConnectUrl;
        private Button btConnect;
        private Button btDownloadHTMLContent;
        private Button btDownloadResource;
    }
}