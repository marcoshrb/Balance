using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Utils;

namespace Views;

public class Completed : Form
{
    public Security MainForm { get; set; }
    PictureBox header;
    PictureBox pb;
    Bitmap bmp;
    Graphics g;
    Timer tm;
    Font font = new Font("Arial", 36, FontStyle.Bold);
    Font font2 = new Font("Arial", 24 * ClientScreen.WidthFactor);
    Screen screen = Screen.PrimaryScreen;
    StringFormat format = new StringFormat();
    public Completed()
    {
        this.WindowState = FormWindowState.Maximized;
        this.FormBorderStyle = FormBorderStyle.None;
        this.Text = "Desafio";

        this.header = new PictureBox
        {
            Dock = DockStyle.Top,
            Height = (int)(16 * ClientScreen.HeightFactor),
            BackgroundImage = Image.FromFile(@"Assets\rainbow.png"),
            BackgroundImageLayout = ImageLayout.Stretch
        };
        this.Controls.Add(header);

        this.pb = new PictureBox { Dock = DockStyle.Fill };
        this.Controls.Add(pb);

        this.tm = new Timer { Interval = 10 };

        this.KeyDown += (o, e) =>
        {
            if (e.KeyCode == Keys.Escape)
                Application.Exit();
        };


        this.Load += (o, e) =>
        {
            this.bmp = new Bitmap(pb.Width, pb.Height);
            g = Graphics.FromImage(this.bmp);
            g.InterpolationMode = InterpolationMode.NearestNeighbor;
            g.Clear(Color.FromArgb(250, 249, 246));
            this.pb.Image = bmp;
            Onstart();
        };
    }

    void Onstart()
    {
        Image logo = ImageProcessing.GetImage(@"Assets\logo.png");
        Size newSize = new Size(
            (int)(170 * ClientScreen.WidthFactor),
            (int)(38 * ClientScreen.WidthFactor)
        );
        Image resizedLogo = ImageProcessing.ResizeImage(logo, newSize);
        int margin = (int)(14 * ClientScreen.HeightFactor);
        int x = margin;
        int y = ClientScreen.Height - resizedLogo.Height - margin;
        g.DrawImage(resizedLogo, new Point(x, y));


        format.Alignment = StringAlignment.Center;
        format.LineAlignment = StringAlignment.Center;

        g.DrawString("Desafio Completo!", font, Brushes.Black, new PointF(screen.Bounds.Width / 2, screen.Bounds.Height / 2 - 50), format);
        g.DrawString("Chame o Instrutor para receber mais informações sobre o proximo passo que você deve seguir.", font2, Brushes.Black, new PointF(screen.Bounds.Width / 2, screen.Bounds.Height / 2 + 50), format);

    }

}

