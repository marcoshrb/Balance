using System.Drawing;

public class Sprite
{
    public Bitmap Img;
    public RectangleF Rect { get; set; }
    public PointF position;

    public Sprite(string path)
        => this.Img = Bitmap.FromFile(path) as Bitmap;
    public Sprite(Bitmap bmp)
        => this.Img = bmp;
    
    public void DrawSprite(Graphics g, RectangleF drawRect)
    {
        g.DrawImage(
            this.Img,
            drawRect,
            this.Rect,
            GraphicsUnit.Pixel
        );
    }
}