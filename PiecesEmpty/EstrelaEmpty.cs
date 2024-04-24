public class EstrelaEmpty : FixedBalance
{
    private List<Quadrado> quadradoList = new List<Quadrado>();
    public EstrelaEmpty(PointF pos)
    {
        Sprite spriteCreate = new Sprite(Bitmap.FromFile(@"./imgs/piecesEmpty/Estrela.png") as Bitmap);
        spriteCreate.Rect = new RectangleF( position.X, position.Y, 80, 80);
        this.Sprite = spriteCreate;

        this.position = pos;
        
        this.Name = "Estrela";
    }
}