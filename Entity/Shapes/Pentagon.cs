using System.Drawing;

namespace Entities.Shapes;

public class Pentagon : Shape
{
    public Pentagon(float x, float y, float width, float height, int weight)
        : base(x, y, width, height, weight, @"./imgs/pieces/Pentagono.png")
    {
        // Sprite spriteCreate = new Sprite(Bitmap.FromFile(@"./imgs/pieces/Pentagono.png") as Bitmap)
        // {
        //     Rect = new RectangleF(Position.X, Position.Y, width, height)
        // };
        // this.Position = new PointF(x, y);
        // this.Sprite = spriteCreate;

        this.Name = "Pentagono";
    }
}
