using Final_Ap_Project.Models;
using System.Drawing;

namespace Final_Ap_Project.Models
{
    public class StandardEnemy : Enemy
    {
        public StandardEnemy(int x, int y, int speed, Image image)
            : base(x, y, 40, 40, speed, image, hp: 1, score: 10, dropChance: 20)
        {
        }
        public override void Move()
        {
            Y += Speed;
        }
    }
}