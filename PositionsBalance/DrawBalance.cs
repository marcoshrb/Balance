public class DrawBalance : PositionWeight 
{
    public DrawBalance()
    {
        AddEmptyPosition(Position.Espace1, 
            new PointF(350, 400)
        ); //GL
        AddEmptyPosition(Position.Espace2, 
            new PointF(Screen.PrimaryScreen.Bounds.Width*0.128f, Screen.PrimaryScreen.Bounds.Height*0.592f)
        ); //LE
        AddEmptyPosition(Position.Espace3, 
            new PointF(Screen.PrimaryScreen.Bounds.Width*0.219f, Screen.PrimaryScreen.Bounds.Height*0.629f)
        ); //ZC
        AddEmptyPosition(Position.Espace4, 
            new PointF(Screen.PrimaryScreen.Bounds.Width*0.323f, Screen.PrimaryScreen.Bounds.Height*0.629f)
        ); //ZC

    }
}