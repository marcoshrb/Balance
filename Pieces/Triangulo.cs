public class Triangulo : Pieces
{
    public Triangulo(){
        Sprite spriteCreate = new Sprite(Bitmap.FromFile(@"./imgs/pieces/Triangulo.png") as Bitmap);
        spriteCreate.Rect = new RectangleF( Position.X, Position.Y, 80, 80);
        this.Sprite = spriteCreate;  

        this.Position = new PointF(750, 800);

        this.Name = "Triangulo";
    }
}