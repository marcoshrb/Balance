public class QuadradoEmpty : FixedBalance
{
    private List<Quadrado> quadradoList = new List<Quadrado>();
    public QuadradoEmpty()
    {
        Sprite spriteCreate = new Sprite(Bitmap.FromFile(@"./imgs/piecesEmpty/Quadrado.png") as Bitmap);
        spriteCreate.Rect = new RectangleF( position.X, position.Y, 80, 80);
        this.Sprite = spriteCreate;

        this.position = new PointF(500, 400);
        
        this.Name = "Quadrado";
    }
}