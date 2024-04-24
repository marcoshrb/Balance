public class QuadradoEmpyt : FixedBalance
{
    private List<Quadrado> quadradoList = new List<Quadrado>();
    public QuadradoEmpyt()
    {
        Sprite spriteCreate = new Sprite(Bitmap.FromFile(@"./imgs/piecesEmpyt/Quadrado.png") as Bitmap);
        spriteCreate.Rect = new RectangleF( position.X, position.Y, 79, 79);
        this.sprite = spriteCreate;
        
        this.Name = "Quadrado";
    }
}