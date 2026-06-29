using Final_Ap_Project.Models;
using System;
using System.Drawing;

namespace Final_Ap_Project.Models
{
    public class Player : GameObject
    {
        public int HP { get; set; }
        public int Score { get; set; }
        public int Coins { get; set; }
        public int FireRateDelay { get; set; }
        public long LastFireTime { get; set; }
        public bool HasShield { get; set; }
        public int ShieldCounter { get; set; }
        public bool HasTripleShot { get; set; }
        public int TripleShotCounter { get; set; }

        public Player(int x, int y, int width, int height, int speed, Image image, int hp)
            : base(x, y, width, height, speed, image)
        {
            HP = hp;
            FireRateDelay = 500;
            LastFireTime = 0;
        }
        public override void Move()
        {

        }
        public override void Draw(Graphics g)
        {
            base.Draw(g);

            if (HasShield)
            {
                Pen shieldPen = new Pen(Color.Cyan, 3);
                g.DrawEllipse(shieldPen, X - 5, Y - 5, Width + 10, Height + 10);
            }
        }
        public void UpdatePowerUps()
        {
            if (HasShield)
            {
                ShieldCounter--;
                if (ShieldCounter <= 0)
                {
                    HasShield = false;
                }
            }
            if (HasTripleShot)
            {
                TripleShotCounter--;
                if (TripleShotCounter <= 0)
                {
                    HasTripleShot = false;
                }
            }
        }
    }
}