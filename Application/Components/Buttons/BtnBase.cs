using System.Drawing;

namespace Components;

public abstract class BtnBase
{
    public RectangleF Rect { get; set; }
    public RectangleF RectShadow = new RectangleF(0, 0, 0, 0);
    public PointF? Location { get; set; }

    public virtual void DrawButton(Graphics g) { }
    public virtual void FinishChallenge() { }
    public void DrawShadow(Graphics g)
    {
        Color semiTransparentColor = Color.FromArgb(128, Color.Black);
        Brush semiTransparentBrush = new SolidBrush(semiTransparentColor);
        g.FillRectangle(semiTransparentBrush, RectShadow);
    }
    protected void ShadowRect(RectangleF rect)
    {
        RectShadow = rect;

        this.RectShadow.X = (int)rect.X;
        this.RectShadow.Y = (int)rect.Y;
        this.RectShadow.Width = (int)rect.Width + 6;
        this.RectShadow.Height = (int)rect.Height + 6;
    }
}
