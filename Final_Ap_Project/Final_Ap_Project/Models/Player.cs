using Final_Ap_Project.Models;
using System;
using System.Drawing;

namespace Final_Ap_Project.Models
{
    public class Player : GameObject
    {
        public int HP { get; set; }
        public int Score { get; set; }
        public int Coins { get; set; }
        public int FireRateDelay { get; set; }
        public long LastFireTime { get; set; }

        public Player(int x, int y, int width, int height, int speed, Image image, int hp)
            : base(x, y, width, height, speed, image)
        {
            HP = hp;
            FireRateDelay = 200;
            LastFireTime = 0;
        }
        public override void Move()
        {

        }
        public override void Draw(Graphics g)
        {
            base.Draw(g);



        }
    }
}