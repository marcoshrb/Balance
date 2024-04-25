using System.Drawing;
using Utils;
public class EmptyCircle : FixedBalance
{
    public EmptyCircle(PointF pos)
    {
        Sprite spriteCreate = new Sprite(Resources.Circle);
        spriteCreate.Rect = new RectangleF( position.X, position.Y, 80, 80);
        this.Sprite = spriteCreate;

        this.position = pos;
        
        this.Name = "Bola";
    }
}