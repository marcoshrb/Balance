namespace Entities.Shapes;


public class Triangle : Shape
{
    public Triangle(float x, float y, float width, float height, int weight)
        : base(x, y, width, height, weight, @"./Assets/Shapes/pieces/Triangulo.png")
    {
        this.Name = "Triangulo";
    }
}
