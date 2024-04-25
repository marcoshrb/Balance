using System.Drawing;
using Utils;

public class EmptyStar : FixedBalance
{
    public EmptyStar()
    {
        Sprite spriteCreate = new Sprite(ImageProcessing.ResizeImage(Resources.Star, new Size(80, 80)));
        spriteCreate.Rect = new RectangleF( position.X, position.Y, 80, 80);
        this.Sprite = spriteCreate;
        
        this.Name = "Estrela";
    }
}