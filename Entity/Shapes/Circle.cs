using System.Drawing;

namespace Entities.Shapes;

public class Circle : Shape
{
    public Circle(float x, float y, float radius, int weight)
        : base(x, y, radius, radius, weight, @"./Assets/Shapes/pieces/Bola.png")
    {
        this.Name = "Bola";
    }
}
