using Final_Ap_Project.Models;
using System.Drawing;

namespace Final_Ap_Project.Models
{
    public class Bullet : GameObject
    {
        public bool IsPlayerBullet { get; set; }
        public int SpeedX { get; set; }
        public int SpeedY { get; set; }

        public Bullet(int x, int y, int width, int height, int speedX, int speedY, Image image, bool isPlayerBullet)
            : base(x, y, width, height, 0, image)
        {
            SpeedX = speedX;
            SpeedY = speedY;
            IsPlayerBullet = isPlayerBullet;
        }

        public override void Move()
        {
            X += SpeedX;
            Y += SpeedY;
        }
    }
}