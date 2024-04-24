public class FixedBalance
{
    public Sprite sprite { get; set; }
    public SizeF Size => sprite.Rect.Size;
    public PointF position { get; set; }
    public List<Pieces> pieces = new List<Pieces>();
    public String Name { get; set; }
    protected int qtd { get; set; } = 0;
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
    Brush brush = new SolidBrush(Color.Black);
    Font font= new Font("Arial", 12);
    public void Draw(Graphics g)
    {
        var format = new StringFormat();
        format.Alignment = StringAlignment.Center;
        format.LineAlignment = StringAlignment.Center;

        var rect = new RectangleF(
            (int)position.X,
            (int)position.Y,
            (int)Size.Width,
            (int)Size.Height
            );

        var Qtd = pieces.Count;

        g.DrawString(
            Qtd.ToString(),
            SystemFonts.DefaultFont, 
            brush, this.position.X + (Size.Width / 2), this.position.Y + (Size.Height / 2), 
            format
            );
        sprite.Draw(g, rect);
    }
    public void Add(Pieces piece)
    {
        if (piece.Name == this.Name)
        {
            pieces.Add(piece);
            piece.CanMove = false;
            piece.position = this.position;
            qtd++;
        }
    }

}