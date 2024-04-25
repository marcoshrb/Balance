using System.Drawing;
using Utils;

public class Sprite
{
    Bitmap img;
    public RectangleF Rect { get; set; }
    public PointF position;

    public Sprite(string path)
        => this.img = Bitmap.FromFile(path) as Bitmap;
    public Sprite(Bitmap bmp)
    {
        this.img = bmp;
        // ImageProcessing.ResizeImage(this.img, new Size(200, 200));
    }    
    
    public void DrawSprite(Graphics g, RectangleF drawRect)
    {
        g.DrawImage(
            this.img,
            drawRect,
            this.Rect,
            GraphicsUnit.Pixel
        );
    }
}