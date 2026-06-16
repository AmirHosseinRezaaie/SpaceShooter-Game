using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Final_Ap_Project.Models;

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
        private Player myPlayer;
        private System.Windows.Forms.Timer gameTimer;

        public GameForm()
        {
            InitializeComponent();

            //this.Icon = Properties.Resources.SpaceShooterIcon;

            this.DoubleBuffered = true;

            activeEnemies = new List<Enemy>();
            activeBullets = new List<Bullet>();

            myPlayer = new Player(350, 450, 50, 50, 5, null, 3);

            gameTimer = new System.Windows.Forms.Timer();
            gameTimer.Interval = 20;
            gameTimer.Tick += GameLoop;
            gameTimer.Start();
        }
        private void GameLoop(object sender, EventArgs e)
        {
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

            this.Invalidate();
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
                                // TODO: putting Score to Player & drop down coin 

                                activeEnemies.RemoveAt(j);
                            }
                            break;
                        }
                    }
                }
            }
        }
    }
}
