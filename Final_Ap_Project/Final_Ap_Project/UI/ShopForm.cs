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
        private int viewedSkinIndex = 0;
        private int[] skinPrices = { 0, 100, 100, 100, 500 };

        private Image[] skinImages = new Image[]
        {
            Properties.Resources.PlayerSpaceshipّSize,
            Properties.Resources.PlayerSpaceship_red,
            Properties.Resources.PlayerSpaceship_pink,
            Properties.Resources.PlayerSpaceship_green
        };

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
            viewedSkinIndex = GameData.CurrentSkinIndex;

            if (viewedSkinIndex > 3) viewedSkinIndex = 0;

            pictureBox7.Image = skinImages[viewedSkinIndex];

            UpdateCoinDisplay();
            UpdateShopUI();
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
                if (GameData.ExtraHP < 2)
                {
                    GameData.TotalCoins -= price;
                    GameData.ExtraHP++;
                    UpdateCoinDisplay();
                    MessageBox.Show("1 Health Point Added!");
                }
                else
                {
                    MessageBox.Show("Maximum Health Level Reached!");
                }
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
                if (GameData.ExtraSpeed < 3)
                {
                    GameData.TotalCoins -= price;
                    GameData.ExtraSpeed++;
                    UpdateCoinDisplay();
                    MessageBox.Show("1 Speed Point Added!");
                }
                else
                {
                    MessageBox.Show("Maximum Speed Level Reached!");
                }
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

        private void UpdateShopUI()
        {
            if (GameData.CurrentSkinIndex == viewedSkinIndex)
            {
                button7.Text = "Equipped";
                button7.Enabled = false;
            }
            else if (GameData.UnlockedSkins[viewedSkinIndex])
            {
                button7.Text = "Equip";
                button7.Enabled = true;
            }
            else
            {
                button7.Text = $"Buy: {skinPrices[viewedSkinIndex]}";
                button7.Enabled = true;
            }

            if (GameData.CurrentSkinIndex == 4)
            {
                button4.Text = "Equipped";
                button4.Enabled = false;
            }
            else if (GameData.UnlockedSkins[4])
            {
                button4.Text = "Equip";
                button4.Enabled = true;
            }
            else
            {
                button4.Text = $"Buy: {skinPrices[4]}";
                button4.Enabled = true;
            }

            UpdateCoinDisplay();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            viewedSkinIndex++;
            if (viewedSkinIndex > 3) viewedSkinIndex = 0;

            pictureBox7.Image = skinImages[viewedSkinIndex];

            UpdateShopUI();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            viewedSkinIndex--;
            if (viewedSkinIndex < 0) viewedSkinIndex = 3;

            pictureBox7.Image = skinImages[viewedSkinIndex];

            UpdateShopUI();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ProcessSkinAction(viewedSkinIndex);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ProcessSkinAction(4);
        }
        private void ProcessSkinAction(int index)
        {
            if (GameData.UnlockedSkins[index])
            {
                GameData.CurrentSkinIndex = index;
            }
            else if (GameData.TotalCoins >= skinPrices[index])
            {
                GameData.TotalCoins -= skinPrices[index];
                GameData.UnlockedSkins[index] = true;
                GameData.CurrentSkinIndex = index;
                MessageBox.Show("Skin Unlocked!");
            }
            else
            {
                MessageBox.Show("Not enough coins!");
            }

            UpdateShopUI();
        }

    }
}
