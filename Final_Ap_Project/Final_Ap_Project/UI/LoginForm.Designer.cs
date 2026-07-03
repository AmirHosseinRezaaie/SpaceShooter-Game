namespace Final_Ap_Project.UI
{
    partial class LoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            pnlLogin = new Panel();
            txtUsername = new TextBox();
            txtPassword = new TextBox();
            lblPass = new Label();
            lblHint = new Label();
            lblUser = new Label();
            btnLogin = new Button();
            lblTitle = new Label();
            pnlLogin.SuspendLayout();
            SuspendLayout();
            // 
            // pnlLogin
            // 
            pnlLogin.BackColor = Color.FromArgb(20, 20, 30);
            pnlLogin.Controls.Add(txtUsername);
            pnlLogin.Controls.Add(txtPassword);
            pnlLogin.Controls.Add(lblPass);
            pnlLogin.Controls.Add(lblHint);
            pnlLogin.Controls.Add(lblUser);
            pnlLogin.Controls.Add(btnLogin);
            pnlLogin.Controls.Add(lblTitle);
            pnlLogin.Location = new Point(225, 90);
            pnlLogin.Name = "pnlLogin";
            pnlLogin.Size = new Size(450, 350);
            pnlLogin.TabIndex = 0;
            // 
            // txtUsername
            // 
            txtUsername.BorderStyle = BorderStyle.FixedSingle;
            txtUsername.Location = new Point(175, 98);
            txtUsername.MaxLength = 20;
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(250, 23);
            txtUsername.TabIndex = 3;
            // 
            // txtPassword
            // 
            txtPassword.BorderStyle = BorderStyle.FixedSingle;
            txtPassword.Location = new Point(325, 155);
            txtPassword.MaxLength = 4;
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '●';
            txtPassword.ShortcutsEnabled = false;
            txtPassword.Size = new Size(100, 23);
            txtPassword.TabIndex = 3;
            txtPassword.KeyPress += txtPassword_KeyPress;
            // 
            // lblPass
            // 
            lblPass.AutoSize = true;
            lblPass.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPass.ForeColor = Color.White;
            lblPass.Location = new Point(29, 155);
            lblPass.Name = "lblPass";
            lblPass.Size = new Size(164, 25);
            lblPass.TabIndex = 2;
            lblPass.Text = "4-Digit Password";
            // 
            // lblHint
            // 
            lblHint.AutoSize = true;
            lblHint.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblHint.ForeColor = SystemColors.ScrollBar;
            lblHint.Location = new Point(58, 220);
            lblHint.Name = "lblHint";
            lblHint.Size = new Size(358, 21);
            lblHint.TabIndex = 5;
            lblHint.Text = "New player? Enter a new username and password.";
            // 
            // lblUser
            // 
            lblUser.AutoSize = true;
            lblUser.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblUser.ForeColor = Color.White;
            lblUser.Location = new Point(29, 92);
            lblUser.Name = "lblUser";
            lblUser.Size = new Size(101, 25);
            lblUser.TabIndex = 2;
            lblUser.Text = "Username";
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.FromArgb(1, 171, 227);
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Segoe UI Black", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(142, 281);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(170, 45);
            btnLogin.TabIndex = 4;
            btnLogin.Text = "LOGIN";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            btnLogin.MouseLeave += btnLogin_MouseLeave;
            btnLogin.MouseHover += btnLogin_MouseHover;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI Black", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.White;
            lblTitle.LiveSetting = System.Windows.Forms.Automation.AutomationLiveSetting.Assertive;
            lblTitle.Location = new Point(165, 15);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(121, 45);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "LOGIN";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(5, 7, 15);
            ClientSize = new Size(884, 561);
            Controls.Add(pnlLogin);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            KeyPreview = true;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "LoginForm";
            pnlLogin.ResumeLayout(false);
            pnlLogin.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlLogin;
        private Label lblTitle;
        private Label lblUser;
        private Label lblPass;
        private TextBox txtUsername;
        private TextBox txtPassword;
        private Button btnLogin;
        private Label lblHint;
    }
}