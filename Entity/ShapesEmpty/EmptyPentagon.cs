using System.Drawing;

public class EmptyPentagon : FixedBalance
{
    public EmptyPentagon( )
    {
        Sprite spriteCreate = new Sprite(Bitmap.FromFile(@"./imgs/piecesEmpty/Pentagono.png") as Bitmap);
        spriteCreate.Rect = new RectangleF( position.X, position.Y, 80, 80);
        this.Sprite = spriteCreate;
        
        this.Name = "Pentagono";
    }

    public EmptyPentagon(PointF pos)
    {
        Sprite spriteCreate = new Sprite(Bitmap.FromFile(@"./imgs/piecesEmpty/Pentagono.png") as Bitmap);
        spriteCreate.Rect = new RectangleF( position.X, position.Y, 80, 80);
        this.Sprite = spriteCreate;
        
        this.position = pos;
        this.Name = "Pentagono";
    }
}