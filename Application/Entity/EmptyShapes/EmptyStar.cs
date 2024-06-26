using System.Drawing;
using Utils;

namespace Entities.EmptyShapes;

public class EmptyStar : EmptyShape
{
    public EmptyStar(float width, float height)
        : base(Resources.StarEmpty, width, height)
    {
        this.Name = "Estrela";
    }

    public EmptyStar(PointF pos, float width, float height)
        : base(Resources.StarEmpty, width, height)
    {
        this.Location = pos;
        this.Name = "Estrela";
    }
}
