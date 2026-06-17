namespace Final_Ap_Project.UI
{
    partial class GameForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameForm));
            pnlHUD = new Panel();
            picHP = new PictureBox();
            lblHP = new Label();
            picScore = new PictureBox();
            lblScore = new Label();
            picCoins = new PictureBox();
            lblCoins = new Label();
            picWave = new PictureBox();
            lblWave = new Label();
            pnlHUD.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picHP).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picScore).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picCoins).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picWave).BeginInit();
            SuspendLayout();
            // 
            // pnlHUD
            // 
            pnlHUD.BackColor = Color.FromArgb(20, 20, 20);
            pnlHUD.Controls.Add(lblWave);
            pnlHUD.Controls.Add(lblCoins);
            pnlHUD.Controls.Add(picWave);
            pnlHUD.Controls.Add(picCoins);
            pnlHUD.Controls.Add(lblScore);
            pnlHUD.Controls.Add(picScore);
            pnlHUD.Controls.Add(lblHP);
            pnlHUD.Controls.Add(picHP);
            pnlHUD.Dock = DockStyle.Top;
            pnlHUD.Location = new Point(0, 0);
            pnlHUD.Name = "pnlHUD";
            pnlHUD.Size = new Size(884, 60);
            pnlHUD.TabIndex = 0;
            // 
            // picHP
            // 
            picHP.Image = Properties.Resources.HP;
            picHP.Location = new Point(10, 14);
            picHP.Name = "picHP";
            picHP.Size = new Size(32, 32);
            picHP.SizeMode = PictureBoxSizeMode.Zoom;
            picHP.TabIndex = 0;
            picHP.TabStop = false;
            // 
            // lblHP
            // 
            lblHP.AutoSize = true;
            lblHP.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblHP.ForeColor = Color.Red;
            lblHP.Location = new Point(50, 15);
            lblHP.Name = "lblHP";
            lblHP.Size = new Size(25, 30);
            lblHP.TabIndex = 1;
            lblHP.Text = "3";
            // 
            // picScore
            // 
            picScore.Image = Properties.Resources.Score;
            picScore.Location = new Point(170, 14);
            picScore.Name = "picScore";
            picScore.Size = new Size(32, 32);
            picScore.SizeMode = PictureBoxSizeMode.Zoom;
            picScore.TabIndex = 0;
            picScore.TabStop = false;
            // 
            // lblScore
            // 
            lblScore.AutoSize = true;
            lblScore.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblScore.ForeColor = Color.FromArgb(0, 192, 192);
            lblScore.Location = new Point(210, 15);
            lblScore.Name = "lblScore";
            lblScore.Size = new Size(25, 30);
            lblScore.TabIndex = 1;
            lblScore.Text = "0";
            lblScore.Click += lblScore_Click;
            // 
            // picCoins
            // 
            picCoins.Image = Properties.Resources.PlayerCoin;
            picCoins.Location = new Point(380, 14);
            picCoins.Name = "picCoins";
            picCoins.Size = new Size(32, 32);
            picCoins.SizeMode = PictureBoxSizeMode.Zoom;
            picCoins.TabIndex = 0;
            picCoins.TabStop = false;
            // 
            // lblCoins
            // 
            lblCoins.AutoSize = true;
            lblCoins.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCoins.ForeColor = Color.FromArgb(192, 192, 0);
            lblCoins.Location = new Point(420, 15);
            lblCoins.Name = "lblCoins";
            lblCoins.Size = new Size(25, 30);
            lblCoins.TabIndex = 1;
            lblCoins.Text = "0";
            lblCoins.Click += lblScore_Click;
            // 
            // picWave
            // 
            picWave.Image = Properties.Resources.Wave;
            picWave.Location = new Point(620, 14);
            picWave.Name = "picWave";
            picWave.Size = new Size(32, 32);
            picWave.SizeMode = PictureBoxSizeMode.Zoom;
            picWave.TabIndex = 0;
            picWave.TabStop = false;
            // 
            // lblWave
            // 
            lblWave.AutoSize = true;
            lblWave.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblWave.ForeColor = Color.DeepSkyBlue;
            lblWave.Location = new Point(660, 15);
            lblWave.Name = "lblWave";
            lblWave.Size = new Size(25, 30);
            lblWave.TabIndex = 1;
            lblWave.Text = "1";
            lblWave.Click += lblScore_Click;
            // 
            // GameForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(5, 7, 15);
            ClientSize = new Size(884, 561);
            Controls.Add(pnlHUD);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            KeyPreview = true;
            MaximizeBox = false;
            Name = "GameForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "GameForm";
            KeyDown += GameForm_KeyDown;
            KeyUp += GameForm_KeyUp;
            pnlHUD.ResumeLayout(false);
            pnlHUD.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picHP).EndInit();
            ((System.ComponentModel.ISupportInitialize)picScore).EndInit();
            ((System.ComponentModel.ISupportInitialize)picCoins).EndInit();
            ((System.ComponentModel.ISupportInitialize)picWave).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlHUD;
        private PictureBox picHP;
        private Label lblHP;
        private Label lblScore;
        private PictureBox picScore;
        private Label lblCoins;
        private PictureBox picCoins;
        private Label lblWave;
        private PictureBox picWave;
    }
}