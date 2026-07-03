using Final_Ap_Project.Managers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;
using Final_Ap_Project.Data;

namespace Final_Ap_Project.UI
{
    public partial class LoginForm : Form
    {
        List<Point> stars = new List<Point>();
        Random rnd = new Random();
        Timer timer = new Timer();

        public LoginForm()
        {
            InitializeComponent();

            txtPassword.KeyPress += txtPassword_KeyPress;

            // random positions for Stars
            for (int i = 0; i < 120; i++)
            {
                stars.Add(new Point(rnd.Next(Width), rnd.Next(Height)));
            }

            // Timer speed (frame update every 30ms)
            timer.Interval = 30;
            timer.Tick += Timer_Tick;
            timer.Start();

            // Paint Event to draw on screen
            this.Paint += MainMenuForm_Paint;

            AudioManager.PlayMenuMusic();

            this.AcceptButton = btnLogin;
        }
        // Update star positions
        private void Timer_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < stars.Count; i++)
            {
                Point p = stars[i];
                p.Y += 1;

                if (p.Y > Height)
                    p = new Point(rnd.Next(Width), 0);

                stars[i] = p;
            }
            Invalidate();
        }

        // Draw Stars
        private void MainMenuForm_Paint(object sender, PaintEventArgs e)
        {
            foreach (var star in stars)
            {
                e.Graphics.FillEllipse(Brushes.White, star.X, star.Y, 2, 2);
            }
        }

        private void btnLogin_MouseHover(object sender, EventArgs e)
        {
            btnLogin.BackColor = Color.DeepSkyBlue;
        }

        private void btnLogin_MouseLeave(object sender, EventArgs e)
        {
            btnLogin.BackColor = Color.FromArgb(1, 171, 227);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();

            string password = txtPassword.Text.Trim();

            if (username.Length < 3)
            {
                MessageBox.Show("Username must contain at least 3 characters.");
                return;
            }

            if (password.Length != 4)
            {
                MessageBox.Show("Password must be exactly 4 digits.");
                return;
            }

            if (!int.TryParse(password, out _))
            {
                MessageBox.Show("Password must contain only numbers.");
                return;
            }

            LoginResult result = DatabaseManager.LoginOrRegister(username, password);

            if (result == LoginResult.WrongPassword)
            {
                MessageBox.Show("Wrong password.");
                return;
            }

            DatabaseManager.LoadGame();

            MainMenuForm menu = new MainMenuForm();

            this.Hide();

            menu.ShowDialog();

            this.Close();
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
