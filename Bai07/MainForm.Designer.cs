namespace Bai07
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            btnAddFood = new Button();
            btnRandomFood = new Button();
            listBoxFood = new ListBox();
            btnUserCreatedFood = new Button();
            btnAllFood = new Button();
            btnNext = new Button();
            btnPrevious = new Button();
            btnDeleteFood = new Button();
            SuspendLayout();
            // 
            // btnAddFood
            // 
            btnAddFood.Location = new Point(16, 18);
            btnAddFood.Margin = new Padding(4, 5, 4, 5);
            btnAddFood.Name = "btnAddFood";
            btnAddFood.Size = new Size(133, 35);
            btnAddFood.TabIndex = 0;
            btnAddFood.Text = "Add Food";
            btnAddFood.UseVisualStyleBackColor = true;
            btnAddFood.Click += btnAddFood_Click;
            // 
            // btnRandomFood
            // 
            btnRandomFood.Location = new Point(16, 108);
            btnRandomFood.Margin = new Padding(4, 5, 4, 5);
            btnRandomFood.Name = "btnRandomFood";
            btnRandomFood.Size = new Size(133, 35);
            btnRandomFood.TabIndex = 1;
            btnRandomFood.Text = "Random Food";
            btnRandomFood.UseVisualStyleBackColor = true;
            btnRandomFood.Click += btnRandomFood_Click;
            // 
            // listBoxFood
            // 
            listBoxFood.FormattingEnabled = true;
            listBoxFood.Location = new Point(173, 18);
            listBoxFood.Margin = new Padding(4, 5, 4, 5);
            listBoxFood.Name = "listBoxFood";
            listBoxFood.ScrollAlwaysVisible = true;
            listBoxFood.Size = new Size(590, 424);
            listBoxFood.TabIndex = 2;
            // 
            // btnUserCreatedFood
            // 
            btnUserCreatedFood.Location = new Point(16, 218);
            btnUserCreatedFood.Margin = new Padding(4, 5, 4, 5);
            btnUserCreatedFood.Name = "btnUserCreatedFood";
            btnUserCreatedFood.Size = new Size(133, 35);
            btnUserCreatedFood.TabIndex = 3;
            btnUserCreatedFood.Text = "My Created Food";
            btnUserCreatedFood.UseVisualStyleBackColor = true;
            btnUserCreatedFood.Click += btnUserCreatedFood_Click;
            // 
            // btnAllFood
            // 
            btnAllFood.Location = new Point(16, 263);
            btnAllFood.Margin = new Padding(4, 5, 4, 5);
            btnAllFood.Name = "btnAllFood";
            btnAllFood.Size = new Size(133, 35);
            btnAllFood.TabIndex = 4;
            btnAllFood.Text = "All Food";
            btnAllFood.UseVisualStyleBackColor = true;
            btnAllFood.Click += btnAllFood_Click;
            // 
            // btnNext
            // 
            btnNext.Location = new Point(669, 467);
            btnNext.Margin = new Padding(4, 5, 4, 5);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(94, 35);
            btnNext.TabIndex = 5;
            btnNext.Text = "Next";
            btnNext.UseVisualStyleBackColor = true;
            btnNext.Click += btnNext_Click;
            // 
            // btnPrevious
            // 
            btnPrevious.Location = new Point(537, 467);
            btnPrevious.Margin = new Padding(4, 5, 4, 5);
            btnPrevious.Name = "btnPrevious";
            btnPrevious.Size = new Size(91, 35);
            btnPrevious.TabIndex = 6;
            btnPrevious.Text = "Previous";
            btnPrevious.UseVisualStyleBackColor = true;
            btnPrevious.Click += btnPrevious_Click;
            // 
            // btnDeleteFood
            // 
            btnDeleteFood.Location = new Point(16, 63);
            btnDeleteFood.Margin = new Padding(4, 5, 4, 5);
            btnDeleteFood.Name = "btnDeleteFood";
            btnDeleteFood.Size = new Size(133, 35);
            btnDeleteFood.TabIndex = 7;
            btnDeleteFood.Text = "Delete Food";
            btnDeleteFood.UseVisualStyleBackColor = true;
            btnDeleteFood.Click += btnDeleteFood_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(776, 516);
            Controls.Add(btnDeleteFood);
            Controls.Add(btnNext);
            Controls.Add(btnPrevious);
            Controls.Add(btnUserCreatedFood);
            Controls.Add(btnAllFood);
            Controls.Add(listBoxFood);
            Controls.Add(btnRandomFood);
            Controls.Add(btnAddFood);
            Margin = new Padding(4, 5, 4, 5);
            Name = "MainForm";
            Text = "Hôm nay ăn gì?";
            ResumeLayout(false);
        }

        private System.Windows.Forms.Button btnAddFood;
        private System.Windows.Forms.Button btnRandomFood;
        private System.Windows.Forms.ListBox listBoxFood;
        private Button btnUserCreatedFood;
        private Button btnAllFood;
        private Button btnNext;
        private Button btnPrevious;
        private Button btnDeleteFood;
    }
}
