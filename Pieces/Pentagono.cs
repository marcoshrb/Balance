public class Pentagono : Pieces
{
    public Pentagono()
    {
        Sprite spriteCreate = new Sprite(Bitmap.FromFile(@"./imgs/pieces/Pentagono.png") as Bitmap);
        spriteCreate.Rect = new RectangleF( Position.X, Position.Y, 80, 80);
        this.Sprite = spriteCreate;  

        this.Position = new PointF(950, 800);

        this.Name = "Pentagono";
    }
}