public class Bola : Pieces
{
    public Bola()
    {
        Sprite spriteCreate = new Sprite(Bitmap.FromFile(@"./imgs/pieces/Bola.png") as Bitmap);
        spriteCreate.Rect = new RectangleF( Position.X, Position.Y, 80, 80);
        this.Sprite = spriteCreate;  

        this.Position = new PointF(550, 800);

        this.Name = "Bola";
    }
}