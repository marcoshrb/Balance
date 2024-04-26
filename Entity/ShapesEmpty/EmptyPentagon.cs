using System.Drawing;
using Utils;

public class EmptyPentagon : FixedBalance
{
    public EmptyPentagon()
    {
        Sprite spriteCreate = new Sprite(ImageProcessing.ResizeImage(Resources.PentagonEmpty, new Size((int)(100 * ClientScreen.WidthFactor), (int)(100 * ClientScreen.WidthFactor))));
        spriteCreate.Rect = new RectangleF( position.X, position.Y, (int)(100 * ClientScreen.WidthFactor), (int)(100 * ClientScreen.WidthFactor));
        this.Sprite = spriteCreate;
        
        this.Name = "Pentagono";
    }
    public EmptyPentagon(PointF pos)
    {
        Sprite spriteCreate = new Sprite(ImageProcessing.ResizeImage(Resources.PentagonEmpty, new Size((int)(100 * ClientScreen.WidthFactor), (int)(100 * ClientScreen.WidthFactor))));
        spriteCreate.Rect = new RectangleF( position.X, position.Y, (int)(100 * ClientScreen.WidthFactor), (int)(100 * ClientScreen.WidthFactor));
        this.Sprite = spriteCreate;
        
        this.position = pos;
        this.Name = "Pentagono";
    }
}