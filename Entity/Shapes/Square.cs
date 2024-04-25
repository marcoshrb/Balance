namespace Entities.Shapes;

public class Square : Shape
{
    public Square(float x, float y, float width, int weight)
        : base(x, y, width, width, weight, @"./Assets/Shapes/pieces/Quadrado.png")
    {
        this.Name = "Quadrado";
    }

    public override void Update() { }
}
