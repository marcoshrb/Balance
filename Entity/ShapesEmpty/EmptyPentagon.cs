using System.Drawing;
using Utils;

public class EmptyPentagon : FixedBalance
{
    public EmptyPentagon()
    {
        Sprite spriteCreate = new Sprite(ImageProcessing.ResizeImage(Resources.Circle, new Size(80, 80)));
        spriteCreate.Rect = new RectangleF( position.X, position.Y, 80, 80);
        this.Sprite = spriteCreate;
        
        this.Name = "Pentagono";
    }
}