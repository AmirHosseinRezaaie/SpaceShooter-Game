using System.Drawing;

namespace Final_Ap_Project.Models
{
    public class Coin : GameObject
    {
        public bool IsGold { get; set; }

        public Coin(int x, int y, int speed, Image image, bool isGold)
            : base(x, y, 20, 20, speed, image)
        {
            IsGold = isGold;
        }

        public override void Move()
        {
            Y += Speed;
        }
    }
}