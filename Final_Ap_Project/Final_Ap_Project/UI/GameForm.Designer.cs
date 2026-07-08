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
            lblScore = new Label();
            lblWave = new Label();
            picHP1 = new PictureBox();
            picHP2 = new PictureBox();
            picHP3 = new PictureBox();
            picHP4 = new PictureBox();
            picHP5 = new PictureBox();
            lblCoins = new Label();
            pnlLU_HUD = new Panel();
            pnlCU_HUD = new Panel();
            pnlRL_HUD = new Panel();
            ((System.ComponentModel.ISupportInitialize)picHP1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picHP2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picHP3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picHP4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picHP5).BeginInit();
            pnlLU_HUD.SuspendLayout();
            pnlCU_HUD.SuspendLayout();
            pnlRL_HUD.SuspendLayout();
            SuspendLayout();
            // 
            // lblScore
            // 
            lblScore.AutoSize = true;
            lblScore.Font = new Font("SWMono", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblScore.ForeColor = Color.FromArgb(1, 171, 227);
            lblScore.Location = new Point(129, 33);
            lblScore.Name = "lblScore";
            lblScore.Size = new Size(28, 27);
            lblScore.TabIndex = 1;
            lblScore.Text = "0";
            // 
            // lblWave
            // 
            lblWave.AutoSize = true;
            lblWave.Font = new Font("SWMono", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblWave.ForeColor = Color.FromArgb(1, 171, 227);
            lblWave.Location = new Point(217, 33);
            lblWave.Name = "lblWave";
            lblWave.Size = new Size(28, 27);
            lblWave.TabIndex = 1;
            lblWave.Text = "1";
            // 
            // picHP1
            // 
            picHP1.Image = Properties.Resources.HP2;
            picHP1.Location = new Point(30, 29);
            picHP1.Name = "picHP1";
            picHP1.Size = new Size(33, 32);
            picHP1.SizeMode = PictureBoxSizeMode.Zoom;
            picHP1.TabIndex = 0;
            picHP1.TabStop = false;
            // 
            // picHP2
            // 
            picHP2.Image = Properties.Resources.HP2;
            picHP2.Location = new Point(70, 29);
            picHP2.Name = "picHP2";
            picHP2.Size = new Size(31, 32);
            picHP2.SizeMode = PictureBoxSizeMode.Zoom;
            picHP2.TabIndex = 0;
            picHP2.TabStop = false;
            // 
            // picHP3
            // 
            picHP3.Image = Properties.Resources.HP2;
            picHP3.Location = new Point(108, 29);
            picHP3.Name = "picHP3";
            picHP3.Size = new Size(31, 32);
            picHP3.SizeMode = PictureBoxSizeMode.Zoom;
            picHP3.TabIndex = 0;
            picHP3.TabStop = false;
            // 
            // picHP4
            // 
            picHP4.Image = Properties.Resources.HP2;
            picHP4.Location = new Point(146, 29);
            picHP4.Name = "picHP4";
            picHP4.Size = new Size(31, 32);
            picHP4.SizeMode = PictureBoxSizeMode.Zoom;
            picHP4.TabIndex = 0;
            picHP4.TabStop = false;
            // 
            // picHP5
            // 
            picHP5.Image = Properties.Resources.HP2;
            picHP5.Location = new Point(185, 29);
            picHP5.Name = "picHP5";
            picHP5.Size = new Size(31, 32);
            picHP5.SizeMode = PictureBoxSizeMode.Zoom;
            picHP5.TabIndex = 0;
            picHP5.TabStop = false;
            // 
            // lblCoins
            // 
            lblCoins.AutoSize = true;
            lblCoins.Font = new Font("SWMono", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCoins.ForeColor = Color.FromArgb(222, 148, 24);
            lblCoins.Location = new Point(79, 33);
            lblCoins.Name = "lblCoins";
            lblCoins.Size = new Size(28, 27);
            lblCoins.TabIndex = 1;
            lblCoins.Text = "0";
            // 
            // pnlLU_HUD
            // 
            pnlLU_HUD.BackgroundImage = Properties.Resources.LeftUp_HUD;
            pnlLU_HUD.BackgroundImageLayout = ImageLayout.Stretch;
            pnlLU_HUD.Controls.Add(picHP1);
            pnlLU_HUD.Controls.Add(picHP2);
            pnlLU_HUD.Controls.Add(picHP5);
            pnlLU_HUD.Controls.Add(picHP4);
            pnlLU_HUD.Controls.Add(picHP3);
            pnlLU_HUD.Location = new Point(-4, 0);
            pnlLU_HUD.Name = "pnlLU_HUD";
            pnlLU_HUD.Size = new Size(250, 85);
            pnlLU_HUD.TabIndex = 2;
            // 
            // pnlCU_HUD
            // 
            pnlCU_HUD.BackgroundImage = Properties.Resources.CenterUp_HUD;
            pnlCU_HUD.BackgroundImageLayout = ImageLayout.Stretch;
            pnlCU_HUD.Controls.Add(lblScore);
            pnlCU_HUD.Location = new Point(283, 0);
            pnlCU_HUD.Name = "pnlCU_HUD";
            pnlCU_HUD.Size = new Size(290, 85);
            pnlCU_HUD.TabIndex = 2;
            // 
            // pnlRL_HUD
            // 
            pnlRL_HUD.BackgroundImage = Properties.Resources.RirhtUp_HUD;
            pnlRL_HUD.BackgroundImageLayout = ImageLayout.Stretch;
            pnlRL_HUD.Controls.Add(lblCoins);
            pnlRL_HUD.Controls.Add(lblWave);
            pnlRL_HUD.Location = new Point(581, 0);
            pnlRL_HUD.Name = "pnlRL_HUD";
            pnlRL_HUD.Size = new Size(302, 85);
            pnlRL_HUD.TabIndex = 2;
            // 
            // GameForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(5, 7, 15);
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(884, 561);
            Controls.Add(pnlRL_HUD);
            Controls.Add(pnlCU_HUD);
            Controls.Add(pnlLU_HUD);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            KeyPreview = true;
            MaximizeBox = false;
            Name = "GameForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "GameForm";
            FormClosing += GameForm_FormClosing;
            KeyDown += GameForm_KeyDown;
            KeyUp += GameForm_KeyUp;
            ((System.ComponentModel.ISupportInitialize)picHP1).EndInit();
            ((System.ComponentModel.ISupportInitialize)picHP2).EndInit();
            ((System.ComponentModel.ISupportInitialize)picHP3).EndInit();
            ((System.ComponentModel.ISupportInitialize)picHP4).EndInit();
            ((System.ComponentModel.ISupportInitialize)picHP5).EndInit();
            pnlLU_HUD.ResumeLayout(false);
            pnlCU_HUD.ResumeLayout(false);
            pnlCU_HUD.PerformLayout();
            pnlRL_HUD.ResumeLayout(false);
            pnlRL_HUD.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Label lblScore;
        private Label lblWave;
        private PictureBox picHP1;
        private PictureBox picHP2;
        private PictureBox picHP3;
        private PictureBox picHP4;
        private PictureBox picHP5;
        private Label lblCoins;
        private Panel pnlLU_HUD;
        private Panel pnlCU_HUD;
        private Panel pnlRL_HUD;
    }
}