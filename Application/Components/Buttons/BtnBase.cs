using System.Drawing;
using Utils;

namespace Components;

public abstract class BtnBase
{
    public RectangleF Hitbox { get; set; }
    public RectangleF Shadow = new RectangleF(0, 0, 0, 0);
    public PointF? Location { get; set; }
    

    public virtual void Draw(Graphics g) { }
    public virtual void FinishChallenge() { }
    public void DrawShadow(Graphics g)
    {
        Color semiTransparentColor = Color.FromArgb(128, Color.Black);
        Brush semiTransparentBrush = new SolidBrush(semiTransparentColor);
        g.FillRectangle(semiTransparentBrush, Shadow);
    }
    protected void ShadowRect(RectangleF rect)
    {
        Shadow = rect;

        this.Shadow.X = rect.X;
        this.Shadow.Y = rect.Y;
        this.Shadow.Width = rect.Width + 6 * ClientScreen.WidthFactor;
        this.Shadow.Height = rect.Height + 6 * ClientScreen.HeightFactor;
    }
}
