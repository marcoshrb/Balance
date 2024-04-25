using System.Drawing;

public class EmptyTriangle : FixedBalance
{
    public EmptyTriangle(PointF pos)
    {
        Sprite spriteCreate = new Sprite(Bitmap.FromFile(@"./imgs/piecesEmpty/Triangulo.png") as Bitmap);
        spriteCreate.Rect = new RectangleF( position.X, position.Y, 80, 80);
        this.Sprite = spriteCreate;

        this.position = pos;
        
        this.Name = "Triangulo";
    }
}