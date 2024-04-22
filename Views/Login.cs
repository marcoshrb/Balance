using System;
using System.Drawing;
using System.Windows.Forms;

namespace Views;

public class Login : Form
{
    private Graphics g = null;
    private Bitmap bmp = null;
    private Image img = null;
    
    private PictureBox pb = new PictureBox {
        Dock = DockStyle.Fill,
    };

    public Login()
    {
        WindowState = FormWindowState.Maximized;
        FormBorderStyle = FormBorderStyle.None;
        this.Text = "Joguinho";

        Controls.Add(pb);

        this.img = Bitmap.FromFile("Views/colorStripe.png");

        this.Load += delegate
        {
            bmp = new Bitmap(
                pb.Width,
                pb.Height
            );
            this.g = Graphics.FromImage(bmp);
            // g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            pb.Image = bmp;

            var format = new StringFormat();
            format.Alignment = StringAlignment.Center;
            format.LineAlignment = StringAlignment.Center;

            Font font= new Font("Copperplate Gothic Bold", Screen.PrimaryScreen.Bounds.Width*0.04f);

            g.DrawImage(img, 0, 0, Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height * 0.015f);

            g.DrawString("Insira seus dados:", font, Brushes.Black, 10, 10, format);

            // pb.Refresh();
        };

        // this.FormClosed += delegate
        // {
        //     Application.Exit();
        // };

        // pb.MouseDown += (o, e) =>
        // {

        // };
    }
}