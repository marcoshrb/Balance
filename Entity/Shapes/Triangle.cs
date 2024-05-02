using System.Drawing;
using Utils;

namespace Entities.Shapes;

public class Triangle : Shape
{
    public Triangle(float x, float y, float width, float height, int weight)
        : base(
            x,
            y,
            width,
            height,
            weight,
            ImageProcessing.ResizeImage(Resources.Triangle, new Size((int)width, (int)height))
        )
    {
        this.Name = "Triangulo";
    }

    public override object Clone()
        => new Triangle(this.X, this.Y, this.Width, this.Height, this.Weight);
}
