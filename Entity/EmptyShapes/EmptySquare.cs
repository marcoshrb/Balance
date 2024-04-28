using System.Drawing;
using Utils;

namespace Entities.EmptyShapes;

public class EmptySquare : EmptyShape
{
    public EmptySquare(float width, float height)
        : base(Resources.CircleEmpty, width, height)
    {
        this.Name = "Quadrado";
    }

    public EmptySquare(PointF pos, float width, float height)
        : base(Resources.SquareEmpty, width, height)
    {
        this.Position = pos;
        this.Name = "Quadrado";
    }
}
