using Views;

public abstract class Localization
{
    private Image shape = Image.FromFile("");
    public List<(Position pos, PointF loc, Piece piece)> PieceList = new();

    public Localization(){}

    
    public void AddEmptyLocalization(Position pos, PointF loc)
        => PieceList.Add((pos, loc, null));

    public bool SetPiece(Piece piece, PointF cursor, PictureBox pb)
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
                // Draws.DrawPieces(new PointF(item.loc.X, item.loc.Y), pb, shirt);
                // Draws.DrawText(item.piece.Name,Color.Black, 
                //     new RectangleF(item.loc.X, item.loc.Y + pb.Height*0.081f, pb.Width*0.044f, pb.Height*0.03f));
            } 
        }
    }
    
}