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

            //this.Icon = Properties.Resources.SpaceShooterIcon;

            // Initialize star positions randomly across the screen
            for (int i = 0; i < 120; i++)
            {
                stars.Add(new Point(rnd.Next(Width), rnd.Next(Height)));
            }

            // Set timer speed (frame update interval in ms)
            timer.Interval = 30;

            // Run update method every timer tick
            timer.Tick += Timer_Tick;

            // Start the animation timer
            timer.Start();

            // Attach paint event to draw graphics on screen
            this.Paint += MainMenuForm_Paint;
        }

        private void AboutForm_Load(object sender, EventArgs e)
        {
            // Timer 20ms
            timer1.Start();
        }

        // For Scroll text:
        private void timer1_Tick(object sender, EventArgs e)
        {
            lblAbout.Top--;

            // ReStart scroll:
            if (lblAbout.Bottom < 0)
            {
                lblAbout.Top = panelAbout.Height;
            }
        }

        // Update star positions to create falling effect
        private void Timer_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < stars.Count; i++)
            {
                Point p = stars[i];
                // Move star downward
                p.Y += 1;

                // Reset star to top if it goes off screen
                if (p.Y > Height)
                    p = new Point(rnd.Next(Width), 0);

                stars[i] = p;
            }
            // Redraw screen
            Invalidate();
        }

        // Draw background and stars on screen
        private void MainMenuForm_Paint(object sender, PaintEventArgs e)
        {
            // Fill background with dark space color
            e.Graphics.Clear(Color.FromArgb(5, 7, 15));

            // Draw each star as a small white dot
            foreach (var star in stars)
            {
                e.Graphics.FillEllipse(Brushes.White, star.X, star.Y, 2, 2);
            }
        }

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
