public class TrianguloEmpty : FixedBalance
{
    private List<Quadrado> quadradoList = new List<Quadrado>();
    public TrianguloEmpty()
    {
        Sprite spriteCreate = new Sprite(Bitmap.FromFile(@"./imgs/piecesEmpty/Triangulo.png") as Bitmap);
        spriteCreate.Rect = new RectangleF( position.X, position.Y, 79, 79);
        this.sprite = spriteCreate;

        this.position = new PointF(660, 400);
        
        this.Name = "Triangulo";
    }
}