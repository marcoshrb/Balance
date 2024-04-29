using System.Drawing;

namespace Views.Components;

public class BtnReset : BtnBase
{
    public RectangleF Rect { get; set; }
    private string text { get; set; }

    public BtnReset(float X, float Y, float width, float height, string text)
    {
        this.Rect = new RectangleF(X, Y, width, height);
        this.text = text;
    }

    public override void DrawButton(Graphics g)
    {
        Font font = new Font("Arial bold", this.Rect.Width * 0.12f);
        SizeF textSize = g.MeasureString(this.text, font);

        g.FillRectangle(Brushes.Orange, this.Rect);
        g.DrawString(
            this.text,
            font,
            Brushes.Black,
            new PointF(
                this.Rect.X + (this.Rect.Width / 2 - textSize.Width / 2),
                this.Rect.Y + (this.Rect.Height / 2 - textSize.Height / 2)
            )
        );
    }
}
