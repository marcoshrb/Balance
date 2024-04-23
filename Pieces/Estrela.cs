public class Estrela : Pieces
{
    public Estrela()
    {
        Sprite spriteCreate = new Sprite(Bitmap.FromFile(@"./imgs/Estrela.png") as Bitmap);
        spriteCreate.Rect = new RectangleF( position.X, position.Y, 79, 79);
        this.sprite = spriteCreate;  
    }
}