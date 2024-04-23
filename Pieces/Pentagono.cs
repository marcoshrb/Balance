public class Pentagono : Pieces
{
    public Pentagono()
    {
        Sprite spriteCreate = new Sprite(Bitmap.FromFile(@"./imgs/Pentagono.png") as Bitmap);
        spriteCreate.Rect = new RectangleF( position.X, position.Y, 79, 79);
        this.sprite = spriteCreate;  
    }
}