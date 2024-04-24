public class Pentagono : Pieces
{
    public Pentagono()
    {
        Sprite spriteCreate = new Sprite(Bitmap.FromFile(@"./imgs/pieces/Pentagono.png") as Bitmap);
        spriteCreate.Rect = new RectangleF( position.X, position.Y, 79, 79);
        this.sprite = spriteCreate;  

        this.position = new PointF(950, 800);

        this.Name = "Pentagono";
    }
}