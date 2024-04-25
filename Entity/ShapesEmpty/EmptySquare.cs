using System.Drawing;

public class EmptySquare : FixedBalance
{
    public EmptySquare(PointF pos)
    {
        Sprite spriteCreate = new Sprite(Bitmap.FromFile(@"./imgs/piecesEmpty/Quadrado.png") as Bitmap);
        spriteCreate.Rect = new RectangleF( position.X, position.Y, 80, 80);
        this.Sprite = spriteCreate;

        this.position = pos;
        
        this.Name = "Quadrado";
    }
}