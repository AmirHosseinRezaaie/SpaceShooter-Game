using Final_Ap_Project.Models;
using System.Drawing;

namespace Final_Ap_Project.Models
{
    public class HeavyTankEnemy : Enemy
    {
        public long LastFireTime { get; set; }
        public int FireDelay { get; set; }

        public HeavyTankEnemy(int x, int y, int speed, Image image)
            : base(x, y, 80, 80, speed, image, hp: 15, score: 100, dropChance: 80)
        {
            LastFireTime = 0;
            FireDelay = 3500;
        }
        public override void Move()
        {
            Y += Speed;
        }
    }
}