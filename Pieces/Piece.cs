public class Pieces
{
    public Sprite Sprite { get; set; }
    public SizeF Size => Sprite.Rect.Size;
    public PointF Position { get; set; }
    public bool CanMove = true;
    public String Name { get; set; }
    public float Weigth { get; set; }
    public PointF LastPosition { get; set; }
    public RectangleF Rectangle
    {
        get
        {
            return new RectangleF(
                (int)Position.X,
                (int)Position.Y,
                (int)Size.Width,
                (int)Size.Height
            );
        }
    }

    internal PointF? ptClick = null;
    public void DrawPieces(Graphics g)
    {
        var rect = new RectangleF(
            (int)Position.X,
            (int)Position.Y,
            (int)Size.Width,
            (int)Size.Height
            );

        Sprite.DrawSprite(g, rect);
    }
    public Pieces OnSelect(Point cursor)
    {
        float _x, _y;
        _x = cursor.X - this.Position.X;
        _y = cursor.Y - this.Position.Y;
        ptClick = new PointF(_x, _y);
        return this;
    }

    public void OnMove(Point cursor)
    {
        if (CanMove)
        {
            if (ptClick is null)
                return;

            Position = new PointF(
                cursor.X - ptClick.Value.X,
                cursor.Y - ptClick.Value.Y
            );
        }
    }
}