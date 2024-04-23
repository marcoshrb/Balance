public class Bola : Pieces
{
    public Bola()
    {
        Sprite spriteCreate = new Sprite(Bitmap.FromFile(@"./imgs/Bola.png") as Bitmap);
        spriteCreate.Rect = new RectangleF( position.X, position.Y, 79, 79);
        this.sprite = spriteCreate;  
    }
}