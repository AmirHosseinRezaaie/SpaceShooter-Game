namespace Final_Ap_Project.UI
{
    partial class OptionsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OptionsForm));
            lblTitle = new Label();
            pnlAudio = new Panel();
            chkSFX = new CheckBox();
            chkMusic = new CheckBox();
            lblSFX = new Label();
            lblMusic = new Label();
            lblAudioSetting = new Label();
            panel1 = new Panel();
            tlpControl2 = new TableLayoutPanel();
            lblKey4 = new Label();
            lblKey5 = new Label();
            lblKey6 = new Label();
            lblAction4 = new Label();
            lblAction6 = new Label();
            lblAction5 = new Label();
            tlpControl1 = new TableLayoutPanel();
            lblKey1 = new Label();
            lblKey2 = new Label();
            lblAction1 = new Label();
            lblKey3 = new Label();
            lblAction2 = new Label();
            lblAction3 = new Label();
            lblControlGuide = new Label();
            btnBack = new Label();
            pnlAudio.SuspendLayout();
            panel1.SuspendLayout();
            tlpControl2.SuspendLayout();
            tlpControl1.SuspendLayout();
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
            lblTitle.TabIndex = 7;
            lblTitle.Text = "Options";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlAudio
            // 
            pnlAudio.BackColor = Color.FromArgb(20, 20, 30);
            pnlAudio.Controls.Add(chkSFX);
            pnlAudio.Controls.Add(chkMusic);
            pnlAudio.Controls.Add(lblSFX);
            pnlAudio.Controls.Add(lblMusic);
            pnlAudio.Controls.Add(lblAudioSetting);
            pnlAudio.Location = new Point(200, 120);
            pnlAudio.Name = "pnlAudio";
            pnlAudio.Size = new Size(500, 150);
            pnlAudio.TabIndex = 8;
            // 
            // chkSFX
            // 
            chkSFX.Checked = true;
            chkSFX.CheckState = CheckState.Checked;
            chkSFX.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            chkSFX.ForeColor = Color.Lime;
            chkSFX.Location = new Point(408, 77);
            chkSFX.Name = "chkSFX";
            chkSFX.Size = new Size(79, 54);
            chkSFX.TabIndex = 8;
            chkSFX.Text = "ON";
            chkSFX.UseVisualStyleBackColor = true;
            chkSFX.CheckedChanged += chkSFX_CheckedChanged_1;
            // 
            // chkMusic
            // 
            chkMusic.Checked = true;
            chkMusic.CheckState = CheckState.Checked;
            chkMusic.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            chkMusic.ForeColor = Color.Lime;
            chkMusic.Location = new Point(96, 77);
            chkMusic.Name = "chkMusic";
            chkMusic.Size = new Size(76, 55);
            chkMusic.TabIndex = 8;
            chkMusic.Text = "ON";
            chkMusic.UseVisualStyleBackColor = true;
            chkMusic.CheckedChanged += chkMusic_CheckedChanged;
            // 
            // lblSFX
            // 
            lblSFX.BackColor = Color.Transparent;
            lblSFX.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSFX.ForeColor = Color.White;
            lblSFX.Location = new Point(260, 75);
            lblSFX.Name = "lblSFX";
            lblSFX.Size = new Size(151, 55);
            lblSFX.TabIndex = 7;
            lblSFX.Text = "Sound Effects";
            lblSFX.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblMusic
            // 
            lblMusic.BackColor = Color.Transparent;
            lblMusic.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblMusic.ForeColor = Color.White;
            lblMusic.Location = new Point(18, 75);
            lblMusic.Name = "lblMusic";
            lblMusic.Size = new Size(83, 55);
            lblMusic.TabIndex = 7;
            lblMusic.Text = "Music";
            lblMusic.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblAudioSetting
            // 
            lblAudioSetting.BackColor = Color.Transparent;
            lblAudioSetting.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblAudioSetting.ForeColor = Color.White;
            lblAudioSetting.Location = new Point(0, 0);
            lblAudioSetting.Name = "lblAudioSetting";
            lblAudioSetting.Size = new Size(500, 60);
            lblAudioSetting.TabIndex = 7;
            lblAudioSetting.Text = "🔊 AUDIO SETTINGS";
            lblAudioSetting.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(20, 20, 30);
            panel1.Controls.Add(tlpControl2);
            panel1.Controls.Add(tlpControl1);
            panel1.Controls.Add(lblControlGuide);
            panel1.Location = new Point(200, 290);
            panel1.Name = "panel1";
            panel1.Size = new Size(500, 220);
            panel1.TabIndex = 8;
            // 
            // tlpControl2
            // 
            tlpControl2.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            tlpControl2.ColumnCount = 2;
            tlpControl2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 39.449543F));
            tlpControl2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60.550457F));
            tlpControl2.Controls.Add(lblKey4, 0, 0);
            tlpControl2.Controls.Add(lblKey5, 0, 1);
            tlpControl2.Controls.Add(lblKey6, 0, 2);
            tlpControl2.Controls.Add(lblAction4, 1, 0);
            tlpControl2.Controls.Add(lblAction6, 1, 2);
            tlpControl2.Controls.Add(lblAction5, 1, 1);
            tlpControl2.Location = new Point(260, 73);
            tlpControl2.Name = "tlpControl2";
            tlpControl2.RowCount = 3;
            tlpControl2.RowStyles.Add(new RowStyle(SizeType.Percent, 33F));
            tlpControl2.RowStyles.Add(new RowStyle(SizeType.Percent, 33F));
            tlpControl2.RowStyles.Add(new RowStyle(SizeType.Percent, 34F));
            tlpControl2.Size = new Size(227, 126);
            tlpControl2.TabIndex = 8;
            // 
            // lblKey4
            // 
            lblKey4.BackColor = Color.Transparent;
            lblKey4.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblKey4.ForeColor = Color.White;
            lblKey4.Location = new Point(4, 1);
            lblKey4.Name = "lblKey4";
            lblKey4.Size = new Size(82, 40);
            lblKey4.TabIndex = 7;
            lblKey4.Text = "D / →";
            lblKey4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblKey5
            // 
            lblKey5.BackColor = Color.Transparent;
            lblKey5.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblKey5.ForeColor = Color.White;
            lblKey5.Location = new Point(4, 42);
            lblKey5.Name = "lblKey5";
            lblKey5.Size = new Size(82, 40);
            lblKey5.TabIndex = 7;
            lblKey5.Text = "SPACE";
            lblKey5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblKey6
            // 
            lblKey6.BackColor = Color.Transparent;
            lblKey6.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblKey6.ForeColor = Color.White;
            lblKey6.Location = new Point(4, 83);
            lblKey6.Name = "lblKey6";
            lblKey6.Size = new Size(82, 41);
            lblKey6.TabIndex = 7;
            lblKey6.Text = "ESC";
            lblKey6.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblAction4
            // 
            lblAction4.BackColor = Color.Transparent;
            lblAction4.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblAction4.ForeColor = Color.White;
            lblAction4.Location = new Point(93, 1);
            lblAction4.Name = "lblAction4";
            lblAction4.Size = new Size(130, 40);
            lblAction4.TabIndex = 7;
            lblAction4.Text = "Move Right";
            lblAction4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblAction6
            // 
            lblAction6.BackColor = Color.Transparent;
            lblAction6.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblAction6.ForeColor = Color.White;
            lblAction6.Location = new Point(93, 83);
            lblAction6.Name = "lblAction6";
            lblAction6.Size = new Size(130, 41);
            lblAction6.TabIndex = 7;
            lblAction6.Text = "Pause";
            lblAction6.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblAction5
            // 
            lblAction5.BackColor = Color.Transparent;
            lblAction5.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblAction5.ForeColor = Color.White;
            lblAction5.Location = new Point(93, 42);
            lblAction5.Name = "lblAction5";
            lblAction5.Size = new Size(130, 40);
            lblAction5.TabIndex = 7;
            lblAction5.Text = "Shoot";
            lblAction5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tlpControl1
            // 
            tlpControl1.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            tlpControl1.ColumnCount = 2;
            tlpControl1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 32.1888428F));
            tlpControl1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 67.81116F));
            tlpControl1.Controls.Add(lblKey1, 0, 0);
            tlpControl1.Controls.Add(lblKey2, 0, 1);
            tlpControl1.Controls.Add(lblAction1, 1, 0);
            tlpControl1.Controls.Add(lblKey3, 0, 2);
            tlpControl1.Controls.Add(lblAction2, 1, 1);
            tlpControl1.Controls.Add(lblAction3, 1, 2);
            tlpControl1.Location = new Point(18, 73);
            tlpControl1.Name = "tlpControl1";
            tlpControl1.RowCount = 3;
            tlpControl1.RowStyles.Add(new RowStyle(SizeType.Percent, 33F));
            tlpControl1.RowStyles.Add(new RowStyle(SizeType.Percent, 33F));
            tlpControl1.RowStyles.Add(new RowStyle(SizeType.Percent, 34F));
            tlpControl1.Size = new Size(233, 126);
            tlpControl1.TabIndex = 8;
            // 
            // lblKey1
            // 
            lblKey1.BackColor = Color.Transparent;
            lblKey1.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblKey1.ForeColor = Color.White;
            lblKey1.Location = new Point(4, 1);
            lblKey1.Name = "lblKey1";
            lblKey1.Size = new Size(68, 40);
            lblKey1.TabIndex = 7;
            lblKey1.Text = "W / ↑";
            lblKey1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblKey2
            // 
            lblKey2.BackColor = Color.Transparent;
            lblKey2.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblKey2.ForeColor = Color.White;
            lblKey2.Location = new Point(4, 42);
            lblKey2.Name = "lblKey2";
            lblKey2.Size = new Size(68, 40);
            lblKey2.TabIndex = 7;
            lblKey2.Text = "S / ↓\n";
            lblKey2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblAction1
            // 
            lblAction1.BackColor = Color.Transparent;
            lblAction1.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblAction1.ForeColor = Color.White;
            lblAction1.Location = new Point(79, 1);
            lblAction1.Name = "lblAction1";
            lblAction1.Size = new Size(133, 40);
            lblAction1.TabIndex = 7;
            lblAction1.Text = "Move Up";
            lblAction1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblKey3
            // 
            lblKey3.BackColor = Color.Transparent;
            lblKey3.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblKey3.ForeColor = Color.White;
            lblKey3.Location = new Point(4, 83);
            lblKey3.Name = "lblKey3";
            lblKey3.Size = new Size(68, 41);
            lblKey3.TabIndex = 7;
            lblKey3.Text = "A / ←";
            lblKey3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblAction2
            // 
            lblAction2.BackColor = Color.Transparent;
            lblAction2.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblAction2.ForeColor = Color.White;
            lblAction2.Location = new Point(79, 42);
            lblAction2.Name = "lblAction2";
            lblAction2.Size = new Size(150, 40);
            lblAction2.TabIndex = 7;
            lblAction2.Text = "Move Down";
            lblAction2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblAction3
            // 
            lblAction3.BackColor = Color.Transparent;
            lblAction3.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblAction3.ForeColor = Color.White;
            lblAction3.Location = new Point(79, 83);
            lblAction3.Name = "lblAction3";
            lblAction3.Size = new Size(132, 41);
            lblAction3.TabIndex = 7;
            lblAction3.Text = "Move Left";
            lblAction3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblControlGuide
            // 
            lblControlGuide.BackColor = Color.Transparent;
            lblControlGuide.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblControlGuide.ForeColor = Color.White;
            lblControlGuide.Location = new Point(0, 0);
            lblControlGuide.Name = "lblControlGuide";
            lblControlGuide.Size = new Size(500, 60);
            lblControlGuide.TabIndex = 7;
            lblControlGuide.Text = "🎮 CONTROLS GUIDE";
            lblControlGuide.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnBack
            // 
            btnBack.BackColor = Color.FromArgb(10, 20, 30);
            btnBack.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnBack.ForeColor = Color.White;
            btnBack.Location = new Point(30, 465);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(140, 45);
            btnBack.TabIndex = 8;
            btnBack.Text = "BACK";
            btnBack.TextAlign = ContentAlignment.MiddleCenter;
            btnBack.Click += btnBack_Click;
            btnBack.MouseLeave += btnBack_MouseLeave;
            btnBack.MouseHover += btnBack_MouseHover;
            // 
            // OptionsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(5, 7, 15);
            ClientSize = new Size(884, 561);
            Controls.Add(btnBack);
            Controls.Add(panel1);
            Controls.Add(pnlAudio);
            Controls.Add(lblTitle);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            KeyPreview = true;
            MaximizeBox = false;
            Name = "OptionsForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "OptionsForm";
            KeyDown += OptionsForm_KeyDown;
            pnlAudio.ResumeLayout(false);
            panel1.ResumeLayout(false);
            tlpControl2.ResumeLayout(false);
            tlpControl1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Label lblTitle;
        private Panel pnlAudio;
        private Label lblAudioSetting;
        private CheckBox chkMusic;
        private CheckBox chkSFX;
        private Label lblMusic;
        private Label lblSFX;
        private Panel panel1;
        private Label lblControlGuide;
        private TableLayoutPanel tlpControl1;
        private Label btnBack;
        private TableLayoutPanel tlpControl2;
        private Label lblKey1;
        private Label lblKey2;
        private Label lblKey3;
        private Label lblKey4;
        private Label lblKey5;
        private Label lblKey6;
        private Label lblAction1;
        private Label lblAction4;
        private Label lblAction5;
        private Label lblAction6;
        private Label lblAction2;
        private Label lblAction3;
    }
}