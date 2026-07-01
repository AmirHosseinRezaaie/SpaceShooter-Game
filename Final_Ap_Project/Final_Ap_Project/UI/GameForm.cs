using Final_Ap_Project.Data;
using Final_Ap_Project.Managers;
using Final_Ap_Project.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        private System.Windows.Forms.Timer waveDelayTimer;
        private Random rnd = new Random();

        private WaveManager waveManager;

        private Image playerBulletImg = Properties.Resources.PlayerBullet;
        private Image enemyBulletImg = Properties.Resources.EnemyBullet;
        private Image coinImg = Properties.Resources.Coin;
        private Image coin2Img = Properties.Resources.Coin2;

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

            myPlayer = new Player(425, 500, 100, 80, 7 + GameData.ExtraSpeed, Properties.Resources.PlayerSpaceship1, 3 + GameData.ExtraHP);

            int currentFireRate = 200 - (GameData.FireRateLevel * 50);
            myPlayer.FireRateDelay = currentFireRate;

            gameTimer = new System.Windows.Forms.Timer();
            gameTimer.Interval = 20;
            gameTimer.Tick += GameLoop;

            waveDelayTimer = new System.Windows.Forms.Timer();
            waveDelayTimer.Interval = 2000;
            waveDelayTimer.Tick += WaveDelayTimer_Tick;

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
                if (activeBullets[i].Y < -30 || activeBullets[i].Y > 630 || activeBullets[i].X < -30 || activeBullets[i].X > 930)
                {
                    activeBullets.RemoveAt(i);
                }
            }

            for (int i = activeEnemies.Count - 1; i >= 0; i--)
            {
                activeEnemies[i].Move();

                if (activeEnemies[i] is ShooterEnemy shooter)
                {
                    long currentTime = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;

                    if (currentTime - shooter.LastFireTime >= shooter.FireDelay)
                    {
                        shooter.LastFireTime = currentTime;
                        FireEnemyBullet(shooter);
                    }
                }

                if (activeEnemies[i] is HeavyTankEnemy tank)
                {
                    long currentTime = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;

                    if (currentTime - tank.LastFireTime >= tank.FireDelay)
                    {
                        tank.LastFireTime = currentTime;
                        FireHeavyTankBullets(tank);
                    }
                }

                if (activeEnemies[i].Y > this.ClientSize.Height)
                {
                    activeEnemies.RemoveAt(i);
                }
            }
            for (int i = activePowerUps.Count - 1; i >= 0; i--)
            {
                activePowerUps[i].Move();
                if (activePowerUps[i].Y > this.ClientSize.Height)
                {
                    activePowerUps.RemoveAt(i);
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
            foreach (var powerUp in activePowerUps)
            {
                powerUp.Draw(g);
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


                            if (activeEnemies[j].HP <= 0)
                            {
                                myPlayer.Score += activeEnemies[j].ScoreValue;

                                if (rnd.Next(1, 101) <= activeEnemies[j].CoinDropChance)
                                {
                                    bool isGoldCoin = (rnd.Next(1, 101) <= 20);

                                    Coin droppedCoin = new Coin(activeEnemies[j].X, activeEnemies[j].Y, 3, isGoldCoin ? coin2Img : coinImg, isGoldCoin);

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
                            gameTimer.Stop();

                            AudioManager.StopMusic();
                            AudioManager.PlayGameOver();
                            
                            GameData.TotalCoins += myPlayer.Coins;
                            
                            MessageBox.Show("Game Over!");
                            
                            this.Close();
                            return;
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
                        myPlayer.HP -= activeBullets[i].Damage;

                        AudioManager.PlayHit();

                        if (myPlayer.HP <= 0)
                        {
                            gameTimer.Stop();

                            AudioManager.StopMusic();
                            AudioManager.PlayGameOver();
                            
                            GameData.TotalCoins += myPlayer.Coins;
                            
                            MessageBox.Show("Game Over!");
                            
                            this.Close();
                            return;
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
                        myPlayer.Coins += 10;
                    }
                    else
                    {
                        myPlayer.Coins += 5;
                    }
                    AudioManager.PlayCoin();
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
                            AudioManager.PlayHealthPack();
                            break;

                        case PowerUpType.Shield:
                            myPlayer.HasShield = true;
                            myPlayer.ShieldCounter = 250;
                            AudioManager.PlayHealthPack();
                            break;

                        case PowerUpType.TripleShot:
                            myPlayer.HasTripleShot = true;
                            myPlayer.TripleShotCounter = 500;
                            AudioManager.PlayHealthPack();
                            break;
                    }

                    activePowerUps.RemoveAt(i);
                }
            }
        }

        private void CheckWaveStatus()
        {
            if (myPlayer.HP <= 0) return;
            if (waveManager.WaveCompleted)
            {
                if (waveManager.CurrentWave < 10)
                {
                    gameTimer.Stop();

                    AudioManager.PlaySuccess();

                    MessageBox.Show($"Wave {waveManager.CurrentWave} Completed!");

                    waveDelayTimer.Start();
                }
                else
                {
                    gameTimer.Stop();

                    UpdateHUD();

                    AudioManager.StopMusic();

                    AudioManager.PlayScore();

                    MessageBox.Show($"Congratulations!\nYou finished all 10 waves!\nScore: {myPlayer.Score}");

                    this.Close();
                }
            }
        }
        private void WaveDelayTimer_Tick(object sender, EventArgs e)
        {
            waveDelayTimer.Stop();
            AudioManager.PlayBackgroundMusic();
            waveManager.NextWave();
            gameTimer.Start();
        }

        private void lblScore_Click(object sender, EventArgs e)
        {

        }

        private void FireBullet()
        {
            long currentTime = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
            if (currentTime - myPlayer.LastFireTime < myPlayer.FireRateDelay) return;

            myPlayer.LastFireTime = currentTime;

            if (myPlayer.HasTripleShot)
            {
                Bullet leftBullet = new Bullet(myPlayer.X + 10, myPlayer.Y, 10, 20, -4, -14, playerBulletImg, true);
                Bullet centerBullet = new Bullet(myPlayer.X + (myPlayer.Width / 2) - 5, myPlayer.Y - 10, 10, 20, 0, -15, playerBulletImg, true);
                Bullet rightBullet = new Bullet(myPlayer.X + myPlayer.Width - 20, myPlayer.Y, 10, 20, 4, -14, playerBulletImg, true);

                activeBullets.Add(leftBullet);
                activeBullets.Add(centerBullet);
                activeBullets.Add(rightBullet);
            }
            else
            {
                Bullet normalBullet = new Bullet(myPlayer.X + (myPlayer.Width / 2) - 5, myPlayer.Y, 10, 20, 0, -15, playerBulletImg, true);
                activeBullets.Add(normalBullet);
            }
        }

        private void FireEnemyBullet(ShooterEnemy enemy)
        {
            Bullet bullet = new Bullet(enemy.X + enemy.Width / 2 - 5, enemy.Y + enemy.Height, 12, 24, 0, 8, enemyBulletImg, false);

            activeBullets.Add(bullet);
        }

        private void FireHeavyTankBullets(HeavyTankEnemy enemy)
        {
            int centerX = enemy.X + enemy.Width / 2 - 5;
            int centerY = enemy.Y + enemy.Height / 2 - 5;

            int speed = 3;

            activeBullets.Add(new Bullet(centerX, centerY, 16, 32, 0, -speed, enemyBulletImg, false, 180, 2));       // بالا
            activeBullets.Add(new Bullet(centerX, centerY, 16, 32, speed, 0, enemyBulletImg, false, 270, 2));        // راست
            activeBullets.Add(new Bullet(centerX, centerY, 16, 32, 0, speed, enemyBulletImg, false, 0, 2));        // پایین
            activeBullets.Add(new Bullet(centerX, centerY, 16, 32, -speed, 0, enemyBulletImg, false, 90, 2));       // چپ

            activeBullets.Add(new Bullet(centerX, centerY, 16, 32, speed, speed, enemyBulletImg, false, 315, 2));    // پایین راست
            activeBullets.Add(new Bullet(centerX, centerY, 16, 32, -speed, speed, enemyBulletImg, false, 45, 2));   // پایین چپ
            activeBullets.Add(new Bullet(centerX, centerY, 16, 32, speed, -speed, enemyBulletImg, false, 225, 2));   // بالا راست
            activeBullets.Add(new Bullet(centerX, centerY, 16, 32, -speed, -speed, enemyBulletImg, false, 135, 2));  // بالا چپ
        }

        private void GameForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            gameTimer.Stop();
            waveDelayTimer.Stop();

            gameTimer.Tick -= GameLoop;
            waveDelayTimer.Tick -= WaveDelayTimer_Tick;

            AudioManager.StopMusic();
        }
    }
}
