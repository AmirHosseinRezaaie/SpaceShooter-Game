using Final_Ap_Project.Models;
using System;
using System.Drawing;

namespace Final_Ap_Project.Models
{
    public class TerroristEnemy : Enemy
    {
        private Player targetPlayer;

        public TerroristEnemy(int x, int y, int speed, Image image, Player player)
            : base(x, y, 45, 45, speed, image, hp: 10, score: 80, dropChance: 60)
        {
            targetPlayer = player;
        }

        public override void Move()
        {
            if (targetPlayer == null) return;

            double dx = targetPlayer.X - X;
            double dy = targetPlayer.Y - Y;

            double distance = Math.Sqrt(dx * dx + dy * dy);

            if (distance > 0)
            {
                X += (int)((dx / distance) * Speed);
                Y += (int)((dy / distance) * Speed);
            }
        }
    }
}