using Final_Ap_Project.Models;
using System.Drawing;

namespace Final_Ap_Project.Models
{
    public class ShooterEnemy : Enemy
    {
        public long LastFireTime { get; set; }
        public int FireDelay { get; set; }

        public ShooterEnemy(int x, int y, int speed, Image image)
            : base(x, y, 40, 40, speed, image, hp: 3, score: 30, dropChance: 40)
        {
            LastFireTime = 0;
            FireDelay = 1500;
        }
        public override void Move()
        {
            Y += Speed;
        }
    }
}