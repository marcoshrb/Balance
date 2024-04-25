using System.Drawing;

namespace Entities.Shapes;

public class Square : Shape
{
    public Square(float x, float y, float width, int weight)
        : base(x, y, width, width, weight, @"./imgs/pieces/Quadrado.png")
    {
        // Sprite spriteCreate = new Sprite(Bitmap.FromFile(@"./imgs/pieces/Quadrado.png") as Bitmap)
        // {
        //     Rect = new RectangleF(Position.X, Position.Y, width, width)
        // };
        // this.Position = new PointF(x, y);
        // this.Sprite = spriteCreate;
        this.Name = "Quadrado";
    }

    public override void Update() { }
}
