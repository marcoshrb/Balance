using System.Drawing;

public class EmptyCircle : FixedBalance
{
    public EmptyCircle()
    {
        Sprite spriteCreate = new Sprite(Bitmap.FromFile(@"./Assets/Shapes/piecesEmpty/Bola.png") as Bitmap);
        spriteCreate.Rect = new RectangleF( position.X, position.Y, 80, 80);
        this.Sprite = spriteCreate;
        
        this.Name = "Bola";
    }

    public EmptyCircle(PointF pos)
    {
        Sprite spriteCreate = new Sprite(Bitmap.FromFile(@"./Assets/Shapes/piecesEmpty/Bola.png") as Bitmap);
        spriteCreate.Rect = new RectangleF( position.X, position.Y, 80, 80);
        this.Sprite = spriteCreate;
        
        this.position = pos;
        this.Name = "Bola";
    }

}