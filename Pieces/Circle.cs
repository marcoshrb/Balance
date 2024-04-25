using Balance;

namespace DragAndDrop;

public class Circle : Pieces
{
    public Circle()
    {
        Sprite spriteCreate = new Sprite(Bitmap.FromFile(@"./imgs/pieces/Bola.png") as Bitmap);
        spriteCreate.Rect = new RectangleF( Position.X, Position.Y, 80, 80);
        this.Sprite = spriteCreate;  

        this.Position = new PointF(550, 800);

        this.Name = "Bola";
    }
}