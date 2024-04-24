public class Triangulo : Pieces
{
    public Triangulo(){
        Sprite spriteCreate = new Sprite(Bitmap.FromFile(@"./imgs/pieces/Triangulo.png") as Bitmap);
        spriteCreate.Rect = new RectangleF( position.X, position.Y, 79, 79);
        this.sprite = spriteCreate;  

        this.Name = "Triangulo";
    }
}