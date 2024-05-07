using System.Drawing;
using System.Drawing.Drawing2D;

namespace Components;

public class BtnReset : BtnBase
{
    private string text { get; set; }
    public BtnReset(float X, float Y, float width, float height, string text)
    {
        this.Rect = new RectangleF(X, Y, width, height);
        this.text = text;
    }
    public override void DrawButton(Graphics g)
    {
        Font font = new Font("Open Sans", this.Rect.Width * 0.10f);
        SizeF textSize = g.MeasureString(this.text, font);
        LinearGradientBrush gradientOrange = new LinearGradientBrush(this.Rect ,Color.FromArgb(255, 145, 77), Color.FromArgb(255, 222, 89), LinearGradientMode.Horizontal);

        ShadowRect(this.Rect);
        // DrawShadow(g);

        g.FillRectangle(gradientOrange, this.Rect);
        g.DrawString(
            this.text,
            font,
            Brushes.White,
            new PointF(
                this.Rect.X + (this.Rect.Width / 2 - textSize.Width / 2),
                this.Rect.Y + (this.Rect.Height / 2 - textSize.Height / 2)
            )
        );
    }
}
