using Balance;

namespace DragAndDrop;

public class EmptyStar : FixedBalance
{
    private List<Square> starList = new List<Square>();
    public EmptyStar(PointF pos)
    {
        Sprite spriteCreate = new Sprite(Bitmap.FromFile(@"./imgs/piecesEmpty/Estrela.png") as Bitmap);
        spriteCreate.Rect = new RectangleF( position.X, position.Y, 80, 80);
        this.Sprite = spriteCreate;

        this.position = pos;
        
        this.Name = "Estrela";
    }
}