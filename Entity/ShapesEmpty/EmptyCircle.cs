using System.Drawing;
using Utils;
public class EmptyCircle : FixedBalance
{
    public EmptyCircle()
    {
        Sprite spriteCreate = new Sprite(ImageProcessing.ResizeImage(Resources.CircleEmpty, new Size((int)(100 * ClientScreen.WidthFactor), (int)(100 * ClientScreen.WidthFactor))));
        spriteCreate.Rect = new RectangleF( position.X, position.Y, (int)(100 * ClientScreen.WidthFactor), (int)(100 * ClientScreen.WidthFactor));
        this.Sprite = spriteCreate;
        
        this.Name = "Bola";
    }

    public EmptyCircle(PointF pos)
    {
        Sprite spriteCreate = new Sprite(ImageProcessing.ResizeImage(Resources.CircleEmpty, new Size((int)(100 * ClientScreen.WidthFactor), (int)(100 * ClientScreen.WidthFactor))));
        spriteCreate.Rect = new RectangleF( position.X, position.Y, (int)(100 * ClientScreen.WidthFactor), (int)(100 * ClientScreen.WidthFactor));
        this.Sprite = spriteCreate;
        
        this.position = pos;
        this.Name = "Bola";
    }
}