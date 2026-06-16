using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace Final_Ap_Project.UI
{
    public partial class AboutForm : Form
    {
        List<Point> stars = new List<Point>();
        Random rnd = new Random();
        Timer timer = new Timer();

        public AboutForm()
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

        private void AboutForm_Load(object sender, EventArgs e)
        {
            // Timer 20ms
            timer1.Start();
        }

        // Scroll text:
        private void timer1_Tick(object sender, EventArgs e)
        {
            lblAbout.Top--;

            // ReStart scroll:
            if (lblAbout.Bottom < 0)
            {
                lblAbout.Top = panelAbout.Height;
            }
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

        // Manage Inputs:
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

        private void AboutForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
