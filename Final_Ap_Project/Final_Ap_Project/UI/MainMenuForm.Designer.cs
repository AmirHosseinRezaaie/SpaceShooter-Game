namespace Final_Ap_Project.UI
{
    partial class MainMenuForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMenuForm));
            btnPlay = new Button();
            btnOptions = new Button();
            btnShop = new Button();
            btnAbout = new Button();
            btnQuit = new Button();
            lblTitle = new Label();
            SuspendLayout();
            // 
            // btnPlay
            // 
            btnPlay.BackColor = Color.Black;
            btnPlay.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnPlay.ForeColor = Color.White;
            btnPlay.Location = new Point(350, 120);
            btnPlay.Name = "btnPlay";
            btnPlay.Size = new Size(200, 50);
            btnPlay.TabIndex = 0;
            btnPlay.Text = "Play";
            btnPlay.UseVisualStyleBackColor = false;
            btnPlay.Click += btnPlay_Click;
            btnPlay.MouseLeave += btnPlay_MouseLeave;
            btnPlay.MouseHover += btnPlay_MouseHover;
            // 
            // btnOptions
            // 
            btnOptions.BackColor = Color.Black;
            btnOptions.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnOptions.ForeColor = Color.White;
            btnOptions.Location = new Point(350, 260);
            btnOptions.Name = "btnOptions";
            btnOptions.Size = new Size(200, 50);
            btnOptions.TabIndex = 1;
            btnOptions.Text = "Options";
            btnOptions.UseVisualStyleBackColor = false;
            btnOptions.Click += btnOptions_Click;
            btnOptions.MouseLeave += btnOptions_MouseLeave;
            btnOptions.MouseHover += btnOptions_MouseHover;
            // 
            // btnShop
            // 
            btnShop.BackColor = Color.Black;
            btnShop.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnShop.ForeColor = Color.White;
            btnShop.Location = new Point(350, 190);
            btnShop.Name = "btnShop";
            btnShop.Size = new Size(200, 50);
            btnShop.TabIndex = 2;
            btnShop.Text = "Shop";
            btnShop.UseVisualStyleBackColor = false;
            btnShop.Click += btnShop_Click;
            btnShop.MouseLeave += btnShop_MouseLeave;
            btnShop.MouseHover += btnShop_MouseHover;
            // 
            // btnAbout
            // 
            btnAbout.BackColor = Color.Black;
            btnAbout.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAbout.ForeColor = Color.White;
            btnAbout.Location = new Point(350, 330);
            btnAbout.Name = "btnAbout";
            btnAbout.Size = new Size(200, 50);
            btnAbout.TabIndex = 3;
            btnAbout.Text = "About";
            btnAbout.UseVisualStyleBackColor = false;
            btnAbout.Click += btnAbout_Click;
            btnAbout.MouseLeave += btnAbout_MouseLeave;
            btnAbout.MouseHover += btnAbout_MouseHover;
            // 
            // btnQuit
            // 
            btnQuit.BackColor = Color.Black;
            btnQuit.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnQuit.ForeColor = Color.White;
            btnQuit.Location = new Point(350, 400);
            btnQuit.Name = "btnQuit";
            btnQuit.Size = new Size(200, 50);
            btnQuit.TabIndex = 4;
            btnQuit.Text = "Quit";
            btnQuit.UseVisualStyleBackColor = false;
            btnQuit.Click += btnQuit_Click;
            btnQuit.MouseLeave += btnQuit_MouseLeave;
            btnQuit.MouseHover += btnQuit_MouseHover;
            // 
            // lblTitle
            // 
            lblTitle.BackColor = Color.Transparent;
            lblTitle.Font = new Font("Segoe UI Black", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(200, 30);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(500, 60);
            lblTitle.TabIndex = 5;
            lblTitle.Text = "SPACE SHOOTER";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // MainMenuForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(5, 7, 15);
            ClientSize = new Size(884, 561);
            Controls.Add(lblTitle);
            Controls.Add(btnQuit);
            Controls.Add(btnAbout);
            Controls.Add(btnShop);
            Controls.Add(btnOptions);
            Controls.Add(btnPlay);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            KeyPreview = true;
            MaximizeBox = false;
            Name = "MainMenuForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Space Shooter";
            KeyDown += MainMenuForm_KeyDown;
            ResumeLayout(false);
        }

        #endregion

        private Button btnPlay;
        private Button btnOptions;
        private Button btnShop;
        private Button btnAbout;
        private Button btnQuit;
        private Label lblTitle;
    }
}