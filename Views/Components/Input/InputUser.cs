using System.Drawing;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace Views;

public class InputUser
{
    public RectangleF Rect { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
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
    public void DrawInput(Graphics g)
    {
        Font font = new Font("Arial bold", 14);
        SizeF textSize = g.MeasureString(this.Title, font);

        g.DrawRectangle(new Pen(Brushes.Black), this.Rect);
        g.DrawString(this.Title, font, Brushes.Black, new PointF(this.Rect.X, this.Rect.Y - textSize.Height * 1.5f));
    }

    public void DrawInputRect(Graphics g)
    {
        g.DrawRectangle(new Pen(Brushes.Black), this.Rect);
    }

    public void DrawInputSprite(Graphics g, PictureBox pb)
    {
        g.DrawImage(this.Bmp, new RectangleF(Rect.X - this.Bmp.Width*0.6f, Rect.Y, pb.Width*0.0208f, pb.Width*0.0208f));
        g.DrawRectangle(new Pen(Brushes.Black), this.Rect);
        Brush brush = Brushes.Black;
        SolidBrush white = new SolidBrush(Color.FromArgb(250, 249, 246));
        Font font = new Font("Arial", pb.Width*0.0125f);
        if(!this.IsTyping)
            g.DrawString(this.Content, font, brush, this.Rect);
    }
}