using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Final_Ap_Project.Models;
using Final_Ap_Project.Managers;

namespace Final_Ap_Project.UI
{
    public partial class GameForm : Form
    {
        bool moveLeft;
        bool moveRight;
        bool moveUp;
        bool moveDown;

        private List<Enemy> activeEnemies;
        private List<Bullet> activeBullets;
        private List<Coin> activeCoins;
        private List<PowerUp> activePowerUps;
        private Player myPlayer;
        private System.Windows.Forms.Timer gameTimer;
        private Random rnd = new Random();

        private WaveManager waveManager;

        public GameForm()
        {
            InitializeComponent();

            this.DoubleBuffered = true;

            this.BackgroundImage = Properties.Resources.BackGround;
            this.BackgroundImageLayout = ImageLayout.Stretch;

            activeEnemies = new List<Enemy>();
            activeBullets = new List<Bullet>();
            activeCoins = new List<Coin>();
            activePowerUps = new List<PowerUp>();

            myPlayer = new Player(425, 500, 50, 50, 5, Properties.Resources.PlayerSpaceship, 3);

            gameTimer = new System.Windows.Forms.Timer();
            gameTimer.Interval = 20;
            gameTimer.Tick += GameLoop;

            waveManager = new WaveManager(myPlayer);
            waveManager.StartWave();

            UpdateHUD();
            gameTimer.Start();

            AudioManager.PlayBackgroundMusic();
        }
        private void GameLoop(object sender, EventArgs e)
        {
            myPlayer.UpdatePowerUps();
            UpdatePlayerMovement();

            for (int i = activeBullets.Count - 1; i >= 0; i--)
            {
                activeBullets[i].Move();
                if (activeBullets[i].Y < 0)
                {
                    activeBullets.RemoveAt(i);
                }
            }

            for (int i = activeEnemies.Count - 1; i >= 0; i--)
            {
                activeEnemies[i].Move();
                if (activeEnemies[i].Y > this.ClientSize.Height)
                {
                    activeEnemies.RemoveAt(i);
                }
            }

            CheckCollisions();

            waveManager.Update(activeEnemies);

            CheckWaveStatus();

            UpdateHUD();
            this.Invalidate();
        }
        private void UpdateHUD()
        {
            lblHP.Text = myPlayer.HP.ToString();

            lblScore.Text = myPlayer.Score.ToString();

            lblCoins.Text = myPlayer.Coins.ToString();

            lblWave.Text = waveManager.CurrentWave.ToString();
        }

        private void UpdatePlayerMovement()
        {
            if (moveLeft && myPlayer.X > 0) myPlayer.X -= myPlayer.Speed;
            if (moveRight && myPlayer.X + myPlayer.Width < this.ClientSize.Width) myPlayer.X += myPlayer.Speed;
            if (moveUp && myPlayer.Y > 0) myPlayer.Y -= myPlayer.Speed;
            if (moveDown && myPlayer.Y + myPlayer.Height < this.ClientSize.Height) myPlayer.Y += myPlayer.Speed;
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;

            myPlayer.Draw(g);

            foreach (var bullet in activeBullets)
            {
                bullet.Draw(g);
            }

            foreach (var enemy in activeEnemies)
            {
                enemy.Draw(g);
            }

            foreach (var coin in activeCoins)
            {
                coin.Draw(g);
            }
        }

        private void GameForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
            if (e.KeyCode == Keys.A) { moveLeft = true; }
            if (e.KeyCode == Keys.D) { moveRight = true; }
            if (e.KeyCode == Keys.W) { moveUp = true; }
            if (e.KeyCode == Keys.S) { moveDown = true; }
            if (e.KeyCode == Keys.Space) { FireBullet(); }

        }

        private void GameForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A) { moveLeft = false; }
            if (e.KeyCode == Keys.D) { moveRight = false; }
            if (e.KeyCode == Keys.W) { moveUp = false; }
            if (e.KeyCode == Keys.S) { moveDown = false; }
        }
        private void CheckCollisions()
        {

            for (int i = activeBullets.Count - 1; i >= 0; i--)
            {
                if (activeBullets[i].IsPlayerBullet)
                {
                    for (int j = activeEnemies.Count - 1; j >= 0; j--)
                    {
                        if (activeBullets[i].GetBounds().IntersectsWith(activeEnemies[j].GetBounds()))
                        {
                            activeEnemies[j].HP--;
                            activeBullets.RemoveAt(i);
                            AudioManager.PlayHit();

                            if (activeEnemies[j].HP <= 0)
                            {
                                myPlayer.Score += activeEnemies[j].ScoreValue;

                                if (rnd.Next(1, 101) <= activeEnemies[j].CoinDropChance)
                                {

                                    bool isGoldCoin = (rnd.Next(1, 101) <= 20);

                                    Coin droppedCoin = new Coin(activeEnemies[j].X, activeEnemies[j].Y, 3, isGoldCoin ? Properties.Resources.Coin2 : Properties.Resources.Coin, isGoldCoin);

                                    activeCoins.Add(droppedCoin);
                                }

                                activeEnemies.RemoveAt(j);

                                AudioManager.PlayExplosion();
                            }
                            break;
                        }
                    }
                }
            }

            for (int i = activeEnemies.Count - 1; i >= 0; i--)
            {
                if (myPlayer.GetBounds().IntersectsWith(activeEnemies[i].GetBounds()))
                {
                    activeEnemies.RemoveAt(i);

                    AudioManager.PlayHit();

                    if (!myPlayer.HasShield)
                    {
                        myPlayer.HP--;

                        if (myPlayer.HP <= 0)
                        {
                            AudioManager.PlayGameOver();
                            AudioManager.StopMusic();
                            gameTimer.Stop();
                            MessageBox.Show("Game Over!");
                            this.Close();
                        }
                    }
                }
            }
            for (int i = activeBullets.Count - 1; i >= 0; i--)
            {
                if (!activeBullets[i].IsPlayerBullet && myPlayer.GetBounds().IntersectsWith(activeBullets[i].GetBounds()))
                {
                    activeBullets.RemoveAt(i);

                    if (!myPlayer.HasShield)
                    {
                        myPlayer.HP--;

                        if (myPlayer.HP <= 0)
                        {
                            if (myPlayer.HP <= 0)
                            {
                                AudioManager.PlayGameOver();
                                AudioManager.StopMusic();
                                gameTimer.Stop();
                                MessageBox.Show("Game Over!");
                                this.Close();
                            }
                        }
                    }
                }
            }

            for (int i = activeCoins.Count - 1; i >= 0; i--)
            {
                if (myPlayer.GetBounds().IntersectsWith(activeCoins[i].GetBounds()))
                {
                    if (activeCoins[i].IsGold)
                    {
                        myPlayer.Coins += 5;
                    }
                    else
                    {
                        myPlayer.Coins += 1;
                    }

                    activeCoins.RemoveAt(i);
                }
            }

            for (int i = activePowerUps.Count - 1; i >= 0; i--)
            {
                if (myPlayer.GetBounds().IntersectsWith(activePowerUps[i].GetBounds()))
                {
                    switch (activePowerUps[i].Type)
                    {
                        case PowerUpType.HealthPack:
                            myPlayer.HP++;
                                           // اینجا یه صدای خاص هم پخش بشه خوبخه
                            break;

                        case PowerUpType.Shield:
                            myPlayer.HasShield = true;
                            myPlayer.ShieldCounter = 250;
                            break;

                        case PowerUpType.TripleShot:
                            myPlayer.HasTripleShot = true;
                            myPlayer.TripleShotCounter = 500;
                            break;
                    }

                    activePowerUps.RemoveAt(i);
                }
            }
        }

        private void CheckWaveStatus()
        {
            if (waveManager.WaveCompleted)
            {
                if (waveManager.CurrentWave < 10)
                {
                    gameTimer.Stop();

                    MessageBox.Show($"Wave {waveManager.CurrentWave} Completed!");

                    System.Threading.Thread.Sleep(2000);

                    waveManager.NextWave();

                    gameTimer.Start();
                }
                else
                {
                    gameTimer.Stop();

                    UpdateHUD();

                    AudioManager.PlaySuccess();
                    AudioManager.StopMusic();

                    MessageBox.Show($"Congratulations!\nYou finished all 10 waves!\nScore: {myPlayer.Score}");

                    this.Close();
                }
            }
        }

        private void lblScore_Click(object sender, EventArgs e)
        {

        }

        private void FireBullet()
        {
            long currentTime = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
            if (currentTime - myPlayer.LastFireTime < myPlayer.FireRateDelay)
                return;

            myPlayer.LastFireTime = currentTime;

            if (myPlayer.HasTripleShot)
            {
                Bullet leftBullet = new Bullet(myPlayer.X + 10, myPlayer.Y, 10, 20, -4, -14, Properties.Resources.PlayerBullet, true);
                Bullet centerBullet = new Bullet(myPlayer.X + (myPlayer.Width / 2) - 5, myPlayer.Y - 10, 10, 20, 0, -15, Properties.Resources.PlayerBullet, true);
                Bullet rightBullet = new Bullet(myPlayer.X + myPlayer.Width - 20, myPlayer.Y, 10, 20, 4, -14, Properties.Resources.PlayerBullet, true);

                activeBullets.Add(leftBullet);
                activeBullets.Add(centerBullet);
                activeBullets.Add(rightBullet);
            }
            else
            {
                Bullet normalBullet = new Bullet(myPlayer.X + (myPlayer.Width / 2) - 5, myPlayer.Y, 10, 20, 0, -15, Properties.Resources.PlayerBullet, true);
                activeBullets.Add(normalBullet);
            }
        }
    }
}
