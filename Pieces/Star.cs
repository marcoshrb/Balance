using Balance;

namespace DragAndDrop;

public class Star : Pieces
{
    public Star()
    {
        Sprite spriteCreate = new Sprite(Bitmap.FromFile(@"./imgs/pieces/Estrela.png") as Bitmap);
        spriteCreate.Rect = new RectangleF( Position.X, Position.Y, 80, 80);
        this.Sprite = spriteCreate;  

        this.Position = new PointF(1150, 800);
        
        this.Name = "Estrela";
    }
}