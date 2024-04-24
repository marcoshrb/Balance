public class TrianguloEmpty : FixedBalance
{
    private List<Quadrado> quadradoList = new List<Quadrado>();
    public TrianguloEmpty()
    {
        Sprite spriteCreate = new Sprite(Bitmap.FromFile(@"./imgs/piecesEmpty/Triangulo.png") as Bitmap);
        spriteCreate.Rect = new RectangleF( position.X, position.Y, 80, 80);
        this.Sprite = spriteCreate;

        this.position = new PointF(660, 400);
        
        this.Name = "Triangulo";
    }
}