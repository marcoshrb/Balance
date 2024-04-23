using Microsoft.VisualBasic.Logging;

public class Quadrado
{
    public Sprite sprite;
    public SizeF Size => sprite.Rect.Size;
    public virtual PointF position {get; set;} = new Point(0, 0);
    public RectangleF rectangle;
    
    public void Draw(Graphics g)
    {
        var rect = new RectangleF(
            (int)position.X, 
            (int)position.Y, 
            (int)Size.Width, 
            (int)Size.Height
            );
        rectangle = rect;
        sprite.Draw(g, rect);
    }

    public Quadrado(){
        Sprite spriteCreate = new Sprite(Bitmap.FromFile(@"./imgs/QuadradoTeste.png") as Bitmap);
        spriteCreate.Rect = new RectangleF( position.X, position.Y, 79, 79);
        this.sprite = spriteCreate;   
    }

    public void OnMove(Point cursor)
    {
        position = new PointF(
            cursor.X,
            cursor.Y
        );
        // MessageBox.Show(cursor.X.ToString(), cursor.Y.ToString());
    }
}