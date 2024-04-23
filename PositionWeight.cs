
public abstract class PositionWeight
{
    // public Image shape = Bitmap.FromFile("img/QuadradoTeste.png");
    public List<(Position pos, PointF loc, Pieces piece)> PieceList = new();

    SolidBrush grayBrush = new SolidBrush(Color.FromArgb(100, 0, 0, 0));
    public PositionWeight(){}

    
    public void AddEmptyPosition(Position pos, PointF loc)
        => PieceList.Add((pos, loc, null!));

    public bool SetPiece(Pieces piece, PointF cursor, PictureBox pb)
    {
        for (int i = 0; i < PieceList.Count; i++)
        {
            var item = PieceList[i];
            var itemRect = new RectangleF(item.loc, size: new SizeF(pb.Width*0.044f, pb.Height*0.081f));

            if (!itemRect.Contains(cursor))
                continue;
            
            PieceList[i] = (item.pos, item.loc, piece);
            return true;
        }
        return false;
    }

    public void PiecePosition(PictureBox pb, Image shape)
    {
        foreach (var item in PieceList)
        {
            if(item.piece != null)
            {
                Draws.DrawPieceShape(new PointF(item.loc.X, item.loc.Y), pb, shape);
            } 
        }
    }

    public void Draw(PointF cursor, bool mouseDown, PictureBox pb)
    {
        foreach (var item in PieceList)
        {
            if(item.piece == null)
            this.DrawEmptyPosition(
                new RectangleF(item.loc.X, item.loc.Y, pb.Width*0.044f, pb.Height*0.081f),
                cursor, mouseDown);
        }
    }

    public RectangleF DrawEmptyPosition(RectangleF location, PointF cursor, bool isDown)
    {
        float realWidth = location.Width;
        var realSize = new SizeF(location.Width, location.Height);
 
        var position = new PointF(location.X, location.Y);
        RectangleF rect = new RectangleF(position, realSize);
 
        bool cursorIn = rect.Contains(cursor);
 
        var pen = new Pen(cursorIn ? Color.Green : Color.Black, 1);

        Draws.Graphics.FillRectangle(grayBrush, rect);
        Draws.Graphics.DrawRectangle(pen, rect.X, rect.Y, realWidth, rect.Height);
 
        if (!cursorIn || !isDown)
            return rect;     

        return rect;
    }
    
}