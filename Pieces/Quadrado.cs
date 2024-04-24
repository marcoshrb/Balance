public class Quadrado : Pieces
{
    public Quadrado(){
        Sprite spriteCreate = new Sprite(Bitmap.FromFile(@"./imgs/pieces/Quadrado.png") as Bitmap);
        spriteCreate.Rect = new RectangleF( position.X, position.Y, 79, 79);
        this.sprite = spriteCreate;  

        this.position = new PointF(350, 800);
        
        this.Name = "Quadrado";
        
    }
}