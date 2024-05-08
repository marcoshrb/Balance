using System.Drawing;
using System.Drawing.Drawing2D;

namespace Components;

public class BtnConfirm : BtnBase
{
    private string text { get; set; }

    public BtnConfirm(float X, float Y, float width, float height, string text)
    {
        this.Hitbox = new RectangleF(X, Y, width, height);
        this.text = text;
    }

    public override void Draw(Graphics g)
    {
        Font font = new Font("Arial bold", this.Hitbox.Width * 0.12f);
        SizeF textSize = g.MeasureString(this.text, font);

        LinearGradientBrush gradientGreen = new LinearGradientBrush(this.Hitbox, Color.FromArgb(29, 123, 23), Color.FromArgb(79, 209, 52), LinearGradientMode.Horizontal);

        ShadowRect(this.Hitbox);

        g.FillRectangle(gradientGreen, this.Hitbox);
        g.DrawString(
            this.text,
            font,
            Brushes.White,
            new PointF(
                this.Hitbox.X + (this.Hitbox.Width / 2 - textSize.Width / 2),
                this.Hitbox.Y + (this.Hitbox.Height / 2 - textSize.Height / 2)
            )
        );
    }
}
