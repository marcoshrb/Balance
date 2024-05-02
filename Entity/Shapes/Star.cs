using System.Drawing;
using Utils;

namespace Entities.Shapes;

public class Star : Shape
{
    public Star(float x, float y, float width, float height, int weight)
        : base(
            x,
            y,
            width,
            height,
            weight,
            ImageProcessing.ResizeImage(Resources.Star, new Size((int)width, (int)height))
        )
    {
        this.Name = "Estrela";
    }

    public override object Clone()
        => new Star(this.X, this.Y, this.Width, this.Height, this.Weight);
}
