using System.Drawing;

namespace Components;

public abstract class BtnBase
{
    public PointF? Location { get; set; }

    public virtual void DrawButton(Graphics g) { }
    public virtual void FinishChallenge() { }
}
