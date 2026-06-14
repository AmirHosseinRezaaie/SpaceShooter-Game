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
            lblTitle = new Label();
            lblCoins = new Label();
            flpItems = new FlowLayoutPanel();
            btnBack = new Label();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.BackColor = Color.Transparent;
            lblTitle.Font = new Font("Segoe UI Black", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(200, 30);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(500, 60);
            lblTitle.TabIndex = 6;
            lblTitle.Text = "Shop";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblCoins
            // 
            lblCoins.AutoSize = true;
            lblCoins.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCoins.ForeColor = SystemColors.ControlLight;
            lblCoins.Location = new Point(100, 54);
            lblCoins.Name = "lblCoins";
            lblCoins.Size = new Size(80, 25);
            lblCoins.TabIndex = 7;
            lblCoins.Text = "Coins: 0";
            // 
            // flpItems
            // 
            flpItems.AutoScroll = true;
            flpItems.BackColor = Color.Transparent;
            flpItems.Location = new Point(100, 93);
            flpItems.Name = "flpItems";
            flpItems.Size = new Size(700, 400);
            flpItems.TabIndex = 8;
            // 
            // btnBack
            // 
            btnBack.BackColor = Color.FromArgb(10, 20, 30);
            btnBack.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnBack.ForeColor = Color.White;
            btnBack.Location = new Point(380, 505);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(140, 45);
            btnBack.TabIndex = 7;
            btnBack.Text = "BACK";
            btnBack.TextAlign = ContentAlignment.MiddleCenter;
            btnBack.Click += btnBack_Click;
            // 
            // ShopForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(5, 7, 15);
            ClientSize = new Size(884, 561);
            Controls.Add(flpItems);
            Controls.Add(btnBack);
            Controls.Add(lblCoins);
            Controls.Add(lblTitle);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            KeyPreview = true;
            MaximizeBox = false;
            Name = "ShopForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ShopForm";
            KeyDown += ShopForm_KeyDown;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Label lblCoins;
        private FlowLayoutPanel flpItems;
        private Label btnBack;
    }
}