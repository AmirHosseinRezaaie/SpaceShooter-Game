namespace Final_Ap_Project.UI
{
    partial class ShopForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShopForm));
            lblTitle = new Label();
            lblCoins = new Label();
            flpItems = new FlowLayoutPanel();
            panel1 = new Panel();
            label1 = new Label();
            button1 = new Button();
            label2 = new Label();
            panel2 = new Panel();
            label3 = new Label();
            button2 = new Button();
            label4 = new Label();
            panel3 = new Panel();
            label5 = new Label();
            button3 = new Button();
            label6 = new Label();
            pictureBox3 = new PictureBox();
            btnBack = new Label();
            pictureBox4 = new PictureBox();
            pictureBox1 = new PictureBox();
            flpItems.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.BackColor = Color.Transparent;
            lblTitle.Font = new Font("Segoe UI Black", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(286, 50);
            lblTitle.Margin = new Padding(4, 0, 4, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(714, 100);
            lblTitle.TabIndex = 6;
            lblTitle.Text = "Shop";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblCoins
            // 
            lblCoins.AutoSize = true;
            lblCoins.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCoins.ForeColor = SystemColors.ControlLight;
            lblCoins.Location = new Point(143, 90);
            lblCoins.Margin = new Padding(4, 0, 4, 0);
            lblCoins.Name = "lblCoins";
            lblCoins.Size = new Size(121, 40);
            lblCoins.TabIndex = 7;
            lblCoins.Text = "Coins: 0";
            // 
            // flpItems
            // 
            flpItems.AutoScroll = true;
            flpItems.BackColor = Color.Transparent;
            flpItems.Controls.Add(panel1);
            flpItems.Controls.Add(panel2);
            flpItems.Controls.Add(panel3);
            flpItems.Location = new Point(143, 155);
            flpItems.Margin = new Padding(4, 5, 4, 5);
            flpItems.Name = "flpItems";
            flpItems.Size = new Size(1000, 667);
            flpItems.TabIndex = 8;
            // 
            // panel1
            // 
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(label2);
            panel1.Location = new Point(50, 50);
            panel1.Margin = new Padding(50, 50, 3, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(234, 278);
            panel1.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Black", 18F, FontStyle.Bold);
            label1.ForeColor = SystemColors.ControlLight;
            label1.Location = new Point(51, 146);
            label1.MaximumSize = new Size(300, 100);
            label1.Name = "label1";
            label1.Size = new Size(126, 48);
            label1.TabIndex = 1;
            label1.Text = "+1 HP";
            // 
            // button1
            // 
            button1.AccessibleName = "btnBuyHP";
            button1.AutoSize = true;
            button1.BackColor = Color.Transparent;
            button1.Font = new Font("Segoe UI Black", 10F, FontStyle.Bold);
            button1.Location = new Point(57, 231);
            button1.Name = "button1";
            button1.Size = new Size(112, 38);
            button1.TabIndex = 2;
            button1.Text = "Buy";
            button1.TextAlign = ContentAlignment.TopCenter;
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Black", 15F, FontStyle.Bold);
            label2.ForeColor = SystemColors.ControlLight;
            label2.Location = new Point(51, 187);
            label2.MaximumSize = new Size(300, 100);
            label2.Name = "label2";
            label2.Size = new Size(133, 41);
            label2.TabIndex = 2;
            label2.Text = "cost: 50";
            // 
            // panel2
            // 
            panel2.Controls.Add(pictureBox4);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(button2);
            panel2.Controls.Add(label4);
            panel2.Location = new Point(387, 50);
            panel2.Margin = new Padding(100, 50, 3, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(234, 278);
            panel2.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Black", 17F, FontStyle.Bold);
            label3.ForeColor = SystemColors.ControlLight;
            label3.Location = new Point(4, 146);
            label3.MaximumSize = new Size(300, 100);
            label3.Name = "label3";
            label3.Size = new Size(227, 46);
            label3.TabIndex = 1;
            label3.Text = "Speed Boost";
            // 
            // button2
            // 
            button2.AccessibleName = "btnBuySpeed";
            button2.AutoSize = true;
            button2.BackColor = Color.Transparent;
            button2.Font = new Font("Segoe UI Black", 10F, FontStyle.Bold);
            button2.Location = new Point(57, 231);
            button2.Name = "button2";
            button2.Size = new Size(112, 38);
            button2.TabIndex = 2;
            button2.Text = "Buy";
            button2.TextAlign = ContentAlignment.TopCenter;
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Black", 15F, FontStyle.Bold);
            label4.ForeColor = SystemColors.ControlLight;
            label4.Location = new Point(51, 187);
            label4.MaximumSize = new Size(300, 100);
            label4.Name = "label4";
            label4.Size = new Size(133, 41);
            label4.TabIndex = 2;
            label4.Text = "cost: 75";
            // 
            // panel3
            // 
            panel3.Controls.Add(label5);
            panel3.Controls.Add(button3);
            panel3.Controls.Add(label6);
            panel3.Controls.Add(pictureBox3);
            panel3.Location = new Point(724, 50);
            panel3.Margin = new Padding(100, 50, 3, 3);
            panel3.Name = "panel3";
            panel3.Size = new Size(234, 278);
            panel3.TabIndex = 3;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Black", 18F, FontStyle.Bold);
            label5.ForeColor = SystemColors.ControlLight;
            label5.Location = new Point(16, 146);
            label5.MaximumSize = new Size(300, 100);
            label5.Name = "label5";
            label5.Size = new Size(198, 48);
            label5.TabIndex = 1;
            label5.Text = "Rapid Fire";
            // 
            // button3
            // 
            button3.AccessibleName = "btnBuyRapidFire";
            button3.AutoSize = true;
            button3.BackColor = Color.Transparent;
            button3.Font = new Font("Segoe UI Black", 10F, FontStyle.Bold);
            button3.Location = new Point(57, 231);
            button3.Name = "button3";
            button3.Size = new Size(112, 38);
            button3.TabIndex = 2;
            button3.Text = "Buy";
            button3.TextAlign = ContentAlignment.TopCenter;
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Black", 15F, FontStyle.Bold);
            label6.ForeColor = SystemColors.ControlLight;
            label6.Location = new Point(51, 187);
            label6.MaximumSize = new Size(300, 100);
            label6.Name = "label6";
            label6.Size = new Size(148, 41);
            label6.TabIndex = 2;
            label6.Text = "cost: 100";
            // 
            // pictureBox3
            // 
            pictureBox3.Image = Properties.Resources.Rapid_fire;
            pictureBox3.Location = new Point(42, -6);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(157, 157);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 0;
            pictureBox3.TabStop = false;
            // 
            // btnBack
            // 
            btnBack.BackColor = Color.FromArgb(10, 20, 30);
            btnBack.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnBack.ForeColor = Color.White;
            btnBack.Location = new Point(543, 842);
            btnBack.Margin = new Padding(4, 0, 4, 0);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(200, 75);
            btnBack.TabIndex = 7;
            btnBack.Text = "BACK";
            btnBack.TextAlign = ContentAlignment.MiddleCenter;
            btnBack.Click += btnBack_Click;
            // 
            // pictureBox4
            // 
            pictureBox4.Image = Properties.Resources.speed_boost;
            pictureBox4.Location = new Point(38, -6);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(157, 157);
            pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox4.TabIndex = 3;
            pictureBox4.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.Extra_Health;
            pictureBox1.Location = new Point(38, -6);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(157, 157);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            // 
            // ShopForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(5, 7, 15);
            ClientSize = new Size(1263, 935);
            Controls.Add(flpItems);
            Controls.Add(btnBack);
            Controls.Add(lblCoins);
            Controls.Add(lblTitle);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            KeyPreview = true;
            Margin = new Padding(4, 5, 4, 5);
            MaximizeBox = false;
            Name = "ShopForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ShopForm";
            Load += ShopForm_Load;
            KeyDown += ShopForm_KeyDown;
            flpItems.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Label lblCoins;
        private FlowLayoutPanel flpItems;
        private Label btnBack;
        private Panel panel1;
        private Label label1;
        private Button button1;
        private Label label2;
        private Panel panel2;
        private Label label3;
        private Button button2;
        private Label label4;
        private Panel panel3;
        private Label label5;
        private Button button3;
        private Label label6;
        private PictureBox pictureBox3;
        private PictureBox pictureBox1;
        private PictureBox pictureBox4;
    }
}