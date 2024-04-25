using System.Drawing;

namespace Entities.Shapes;

public class Star : Shape
{
    public Star(float x, float y, float width, float height, int weight)
        : base(x, y, width, height, weight, @"./imgs/pieces/Estrela.png")
    {
        // Sprite spriteCreate = new Sprite(Bitmap.FromFile(@"./imgs/pieces/Estrela.png") as Bitmap)
        // {
        //     Rect = new RectangleF(Position.X, Position.Y, width, height)
        // };
        // this.Position = new PointF(x, y);
        // this.Sprite = spriteCreate;
        this.Name = "Estrela";
    }

}
