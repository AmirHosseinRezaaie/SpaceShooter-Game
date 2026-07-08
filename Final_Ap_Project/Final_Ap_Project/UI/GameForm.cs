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

            this.BackgroundImage = Properties.Resources.BG_Game;
            this.BackgroundImageLayout = ImageLayout.Stretch;

            activeEnemies = new List<Enemy>();
            activeBullets = new List<Bullet>();
            activeCoins = new List<Coin>();
            activePowerUps = new List<PowerUp>();

            Image GetCurrentSkin()
            {
                switch (GameData.CurrentSkinIndex)
                {
                    case 1: return Properties.Resources.PlayerSpaceship_red;
                    case 2: return Properties.Resources.PlayerSpaceship_pink;
                    case 3: return Properties.Resources.PlayerSpaceship_green;
                    case 4: return Properties.Resources.special_skin;
                    default: return Properties.Resources.PlayerSpaceshipّSize;
                }
            }

            myPlayer = new Player(395, 440, 100, 100, 7 + GameData.ExtraSpeed, GetCurrentSkin(), 3 + GameData.ExtraHP);

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
            lblScore.Text = myPlayer.Score.ToString();
            lblCoins.Text = myPlayer.Coins.ToString();
            lblWave.Text = waveManager.CurrentWave.ToString();

            picHP1.Visible = myPlayer.HP >= 1;
            picHP2.Visible = myPlayer.HP >= 2;
            picHP3.Visible = myPlayer.HP >= 3;

            picHP4.Visible = GameData.ExtraHP >= 1 && myPlayer.HP >= 4;
            picHP5.Visible = GameData.ExtraHP >= 2 && myPlayer.HP >= 5;
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

            foreach (var coin in activeCoins)
            {
                coin.Draw(g);
            }

            foreach (var powerUp in activePowerUps)
            {
                powerUp.Draw(g);
            }

            DrawPowerUpHUD(g);

            foreach (var enemy in activeEnemies)
            {
                enemy.Draw(g);
            }

            foreach (var bullet in activeBullets)
            {
                bullet.Draw(g);
            }

            myPlayer.Draw(g);
        }

        private void DrawPowerUpHUD(Graphics g)
        {
            if (myPlayer.HasTripleShot)
            {
                g.DrawImage(Properties.Resources.Triple_fire,
                            25, 500, 45, 45);
            }

            if (myPlayer.HasShield)
            {
                g.DrawImage(Properties.Resources.Shild,
                            80, 500, 45, 45);
            }
        }

        private void GameForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
                return;
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

                                int dropChance = rnd.Next(1, 101);

                                if (dropChance <= activeEnemies[j].CoinDropChance)
                                {
                                    bool isGoldCoin = (rnd.Next(1, 101) <= 30);
                                    Coin droppedCoin = new Coin(activeEnemies[j].X, activeEnemies[j].Y, 3, isGoldCoin ? coin2Img : coinImg, isGoldCoin);
                                    activeCoins.Add(droppedCoin);
                                }
                                else if (dropChance <= 20) 
                                {
                                    Array values = Enum.GetValues(typeof(PowerUpType));
                                    PowerUpType randomType = (PowerUpType)values.GetValue(rnd.Next(values.Length));

                                    Image powerUpImg = null;

                                    switch (randomType)
                                    {
                                        case PowerUpType.HealthPack:
                                            powerUpImg = Properties.Resources.HP;
                                            break;
                                        case PowerUpType.Shield:
                                            powerUpImg = Properties.Resources.Shild;
                                            break;
                                        case PowerUpType.TripleShot:
                                            powerUpImg = Properties.Resources.Triple_fire;
                                            break;
                                    }

                                    PowerUp droppedPowerUp = new PowerUp(activeEnemies[j].X, activeEnemies[j].Y, 3, powerUpImg, randomType);
                                    activePowerUps.Add(droppedPowerUp);
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
                        ConsumeExtraHeart();

                        if (myPlayer.HP <= 0)
                        {
                            gameTimer.Stop();

                            AudioManager.StopMusic();
                            AudioManager.PlayGameOver();

                            MessageBox.Show("Game Over!");

                            if (myPlayer.Score > GameData.HighScore)
                            {
                                GameData.HighScore = myPlayer.Score;
                            }
                            DatabaseManager.SaveGame();

                            this.Close();
                            return;
                        }
                    }
                }
            }
            for (int i = activeBullets.Count - 1; i >= 0; i--)
            {
                if (!activeBullets[i].IsPlayerBullet &&
                    myPlayer.GetBounds().IntersectsWith(activeBullets[i].GetBounds()))
                {
                    int damage = activeBullets[i].Damage;

                    activeBullets.RemoveAt(i);

                    if (!myPlayer.HasShield)
                    {
                        myPlayer.HP -= damage;
                        ConsumeExtraHeart();

                        AudioManager.PlayHit();

                        if (myPlayer.HP <= 0)
                        {
                            gameTimer.Stop();

                            AudioManager.StopMusic();
                            AudioManager.PlayGameOver();

                            if (myPlayer.Score > GameData.HighScore)
                                GameData.HighScore = myPlayer.Score;

                            DatabaseManager.SaveGame();

                            MessageBox.Show("Game Over!");

                            Close();
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
                        GameData.TotalCoins += 10;
                        DatabaseManager.SaveGame();
                    }
                    else
                    {
                        myPlayer.Coins += 5;
                        GameData.TotalCoins += 5;
                        DatabaseManager.SaveGame();
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

                            int maxHP = 3 + GameData.ExtraHP;

                            if (myPlayer.HP < maxHP)
                                myPlayer.HP++;

                            AudioManager.PlayHealthPack();
                            break;

                        case PowerUpType.Shield:

                            if (!myPlayer.HasShield)
                            {
                                myPlayer.HasShield = true;
                                myPlayer.ShieldCounter = 250;
                            }

                            AudioManager.PlayHealthPack();
                            break;

                        case PowerUpType.TripleShot:

                            if (!myPlayer.HasTripleShot)
                            {
                                myPlayer.HasTripleShot = true;
                                myPlayer.TripleShotCounter = 500;
                            }

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

                    if (myPlayer.Score > GameData.HighScore)
                    {
                        GameData.HighScore = myPlayer.Score;
                    }
                    DatabaseManager.SaveGame();

                    this.Close();
                    return;
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

        private void ConsumeExtraHeart()
        {
            int normalHP = 3;

            if (myPlayer.HP >= normalHP)
            {
                int remainingExtra = myPlayer.HP - normalHP;

                if (GameData.ExtraHP != remainingExtra)
                {
                    GameData.ExtraHP = remainingExtra;

                    DatabaseManager.SaveGame();
                }
            }
            else
            {
                if (GameData.ExtraHP != 0)
                {
                    GameData.ExtraHP = 0;

                    DatabaseManager.SaveGame();
                }
            }
        }
    }
}
