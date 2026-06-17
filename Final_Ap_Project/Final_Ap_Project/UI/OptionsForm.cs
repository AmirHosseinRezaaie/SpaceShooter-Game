using Final_Ap_Project.Managers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Timers;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace Final_Ap_Project.UI
{
    public partial class OptionsForm : Form
    {
        List<Point> stars = new List<Point>();
        Random rnd = new Random();
        Timer timer = new Timer();

        public OptionsForm()
        {
            InitializeComponent();

            // Add Stars in BackGround:
            for (int i = 0; i < 120; i++)
            {
                stars.Add(new Point(rnd.Next(Width), rnd.Next(Height)));
            }
            timer.Interval = 30;
            timer.Tick += Timer_Tick;
            timer.Start();
            this.Paint += MainMenuForm_Paint;
        }

        // Timer for Stars:
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
        private void MainMenuForm_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.FromArgb(5, 7, 15));

            foreach (var star in stars)
            {
                e.Graphics.FillEllipse(Brushes.White, star.X, star.Y, 2, 2);
            }
        }

        // Input Manage:
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnBack_MouseHover(object sender, EventArgs e)
        {
            btnBack.BackColor = Color.FromArgb(30, 30, 60);
        }
        private void btnBack_MouseLeave(object sender, EventArgs e)
        {
            btnBack.BackColor = Color.FromArgb(10, 20, 30);
        }

        private void chkSFX_CheckedChanged_1(object sender, EventArgs e)
        {
            AudioManager.SFXEnabled = chkSFX.Checked;

            if (chkSFX.Checked)
            {
                chkSFX.Text = "ON";
                chkSFX.ForeColor = Color.Lime;
            }
            else
            {
                chkSFX.Text = "OFF";
                chkSFX.ForeColor = Color.Red;
            }
        }

        private void chkMusic_CheckedChanged(object sender, EventArgs e)
        {
            AudioManager.MusicEnabled = chkMusic.Checked;

            if (chkMusic.Checked)
            {
                chkMusic.Text = "ON";
                chkMusic.ForeColor = Color.Lime;

                AudioManager.PlayMenuMusic();
            }
            else
            {
                chkMusic.Text = "OFF";
                chkMusic.ForeColor = Color.Red;

                AudioManager.StopMusic();
            }
        }

        private void OptionsForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
