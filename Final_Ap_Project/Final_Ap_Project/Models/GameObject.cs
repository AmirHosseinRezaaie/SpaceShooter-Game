using System.Drawing;

namespace Final_Ap_Project.Models
{
    public abstract class GameObject
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int Speed { get; set; }
        public Image ObjectImage { get; set; }

        public GameObject(int x, int y, int width, int height, int speed, Image image)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
            Speed = speed;
            ObjectImage = image;
        }
        public virtual void Draw(Graphics g)
        {
            if (ObjectImage != null)
            {
                g.DrawImage(ObjectImage, X, Y, Width, Height);
            }
        }
        public abstract void Move();
        public Rectangle GetBounds()
        {
            return new Rectangle(X, Y, Width, Height);
        }
    }
}