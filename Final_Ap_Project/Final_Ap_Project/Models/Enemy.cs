using Final_Ap_Project.Models;
using System.Drawing;

namespace Final_Ap_Project.Models
{
    public abstract class Enemy : GameObject
    {
        public int HP { get; set; }
        public int ScoreValue { get; set; }
        public int CoinDropChance { get; set; }

        public Enemy(int x, int y, int width, int height, int speed, Image image, int hp, int score, int dropChance)
            : base(x, y, width, height, speed, image)
        {
            HP = hp;
            ScoreValue = score;
            CoinDropChance = dropChance;
        }
    }
}