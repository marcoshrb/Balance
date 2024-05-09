using System.Drawing;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Utils;

namespace Components;

public class InputUser
{
    public RectangleF Rect { get; set; }
    public string Title { get; set; }
    public string Content { get; set; } = "";
    public Bitmap Bmp { get; set; }
    public bool IsTyping { get; set; } = false;
    public bool Disable { get; set; } = false;

    public InputUser(float X, float Y, float width, float height, string text)
    {
        this.Rect = new RectangleF(X, Y, width, height);
        this.Title = text;
    }

    public InputUser(float X, float Y, float width, float height)
    {
        this.Rect = new RectangleF(X, Y, width, height);
    }

    public InputUser(float X, float Y, float width, float height, Bitmap bmp)
    {
        this.Rect = new RectangleF(X, Y, width, height);
        this.Bmp = bmp;
    }

    public void DrawInputRect(Graphics g)
    {
        g.DrawRectangle(new Pen(Brushes.Black), this.Rect);
    }

    public void DrawInput(Graphics g)
    {
        Font font = new Font("Arial bold", ClientScreen.WidthFactor * 14);
        SizeF textSize = g.MeasureString(this.Title, font);

        float textY = this.Rect.Y + (this.Rect.Height - textSize.Height) / 2;
        float textX = this.Rect.X + (this.Rect.Width - textSize.Width) / 2;

        g.DrawRectangle(new Pen(Brushes.Black), this.Rect);
        g.DrawString(this.Title, font, Brushes.Black, new PointF(textX, textY));
    }

    public void DrawInputSprite(Graphics g, PictureBox pb)
    {
        if (this.Bmp != null)
        {
            float imageX = Rect.X - 100 * ClientScreen.WidthFactor;
            float imageY = this.Rect.Y + (this.Rect.Height - ClientScreen.HeightFactor * 80) / 2;

            g.DrawImage(
                this.Bmp,
                new RectangleF(
                    imageX,
                    imageY,
                    ClientScreen.WidthFactor * 80,
                    ClientScreen.HeightFactor * 80
                )
            );
        }

        g.DrawRectangle(new Pen(Brushes.Black), this.Rect);
        if (!this.IsTyping)
        {
            Font font = new Font("Arial", ClientScreen.WidthFactor * 32);
            SizeF textSize = g.MeasureString(this.Content, font);
            float textY = this.Rect.Y + (this.Rect.Height - textSize.Height) / 2;
            g.DrawString(this.Content, font, Brushes.Black, new PointF(this.Rect.X, textY));
        }
    }

    public void Select() { }
}
