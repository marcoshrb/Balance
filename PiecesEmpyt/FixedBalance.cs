public class FixedBalance
{
    public Sprite sprite { get; set; }
    public SizeF Size => sprite.Rect.Size;
    public PointF position { get; set; } = new Point(0, 0);
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

    public void AtualizarPosition(PointF newPositon)
        =>position = newPositon;

}