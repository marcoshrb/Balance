using Balance;

namespace DragAndDrop;

public class EmptySquare : FixedBalance
{
    private List<Square> squareList = new List<Square>();
    public EmptySquare(PointF pos)
    {
        Sprite spriteCreate = new Sprite(Bitmap.FromFile(@"./imgs/piecesEmpty/Quadrado.png") as Bitmap);
        spriteCreate.Rect = new RectangleF( position.X, position.Y, 80, 80);
        this.Sprite = spriteCreate;

        this.position = pos;
        
        this.Name = "Quadrado";
    }
}