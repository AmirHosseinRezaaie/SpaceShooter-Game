using Final_Ap_Project.Models;
using System;
using System.Drawing;

namespace Final_Ap_Project.Models
{
    public class ScoutEnemy : Enemy
    {
        private int startX;
        public ScoutEnemy(int x, int y, int speed, Image image)
            : base(x, y, 40, 40, speed, image, hp: 1, score: 20, dropChance: 30)
        {
            startX = x;
        }

        public override void Move()
        {
            Y += Speed;
            X = startX + (int)(Math.Sin(Y / 20.0) * 50);
        }
    }
}