using System.Drawing;

public class EmptyTriangle : FixedBalance
{
    public EmptyTriangle()
    {
        Sprite spriteCreate = new Sprite(Bitmap.FromFile(@"./Assets/Shapes/piecesEmpty/Triangulo.png") as Bitmap);
        spriteCreate.Rect = new RectangleF( position.X, position.Y, 80, 80);
        this.Sprite = spriteCreate;

        this.Name = "Triangulo";
    }

    public EmptyTriangle(PointF pos)
    {
        Sprite spriteCreate = new Sprite(Bitmap.FromFile(@"./Assets/Shapes/piecesEmpty/Triangulo.png") as Bitmap);
        spriteCreate.Rect = new RectangleF( position.X, position.Y, 80, 80);
        this.Sprite = spriteCreate;

        this.position = pos;
        this.Name = "Triangulo";
    }
}