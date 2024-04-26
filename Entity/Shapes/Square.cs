using System.Drawing;
using Utils;

namespace Entities.Shapes;

public class Square : Shape
{
    public Square(float x, float y, float width, int weight)
        : base(x, y, width, width, weight, ImageProcessing.ResizeImage(Resources.Square, new Size((int)width, (int)width)))
    {
        this.Name = "Quadrado";
    }

    public override void Update() { }
}
