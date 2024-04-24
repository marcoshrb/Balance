public class BolaEmpty : FixedBalance
{
    private List<Quadrado> quadradoList = new List<Quadrado>();
    public BolaEmpty(PointF pos)
    {
        Sprite spriteCreate = new Sprite(Bitmap.FromFile(@"./imgs/piecesEmpty/Bola.png") as Bitmap);
        spriteCreate.Rect = new RectangleF( position.X, position.Y, 80, 80);
        this.Sprite = spriteCreate;

        this.position = pos;
        
        this.Name = "Bola";
    }
}