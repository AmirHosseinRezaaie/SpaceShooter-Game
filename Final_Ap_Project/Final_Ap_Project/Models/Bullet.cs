using Final_Ap_Project.Models;
using System.Drawing;

namespace Final_Ap_Project.Models
{
    public class Bullet : GameObject
    {
        public bool IsPlayerBullet { get; set; }
        public int SpeedX { get; set; }
        public int SpeedY { get; set; }
        public float RotationAngle { get; set; }
        public int Damage { get; set; }

        public Bullet(int x, int y, int width, int height, int speedX, int speedY, Image image, bool isPlayerBullet, float rotationAngle = 0, int damage = 1)
            : base(x, y, width, height, 0, image)
        {
            SpeedX = speedX;
            SpeedY = speedY;
            IsPlayerBullet = isPlayerBullet;
            RotationAngle = rotationAngle;
            Damage = damage;
        }

        public override void Draw(Graphics g)
        {
            g.TranslateTransform(X + Width / 2, Y + Height / 2);

            g.RotateTransform(RotationAngle);

            g.DrawImage(ObjectImage, -Width / 2, -Height / 2, Width, Height);

            g.ResetTransform();
        }

        public override void Move()
        {
            X += SpeedX;
            Y += SpeedY;
        }
    }
}