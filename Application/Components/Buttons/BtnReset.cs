using System.Drawing;
using System.Drawing.Drawing2D;

namespace Components;

public class BtnReset : BtnBase
{
    private string text { get; set; }
    public BtnReset(float X, float Y, float width, float height, string text)
    {
        this.Hitbox = new RectangleF(X, Y, width, height);
        this.text = text;
    }
    public override void Draw(Graphics g)
    {
        Font font = new Font("Arial bold", this.Hitbox.Width * 0.12f);
        SizeF textSize = g.MeasureString(this.text, font);

        LinearGradientBrush gradientOrange = new LinearGradientBrush(this.Hitbox ,Color.FromArgb(255, 145, 77), Color.FromArgb(255, 222, 89), LinearGradientMode.Horizontal);

        ShadowRect(this.Hitbox);

        g.FillRectangle(gradientOrange, this.Hitbox);
        g.DrawString(
            this.text,
            font,
            Brushes.Black,
            new PointF(
                this.Hitbox.X + (this.Hitbox.Width / 2 - textSize.Width / 2),
                this.Hitbox.Y + (this.Hitbox.Height / 2 - textSize.Height / 2)
            )
        );
    }
}
