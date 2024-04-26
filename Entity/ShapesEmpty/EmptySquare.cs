using System.Drawing;
using Utils;

public class EmptySquare : FixedBalance
{
    public EmptySquare()
    {
        Sprite spriteCreate = new Sprite(ImageProcessing.ResizeImage(Resources.SquareEmpty, new Size((int)(100 * ClientScreen.WidthFactor), (int)(100 * ClientScreen.WidthFactor))));
        spriteCreate.Rect = new RectangleF( position.X, position.Y, (int)(100 * ClientScreen.WidthFactor), (int)(100 * ClientScreen.WidthFactor));
        this.Sprite = spriteCreate;

        this.Name = "Quadrado";
    }

    public EmptySquare(PointF pos)
    {
        Sprite spriteCreate = new Sprite(ImageProcessing.ResizeImage(Resources.SquareEmpty, new Size((int)(100 * ClientScreen.WidthFactor), (int)(100 * ClientScreen.WidthFactor))));
        spriteCreate.Rect = new RectangleF( position.X, position.Y, (int)(100 * ClientScreen.WidthFactor), (int)(100 * ClientScreen.WidthFactor));
        this.Sprite = spriteCreate;

        this.position = pos;
        this.Name = "Quadrado";
    }
}