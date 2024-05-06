using System.Drawing;
using Utils;

namespace Entities.EmptyShapes;

public class EmptyCircle : EmptyShape
{
    public EmptyCircle(float width, float height)
        : base(Resources.CircleEmpty, width, height)
    {
        this.Name = "Bola";
    }

    public EmptyCircle(PointF pos, float width, float height)
        : base(Resources.CircleEmpty, width, height)
    {
        this.Position = pos;
        this.Name = "Bola";
    }
}
