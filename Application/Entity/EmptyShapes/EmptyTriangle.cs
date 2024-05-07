using System.Drawing;
using Utils;

namespace Entities.EmptyShapes;

public class EmptyTriangle : EmptyShape
{
    public EmptyTriangle(float width, float height)
        : base(Resources.TriangleEmpty, width, height)
    {
        this.Name = "Triangulo";
    }

    public EmptyTriangle(PointF pos, float width, float height)
        : base(Resources.TriangleEmpty, width, height)
    {
        this.Location = pos;
        this.Name = "Triangulo";
    }
}
