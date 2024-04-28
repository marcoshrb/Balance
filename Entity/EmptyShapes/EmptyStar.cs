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
        : base(Resources.Star, width, height)
    {
        this.Position = pos;
        this.Name = "Estrela";
    }
}
