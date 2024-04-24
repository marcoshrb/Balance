public class PentagonoEmpty : FixedBalance
{
    private List<Quadrado> quadradoList = new List<Quadrado>();
    public PentagonoEmpty(PointF pos)
    {
        Sprite spriteCreate = new Sprite(Bitmap.FromFile(@"./imgs/piecesEmpty/Pentagono.png") as Bitmap);
        spriteCreate.Rect = new RectangleF( position.X, position.Y, 80, 80);
        this.Sprite = spriteCreate;

        this.position = pos;
        
        this.Name = "Pentagono";
    }
}