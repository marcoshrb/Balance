using System.Drawing;

namespace Entities.Shapes;

public class Star : Shape
{
    public Star(float x, float y, float width, float height, int weight)
        : base(x, y, width, height, weight, @"./Assets/Shapes/pieces/Estrela.png")
    {
        this.Name = "Estrela";
    }

}
