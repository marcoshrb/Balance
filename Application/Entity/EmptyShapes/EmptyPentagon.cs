using System.Drawing;
using Utils;

namespace Entities.EmptyShapes;

public class EmptyPentagon : EmptyShape
{
    public EmptyPentagon(float width, float height)
        : base(Resources.PentagonEmpty, width, height)
    {
        this.Name = "Pentagono";
    }

    public EmptyPentagon(PointF pos, float width, float height)
        : base(Resources.PentagonEmpty, width, height)
    {
        this.Position = pos;
        this.Name = "Pentagono";
    }
}
