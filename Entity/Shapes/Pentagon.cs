using System.Drawing;

namespace Entities.Shapes;

public class Pentagon : Shape
{
    public Pentagon(float x, float y, float width, float height, int weight)
        : base(x, y, width, height, weight, @"./Assets/Shapes/pieces/Pentagono.png")
    {
        this.Name = "Pentagono";
    }
}
