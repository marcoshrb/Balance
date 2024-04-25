using System.Drawing;
using Utils;

public class EmptySquare : FixedBalance
{
    public EmptySquare()
    {
        Sprite spriteCreate = new Sprite(ImageProcessing.ResizeImage(Resources.Square, new Size(80, 80)));
        spriteCreate.Rect = new RectangleF( position.X, position.Y, 80, 80);
        this.Sprite = spriteCreate;

        this.Name = "Quadrado";
    }
}