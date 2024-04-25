using System.Drawing;

namespace Entities.Shapes;


public class Triangle : Shape
{
    public Triangle(float x, float y, float width, float height, int weight)
        : base(x, y, width, height, weight, @"./imgs/pieces/Triangulo.png")
    {
        // Sprite spriteCreate = new Sprite(Bitmap.FromFile(@"./imgs/pieces/Triangulo.png") as Bitmap)
        // {
        //     Rect = new RectangleF(Position.X, Position.Y, width, height)
        // };
        // this.Position = new PointF(x, y);
        // this.Sprite = spriteCreate;
        this.Name = "Triangulo";
    }
}