using System.Drawing;

namespace Final_Ap_Project.Models
{
    public enum PowerUpType
    {
        Shield,
        TripleShot,
        HealthPack
    }

    public class PowerUp : GameObject
    {
        public PowerUpType Type { get; set; }

        public PowerUp(int x, int y, int speed, Image image, PowerUpType type)
            : base(x, y, 30, 30, speed, image) // سایز پیش‌فرض ۳۰ در ۳۰
        {
            Type = type;
        }

        public override void Move()
        {
            Y += Speed; // آیتم‌ها هم مثل سکه از بالا به پایین میان
        }
    }
}