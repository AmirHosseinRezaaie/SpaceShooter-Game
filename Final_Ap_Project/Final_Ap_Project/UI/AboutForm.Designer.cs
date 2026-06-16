namespace Final_Ap_Project.UI
{
    partial class AboutForm
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutForm));
            lblAboutTitle = new Label();
            panelAbout = new Panel();
            lblAbout = new Label();
            timer1 = new System.Windows.Forms.Timer(components);
            btnBack = new Label();
            panelAbout.SuspendLayout();
            SuspendLayout();
            // 
            // lblAboutTitle
            // 
            lblAboutTitle.BackColor = Color.Transparent;
            lblAboutTitle.Font = new Font("Segoe UI Black", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblAboutTitle.ForeColor = Color.White;
            lblAboutTitle.Location = new Point(200, 30);
            lblAboutTitle.Name = "lblAboutTitle";
            lblAboutTitle.Size = new Size(500, 60);
            lblAboutTitle.TabIndex = 7;
            lblAboutTitle.Text = "About";
            lblAboutTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panelAbout
            // 
            panelAbout.BackColor = Color.FromArgb(20, 20, 30);
            panelAbout.BorderStyle = BorderStyle.FixedSingle;
            panelAbout.Controls.Add(lblAbout);
            panelAbout.Location = new Point(150, 93);
            panelAbout.Name = "panelAbout";
            panelAbout.Size = new Size(600, 400);
            panelAbout.TabIndex = 8;
            // 
            // lblAbout
            // 
            lblAbout.AutoSize = true;
            lblAbout.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblAbout.ForeColor = Color.White;
            lblAbout.Location = new Point(-50, 25);
            lblAbout.Name = "lblAbout";
            lblAbout.Size = new Size(688, 875);
            lblAbout.TabIndex = 0;
            lblAbout.Text = resources.GetString("lblAbout.Text");
            lblAbout.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // timer1
            // 
            timer1.Interval = 20;
            timer1.Tick += timer1_Tick;
            // 
            // btnBack
            // 
            btnBack.BackColor = Color.FromArgb(10, 20, 30);
            btnBack.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnBack.ForeColor = Color.White;
            btnBack.Location = new Point(380, 505);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(140, 45);
            btnBack.TabIndex = 9;
            btnBack.Text = "BACK";
            btnBack.TextAlign = ContentAlignment.MiddleCenter;
            btnBack.Click += btnBack_Click;
            // 
            // AboutForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(5, 7, 15);
            ClientSize = new Size(884, 561);
            Controls.Add(btnBack);
            Controls.Add(panelAbout);
            Controls.Add(lblAboutTitle);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            KeyPreview = true;
            MaximizeBox = false;
            Name = "AboutForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AboutForm";
            Load += AboutForm_Load;
            KeyDown += AboutForm_KeyDown;
            panelAbout.ResumeLayout(false);
            panelAbout.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label lblAboutTitle;
        private Panel panelAbout;
        private Label lblAbout;
        private System.Windows.Forms.Timer timer1;
        private Label btnBack;
    }
}