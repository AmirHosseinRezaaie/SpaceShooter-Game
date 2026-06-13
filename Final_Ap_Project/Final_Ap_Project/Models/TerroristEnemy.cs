using Final_Ap_Project.Models;
using System.Drawing;

namespace Final_Ap_Project.Models
{
    public class TerroristEnemy : Enemy
    {
        public TerroristEnemy(int x, int y, int speed, Image image)
            : base(x, y, 45, 45, speed, image, hp: 10, score: 80, dropChance: 60)
        {
        }

        public override void Move()
        {
        }
    }
}