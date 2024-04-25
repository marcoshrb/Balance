using System.Drawing;

public class Circle : Shape
{
    public Circle(float x, float y, float radius, int weight)
        : base(x, y, radius, radius, weight)
    {
        Sprite spriteCreate = new Sprite(Bitmap.FromFile(@"./imgs/pieces/Bola.png") as Bitmap)
        {
            Rect = new RectangleF(Position.X, Position.Y, radius, radius)
        };
        this.Position = new PointF(x, y);
        this.Sprite = spriteCreate;

        this.Name = "Bola";
    }
}
