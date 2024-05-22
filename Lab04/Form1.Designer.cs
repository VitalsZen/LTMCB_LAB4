namespace Lab04
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
            tbGetUrl = new TextBox();
            btGet = new Button();
            rtbGetContent = new RichTextBox();
            SuspendLayout();
            // 
            // tbGetUrl
            // 
            tbGetUrl.BorderStyle = BorderStyle.FixedSingle;
            tbGetUrl.Location = new Point(23, 23);
            tbGetUrl.Name = "tbGetUrl";
            tbGetUrl.Size = new Size(501, 27);
            tbGetUrl.TabIndex = 0;
            // 
            // btGet
            // 
            btGet.Location = new Point(544, 20);
            btGet.Name = "btGet";
            btGet.Size = new Size(140, 30);
            btGet.TabIndex = 1;
            btGet.Text = "Get";
            btGet.UseVisualStyleBackColor = true;
            btGet.Click += btGet_Click;
            // 
            // rtbGetContent
            // 
            rtbGetContent.BorderStyle = BorderStyle.FixedSingle;
            rtbGetContent.Location = new Point(26, 70);
            rtbGetContent.Name = "rtbGetContent";
            rtbGetContent.Size = new Size(658, 335);
            rtbGetContent.TabIndex = 2;
            rtbGetContent.Text = "";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(699, 435);
            Controls.Add(rtbGetContent);
            Controls.Add(btGet);
            Controls.Add(tbGetUrl);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox tbGetUrl;
        private Button btGet;
        private RichTextBox rtbGetContent;
    }
}
