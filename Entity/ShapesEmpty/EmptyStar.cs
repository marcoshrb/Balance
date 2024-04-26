using System.Drawing;
using Utils;

public class EmptyStar : FixedBalance
{
    public EmptyStar()
    {
        Sprite spriteCreate = new Sprite(ImageProcessing.ResizeImage(Resources.StarEmpty, new Size((int)(100 * ClientScreen.WidthFactor), (int)(100 * ClientScreen.WidthFactor))));
        spriteCreate.Rect = new RectangleF( position.X, position.Y, (int)(100 * ClientScreen.WidthFactor), (int)(100 * ClientScreen.WidthFactor));
        this.Sprite = spriteCreate;
        
        this.Name = "Estrela";
    }

    public EmptyStar(PointF pos)
    {
        Sprite spriteCreate = new Sprite(ImageProcessing.ResizeImage(Resources.StarEmpty, new Size((int)(100 * ClientScreen.WidthFactor), (int)(100 * ClientScreen.WidthFactor))));
        spriteCreate.Rect = new RectangleF( position.X, position.Y, (int)(100 * ClientScreen.WidthFactor), (int)(100 * ClientScreen.WidthFactor));
        this.Sprite = spriteCreate;

        this.position = pos;        
        this.Name = "Estrela";
    }
}