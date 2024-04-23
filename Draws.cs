using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;




public static class Draws
{
    public static Graphics Graphics { get; set; }
    private static Graphics g => Graphics;
    private static Font font = new Font("Copperplate Gothic Bold", Screen.PrimaryScreen.Bounds.Width*0.005f);

    public static void DrawPieces(Image image, PictureBox pb)
        => g.DrawImage(image, new RectangleF(pb.Width*0.104f, pb.Height*0.009f, pb.Width*0.38f, pb.Height*0.38f));

    public static void DrawText(string text, Color color, RectangleF location)
    {
        var format = new StringFormat();
        format.Alignment = StringAlignment.Center;
        format.LineAlignment = StringAlignment.Center;

        var brush = new SolidBrush(color);

        g.DrawString(text, SystemFonts.DefaultFont, brush, location, format);
    }

    public static void DrawBalance(Image image, PictureBox pb)
    => g.DrawImage(image, new RectangleF(pb.Width*0.104f, pb.Height*0.009f, pb.Width*0.38f, pb.Height*0.921f));

    public static void DrawPieceShape(PointF location, PictureBox pb, Image shirt)
        => g.DrawImage(shirt, new RectangleF(location.X, location.Y , pb.Width*0.044f, pb.Height*0.081f));

}