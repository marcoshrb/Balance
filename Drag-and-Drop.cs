using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;
public class DragAndDrop : Form
{
    Bitmap bmp = null;
    public Graphics g = null;
    PointF cursor = PointF.Empty;
    Timer tm = new Timer();
    private PictureBox pb = new PictureBox{
        Dock = DockStyle.Fill,
    };
    bool isDown = false;
    public Image piece = Bitmap.FromFile("assents/circulo.png");
    public DragAndDrop(){
        tm.Interval = 10;
        WindowState = FormWindowState.Maximized;
        FormBorderStyle = FormBorderStyle.None;

        pb.MouseDown += (o, e) =>
        {
            isDown = true;
        };

        pb.MouseUp += (o, e) =>
        {
            isDown = false;
        };

        pb.MouseMove += (o, e) =>
        {
            cursor = e.Location;
        };

        Controls.Add(pb);

        KeyDown += (o, e) =>
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    Application.Exit();
                    break;

            }
        };
        this.Load += delegate
        {
            bmp = new Bitmap(
                pb.Width, 
                pb.Height
            );
            g = Graphics.FromImage(bmp);
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            // Draws.DrawPieces(piece, pb);
            pb.Image = bmp;
            tm.Start();
        };

        tm.Tick += delegate
        {
            g.Clear(Color.Green);
            // Draws.DrawPieces(piece, pb);
            pb.Refresh();
        };
    }

    // public void DrawPiece(Image img)
    // {
    //     Draws.DrawPieces(img, pb);
    // }
}