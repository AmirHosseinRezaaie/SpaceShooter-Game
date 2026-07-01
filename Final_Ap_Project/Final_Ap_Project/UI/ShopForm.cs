using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Timers;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;
using Final_Ap_Project.Data;

namespace Final_Ap_Project.UI
{
    public partial class ShopForm : Form
    {
        List<Point> stars = new List<Point>();
        Random rnd = new Random();
        Timer timer = new Timer();

        public ShopForm()
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
            // Redraw screen
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

        private void ShopForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void ShopForm_Load(object sender, EventArgs e)
        {
            UpdateCoinDisplay();
        }
        private void UpdateCoinDisplay()
        {
            lblCoins.Text = "Coins: " + GameData.TotalCoins.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int price = 50;

            if (GameData.TotalCoins >= price)
            {
                GameData.TotalCoins -= price;

                GameData.ExtraHP++;

                UpdateCoinDisplay();

                MessageBox.Show("1 Health Point Added!");
            }
            else
            {
                MessageBox.Show("Not enough coins!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int price = 75;

            if (GameData.TotalCoins >= price)
            {
                GameData.TotalCoins -= price;

                GameData.ExtraSpeed++;

                UpdateCoinDisplay();

                MessageBox.Show("1 Speed Point Added!");
            }
            else
            {
                MessageBox.Show("Not enough coins!");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int price = 100;

            if (GameData.TotalCoins >= price)
            {
                if (GameData.FireRateLevel < 2)
                {
                    GameData.TotalCoins -= price;
                    GameData.FireRateLevel++;

                    MessageBox.Show("Rapid Fire Upgraded!");
                }
                else
                {
                    MessageBox.Show("Maximum Level Reached!");
                }
                UpdateCoinDisplay();
            }
            else
            {
                MessageBox.Show("Not enough coins!");
            }
        }

    }
}
