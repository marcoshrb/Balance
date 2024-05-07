using System.Drawing;
using System.Drawing.Drawing2D;

namespace Components;

public class BtnConfirm : BtnBase
{
    private string text { get; set; }

    public BtnConfirm(float X, float Y, float width, float height, string text)
    {
        this.Rect = new RectangleF(X, Y, width, height);
        this.text = text;
    }

    public override void DrawButton(Graphics g)
    {
        Font font = new Font("Arial bold", this.Rect.Width * 0.10f);
        SizeF textSize = g.MeasureString(this.text, font);
        LinearGradientBrush gradientGreen = new LinearGradientBrush(this.Rect, Color.FromArgb(29, 123, 23), Color.FromArgb(79, 209, 52), LinearGradientMode.Horizontal);
        
        ShadowRect(this.Rect);
        // DrawShadow(g);

        g.FillRectangle(gradientGreen, this.Rect);
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
