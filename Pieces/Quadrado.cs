public class Quadrado : Pieces
{
    public Quadrado(){
        Sprite spriteCreate = new Sprite(Bitmap.FromFile(@"./imgs/pieces/Quadrado.png") as Bitmap);
        spriteCreate.Rect = new RectangleF( Position.X, Position.Y, 80, 80);
        this.Sprite = spriteCreate;  

        this.Position = new PointF(350, 800);
        
        this.Name = "Quadrado";
        
    }
}