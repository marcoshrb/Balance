using System.Drawing;
using Utils;

public class EmptyTriangle : FixedBalance
{
    public EmptyTriangle()
    {
        Sprite spriteCreate = new Sprite(ImageProcessing.ResizeImage(Resources.TriangleEmpty, new Size((int)(100 * ClientScreen.WidthFactor), (int)(100 * ClientScreen.WidthFactor))));
        spriteCreate.Rect = new RectangleF( position.X, position.Y, (int)(100 * ClientScreen.WidthFactor), (int)(100 * ClientScreen.WidthFactor));
        this.Sprite = spriteCreate;
        
        this.Name = "Triangulo";
    }

    public EmptyTriangle(PointF pos)
    {
        Sprite spriteCreate = new Sprite(ImageProcessing.ResizeImage(Resources.TriangleEmpty, new Size((int)(100 * ClientScreen.WidthFactor), (int)(100 * ClientScreen.WidthFactor))));
        spriteCreate.Rect = new RectangleF( position.X, position.Y, (int)(100 * ClientScreen.WidthFactor), (int)(100 * ClientScreen.WidthFactor));
        this.Sprite = spriteCreate;
        
        this.position = pos;
        this.Name = "Triangulo";
    }
}