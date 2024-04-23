public class Pieces
{
    public Sprite sprite { get; set; }
    public SizeF Size => sprite.Rect.Size;
    public PointF position {get; set;} = new Point(0, 0);
    public RectangleF rectangle
    {
        get
        {
            return new RectangleF(
                (int)position.X, 
                (int)position.Y, 
                (int)Size.Width, 
                (int)Size.Height
            );
        } 
    }

    internal PointF? ptClick = null;
    public void Draw(Graphics g)
    {
        var rect = new RectangleF(
            (int)position.X, 
            (int)position.Y, 
            (int)Size.Width, 
            (int)Size.Height
            );
        
        sprite.Draw(g, rect);
    }
    public Pieces OnSelect(Point cursor)
    {
        float _x, _y;
        _x = cursor.X - this.position.X;
        _y = cursor.Y - this.position.Y;
        ptClick = new PointF( _x, _y );
        return this;
    }

    public void OnMove(Point cursor)
    {
        if (ptClick is null)
            return;

        position = new PointF(
            cursor.X - ptClick.Value.X,
            cursor.Y - ptClick.Value.Y
        );
        
    }
}