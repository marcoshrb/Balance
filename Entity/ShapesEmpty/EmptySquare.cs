using System.Drawing;

public class EmptySquare : FixedBalance
{
    public EmptySquare(PointF pos)
    {
        Sprite spriteCreate = new Sprite(Resources.Square);
        spriteCreate.Rect = new RectangleF( position.X, position.Y, 80, 80);
        this.Sprite = spriteCreate;

        this.position = pos;
        
        this.Name = "Quadrado";
    }
}