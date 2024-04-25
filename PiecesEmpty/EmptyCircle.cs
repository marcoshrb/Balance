using Balance;

namespace DragAndDrop;

public class EmptyCircle : FixedBalance
{
    private List<Square> circleList = new List<Square>();
    public EmptyCircle(PointF pos)
    {
        Sprite spriteCreate = new Sprite(Bitmap.FromFile(@"./imgs/piecesEmpty/Bola.png") as Bitmap);
        spriteCreate.Rect = new RectangleF( position.X, position.Y, 80, 80);
        this.Sprite = spriteCreate;

        this.position = pos;
        
        this.Name = "Bola";
    }
}