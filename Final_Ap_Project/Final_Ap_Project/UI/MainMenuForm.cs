using Final_Ap_Project.Managers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
// Threading.Timer for avoid conflict
using Timer = System.Windows.Forms.Timer;

namespace Final_Ap_Project.UI
{
    public partial class MainMenuForm : Form
    {
        List<Point> stars = new List<Point>();
        Random rnd = new Random();
        Timer timer = new Timer();

        public MainMenuForm()
        {
            InitializeComponent();

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

        private void MainMenuForm_Load(object sender, EventArgs e)
        {

        }

        // Input Manage:
        private void btnPlay_Click(object sender, EventArgs e)
        {
            // Hide main menu:
            this.Hide();

            AudioManager.StopMusic();

            // GameForm : Modal
            using (GameForm game = new GameForm())
            {
                game.ShowDialog();
            }

            // Back to Main menu:
            this.Show();
            AudioManager.PlayMenuMusic();
        }

        private void btnShop_Click(object sender, EventArgs e)
        {
            // Hide main menu:
            this.Hide();

            AudioManager.StopMusic();

            // ShopForm : Modal
            using (ShopForm game = new ShopForm())
            {
                game.ShowDialog();
            }

            // Back to Main menu:
            this.Show();
            AudioManager.PlayMenuMusic();
        }

        private void btnOptions_Click(object sender, EventArgs e)
        {
            // Hide main menu:
            this.Hide();

            AudioManager.StopMusic();

            // OptionsForm : Modal
            using (OptionsForm game = new OptionsForm())
            {
                game.ShowDialog();
            }

            // Back to Main menu:
            this.Show();
            AudioManager.PlayMenuMusic();
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            // Hide main menu:
            this.Hide();

            AudioManager.StopMusic();

            // AboutForm : Modal
            using (AboutForm game = new AboutForm())
            {
                game.ShowDialog();
            }

            // Back to Main menu:
            this.Show();
            AudioManager.PlayMenuMusic();
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnPlay_MouseHover(object sender, EventArgs e)
        {
            btnPlay.BackColor = Color.FromArgb(30, 30, 60);
        }

        private void btnShop_MouseHover(object sender, EventArgs e)
        {
            btnShop.BackColor = Color.FromArgb(30, 30, 60);
        }

        private void btnOptions_MouseHover(object sender, EventArgs e)
        {
            btnOptions.BackColor = Color.FromArgb(30, 30, 60);
        }

        private void btnAbout_MouseHover(object sender, EventArgs e)
        {
            btnAbout.BackColor = Color.FromArgb(30, 30, 60);
        }

        private void btnQuit_MouseHover(object sender, EventArgs e)
        {
            btnQuit.BackColor = Color.FromArgb(30, 30, 60);
        }

        private void btnPlay_MouseLeave(object sender, EventArgs e)
        {
            btnPlay.BackColor = Color.Black;
        }

        private void btnShop_MouseLeave(object sender, EventArgs e)
        {
            btnShop.BackColor = Color.Black;
        }

        private void btnOptions_MouseLeave(object sender, EventArgs e)
        {
            btnOptions.BackColor = Color.Black;
        }

        private void btnAbout_MouseLeave(object sender, EventArgs e)
        {
            btnAbout.BackColor = Color.Black;
        }

        private void btnQuit_MouseLeave(object sender, EventArgs e)
        {
            btnQuit.BackColor = Color.Black;
        }

        private void MainMenuForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
