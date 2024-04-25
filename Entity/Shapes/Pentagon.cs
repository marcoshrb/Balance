using System.Drawing;
using Utils;

namespace Entities.Shapes;

public class Pentagon : Shape
{
    public Pentagon(float x, float y, float width, float height, int weight)
        : base(x, y, width, height, weight, ImageProcessing.ResizeImage(Resources.Pentagon, new Size((int)width, (int)height)))
    {
        this.Name = "Pentagono";
    }
}
