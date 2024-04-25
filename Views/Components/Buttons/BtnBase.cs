using System.Drawing;

namespace Views.Components;

public abstract class BtnBase
{
    public PointF? Location { get; set; }

    public virtual void DrawButton (Graphics g) { }
}