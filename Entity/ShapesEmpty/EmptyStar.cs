using System.Drawing;

public class EmptyStar : FixedBalance
{
    public EmptyStar(PointF pos)
    {
        Sprite spriteCreate = new Sprite(Resources.Star);
        spriteCreate.Rect = new RectangleF( position.X, position.Y, 80, 80);
        this.Sprite = spriteCreate;

        this.position = pos;
        
        this.Name = "Estrela";
    }
}