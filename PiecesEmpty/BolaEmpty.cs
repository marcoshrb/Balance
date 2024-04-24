public class BolaEmpty : FixedBalance
{
    private List<Quadrado> quadradoList = new List<Quadrado>();
    public BolaEmpty()
    {
        Sprite spriteCreate = new Sprite(Bitmap.FromFile(@"./imgs/piecesEmpty/Bola.png") as Bitmap);
        spriteCreate.Rect = new RectangleF( position.X, position.Y, 80, 80);
        this.Sprite = spriteCreate;

        this.position = new PointF(580, 400);
        
        this.Name = "Bola";
    }
}