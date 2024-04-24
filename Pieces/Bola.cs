public class Bola : Pieces
{
    public Bola()
    {
        Sprite spriteCreate = new Sprite(Bitmap.FromFile(@"./imgs/pieces/Bola.png") as Bitmap);
        spriteCreate.Rect = new RectangleF( position.X, position.Y, 79, 79);
        this.sprite = spriteCreate;  

        this.position = new PointF(550, 800);

        this.Name = "Bola";
    }
}