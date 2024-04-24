using System.Drawing;
using System.Reflection.Emit;

namespace Views;

public class InputUser
{
    public RectangleF Rect { get; set; }
    public string Text { get; set; }


    public InputUser(float X, float Y, float width, float height, string text)
    {
        this.Rect = new RectangleF(X, Y, width, height);
        this.Text = text;
    }
    public InputUser(float X, float Y, float width, float height)
    {
        this.Rect = new RectangleF(X, Y, width, height);
        this.Text = "";
    }
    public void DrawInput(Graphics g)
    {
        Font font = new Font("Arial bold", 14);
        SizeF textSize = g.MeasureString(this.Text, font);

        g.DrawRectangle(new Pen(Brushes.Black), this.Rect);
        g.DrawString(this.Text, font, Brushes.Black, new PointF(this.Rect.X, this.Rect.Y - textSize.Height * 1.5f));
    }

    public void DrawInputRect(Graphics g)
    {
        g.DrawRectangle(new Pen(Brushes.Black), this.Rect);
    }
}