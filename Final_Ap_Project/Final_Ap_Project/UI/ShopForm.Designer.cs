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
            pictureBox1 = new PictureBox();
            label1 = new Label();
            button1 = new Button();
            label2 = new Label();
            panel2 = new Panel();
            pictureBox4 = new PictureBox();
            label3 = new Label();
            button2 = new Button();
            label4 = new Label();
            panel3 = new Panel();
            label5 = new Label();
            button3 = new Button();
            label6 = new Label();
            pictureBox3 = new PictureBox();
            panel6 = new Panel();
            button6 = new Button();
            button5 = new Button();
            pictureBox7 = new PictureBox();
            label13 = new Label();
            button7 = new Button();
            label14 = new Label();
            panel4 = new Panel();
            pictureBox2 = new PictureBox();
            label7 = new Label();
            button4 = new Button();
            label8 = new Label();
            btnBack = new Label();
            flpItems.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).BeginInit();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
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
            flpItems.Controls.Add(panel6);
            flpItems.Controls.Add(panel4);
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
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(39, -7);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(157, 157);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Black", 18F, FontStyle.Bold);
            label1.ForeColor = SystemColors.ControlLight;
            label1.Location = new Point(51, 147);
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
            button1.Location = new Point(57, 232);
            button1.Name = "button1";
            button1.Size = new Size(111, 63);
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
            // pictureBox4
            // 
            pictureBox4.Image = (Image)resources.GetObject("pictureBox4.Image");
            pictureBox4.Location = new Point(39, -7);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(157, 157);
            pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox4.TabIndex = 3;
            pictureBox4.TabStop = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Black", 17F, FontStyle.Bold);
            label3.ForeColor = SystemColors.ControlLight;
            label3.Location = new Point(4, 147);
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
            button2.Location = new Point(57, 232);
            button2.Name = "button2";
            button2.Size = new Size(111, 63);
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
            label5.Location = new Point(16, 147);
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
            button3.Location = new Point(57, 232);
            button3.Name = "button3";
            button3.Size = new Size(111, 63);
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
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(41, -7);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(157, 157);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 0;
            pictureBox3.TabStop = false;
            // 
            // panel6
            // 
            panel6.Controls.Add(button6);
            panel6.Controls.Add(button5);
            panel6.Controls.Add(pictureBox7);
            panel6.Controls.Add(label13);
            panel6.Controls.Add(button7);
            panel6.Controls.Add(label14);
            panel6.Location = new Point(150, 381);
            panel6.Margin = new Padding(150, 50, 3, 3);
            panel6.Name = "panel6";
            panel6.Size = new Size(234, 278);
            panel6.TabIndex = 6;
            // 
            // button6
            // 
            button6.AccessibleName = "btnPrevSkin";
            button6.AutoSize = true;
            button6.BackColor = Color.Transparent;
            button6.FlatAppearance.BorderSize = 0;
            button6.FlatAppearance.MouseDownBackColor = Color.FromArgb(30, 30, 30);
            button6.FlatAppearance.MouseOverBackColor = Color.Black;
            button6.FlatStyle = FlatStyle.Flat;
            button6.Font = new Font("Bauhaus 93", 18F, FontStyle.Bold);
            button6.ForeColor = SystemColors.Control;
            button6.Location = new Point(-7, 37);
            button6.Name = "button6";
            button6.Size = new Size(66, 83);
            button6.TabIndex = 6;
            button6.Text = "<";
            button6.TextAlign = ContentAlignment.TopCenter;
            button6.UseVisualStyleBackColor = false;
            button6.Click += button6_Click;
            // 
            // button5
            // 
            button5.AccessibleName = "btnNextSkin";
            button5.AutoSize = true;
            button5.BackColor = Color.Transparent;
            button5.FlatAppearance.BorderSize = 0;
            button5.FlatAppearance.MouseDownBackColor = Color.FromArgb(30, 30, 30);
            button5.FlatAppearance.MouseOverBackColor = Color.Black;
            button5.FlatStyle = FlatStyle.Flat;
            button5.Font = new Font("Bauhaus 93", 18F, FontStyle.Bold);
            button5.ForeColor = SystemColors.Control;
            button5.Location = new Point(197, 37);
            button5.Name = "button5";
            button5.Size = new Size(66, 83);
            button5.TabIndex = 5;
            button5.Text = ">";
            button5.TextAlign = ContentAlignment.TopCenter;
            button5.UseVisualStyleBackColor = false;
            button5.Click += button5_Click;
            // 
            // pictureBox7
            // 
            pictureBox7.AccessibleName = "picCarousel";
            pictureBox7.Image = Properties.Resources.PlayerSpaceshipّSize;
            pictureBox7.Location = new Point(26, -17);
            pictureBox7.Name = "pictureBox7";
            pictureBox7.Size = new Size(201, 168);
            pictureBox7.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox7.TabIndex = 4;
            pictureBox7.TabStop = false;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI Black", 18F, FontStyle.Bold);
            label13.ForeColor = SystemColors.ControlLight;
            label13.Location = new Point(60, 147);
            label13.MaximumSize = new Size(300, 100);
            label13.Name = "label13";
            label13.Size = new Size(113, 48);
            label13.TabIndex = 1;
            label13.Text = "Skins";
            // 
            // button7
            // 
            button7.AccessibleName = "btnCarouselAction";
            button7.AutoSize = true;
            button7.BackColor = Color.Transparent;
            button7.Font = new Font("Segoe UI Black", 10F, FontStyle.Bold);
            button7.Location = new Point(57, 232);
            button7.Name = "button7";
            button7.Size = new Size(111, 63);
            button7.TabIndex = 2;
            button7.Text = "Buy";
            button7.TextAlign = ContentAlignment.TopCenter;
            button7.UseVisualStyleBackColor = false;
            button7.Click += button7_Click;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Segoe UI Black", 15F, FontStyle.Bold);
            label14.ForeColor = SystemColors.ControlLight;
            label14.Location = new Point(41, 187);
            label14.MaximumSize = new Size(300, 100);
            label14.Name = "label14";
            label14.Size = new Size(148, 41);
            label14.TabIndex = 2;
            label14.Text = "cost: 100";
            // 
            // panel4
            // 
            panel4.Controls.Add(pictureBox2);
            panel4.Controls.Add(label7);
            panel4.Controls.Add(button4);
            panel4.Controls.Add(label8);
            panel4.Location = new Point(657, 381);
            panel4.Margin = new Padding(270, 50, 3, 3);
            panel4.Name = "panel4";
            panel4.Size = new Size(234, 278);
            panel4.TabIndex = 5;
            // 
            // pictureBox2
            // 
            pictureBox2.AccessibleName = "picUltimate";
            pictureBox2.Image = Properties.Resources.specialskinGIF;
            pictureBox2.Location = new Point(17, -7);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(193, 157);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 4;
            pictureBox2.TabStop = false;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI Black", 18F, FontStyle.Bold);
            label7.ForeColor = SystemColors.ControlLight;
            label7.Location = new Point(0, 147);
            label7.MaximumSize = new Size(300, 100);
            label7.Name = "label7";
            label7.Size = new Size(243, 48);
            label7.TabIndex = 1;
            label7.Text = "Special Skin!";
            // 
            // button4
            // 
            button4.AccessibleName = "btnUltimateAction";
            button4.AutoSize = true;
            button4.BackColor = Color.Transparent;
            button4.Font = new Font("Segoe UI Black", 10F, FontStyle.Bold);
            button4.Location = new Point(57, 232);
            button4.Name = "button4";
            button4.Size = new Size(111, 63);
            button4.TabIndex = 2;
            button4.Text = "Buy";
            button4.TextAlign = ContentAlignment.TopCenter;
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI Black", 15F, FontStyle.Bold);
            label8.ForeColor = SystemColors.ControlLight;
            label8.Location = new Point(39, 187);
            label8.MaximumSize = new Size(300, 100);
            label8.Name = "label8";
            label8.Size = new Size(151, 41);
            label8.TabIndex = 2;
            label8.Text = "cost: 500";
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
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).EndInit();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Label lblCoins;
        private FlowLayoutPanel flpItems;
        private Label btnBack;
        private Panel panel2;
        private Label label3;
        private Button button2;
        private Label label4;
        private Panel panel3;
        private Label label5;
        private Button button3;
        private Label label6;
        private PictureBox pictureBox3;
        private PictureBox pictureBox4;
        private Panel panel4;
        private PictureBox pictureBox2;
        private Label label7;
        private Button button4;
        private Label label8;
        private Panel panel1;
        private PictureBox pictureBox1;
        private Label label1;
        private Button button1;
        private Label label2;
        private Panel panel6;
        private PictureBox pictureBox7;
        private Label label13;
        private Button button7;
        private Label label14;
        private Button button5;
        private Button button6;
    }
}