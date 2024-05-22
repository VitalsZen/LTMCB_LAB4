namespace Bai04
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.ListBox movieListBox;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            progressBar = new ProgressBar();
            movieListBox = new ListBox();
            SuspendLayout();
            // 
            // progressBar
            // 
            //progressBar.Location = new Point(12, 12);
            //progressBar.Name = "progressBar";
            //progressBar.Size = new Size(776, 23);
            //progressBar.TabIndex = 0;
            // 
            // movieListBox
            // 
            //movieListBox.FormattingEnabled = true;
            //movieListBox.Location = new Point(12, 41);
            //movieListBox.Name = "movieListBox";
            //movieListBox.Size = new Size(776, 384);
            //movieListBox.TabIndex = 1;
            //movieListBox.DoubleClick += movieListBox_DoubleClick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1440, 800);
            //Controls.Add(movieListBox);
            //Controls.Add(progressBar);
            Name = "Form1";
            Text = "Phim Đang Chiếu";
            Load += Form1_Load;
            ResumeLayout(false);
        }

        #endregion
    }
}
