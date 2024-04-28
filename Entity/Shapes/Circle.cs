using System.Drawing;
using System.Drawing;
using Utils;

namespace Entities.Shapes;

public class Circle : Shape
{
    public Circle(float x, float y, float radius, int weight)
        : base(
            x,
            y,
            radius,
            radius,
            weight,
            ImageProcessing.ResizeImage(Resources.Circle, new Size((int)radius, (int)radius))
        )
    {
        this.Name = "Bola";
    }
}
