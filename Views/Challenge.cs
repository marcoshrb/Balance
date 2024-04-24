using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Utils;

namespace Views
{
    public class Challenge : Form
    {
        Balance balanceLeft;
        Balance balanceRight;

        PictureBox header;
        PictureBox pb;
        Bitmap bmp;
        Graphics g;
        Timer tm;

        public Challenge()
        {
            this.balanceLeft = new Balance(200, 100, 350, 350);
            this.balanceRight = new Balance(950, 100, 350, 350);
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


            this.pb = new PictureBox
            {
                Dock = DockStyle.Fill
            };
            this.Controls.Add(pb);

            this.tm = new Timer
            {
                Interval = 20
            };

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
                this.tm.Start();
            };

            tm.Tick += (o, e) =>
            {
                g.Clear(Color.FromArgb(250, 249, 246));
                balanceLeft.Draw(this.g);
                balanceRight.Draw(this.g);
                Frame();
                pb.Refresh();
            };
        }

        void Onstart()
        {
            Image logo = ImageProcessing.GetImage(@"Assets\logo.png");
            Size newSize = new Size((int)(170 * ClientScreen.WidthFactor), (int)(38 * ClientScreen.WidthFactor));
            Image resizedLogo = ImageProcessing.ResizeImage(logo, newSize);
            int margin = (int)(14 * ClientScreen.HeightFactor);
            int x = margin;
            int y = ClientScreen.Height - resizedLogo.Height - margin;
            g.DrawImage(resizedLogo, new Point(x, y));
        }

        void Frame()
        {
            Image logo = ImageProcessing.GetImage(@"Assets\logo.png");
            Size newSize = new Size((int)(170 * ClientScreen.WidthFactor), (int)(38 * ClientScreen.WidthFactor));
            Image resizedLogo = ImageProcessing.ResizeImage(logo, newSize);
            int margin = (int)(14 * ClientScreen.HeightFactor);
            int x = margin;
            int y = ClientScreen.Height - resizedLogo.Height - margin;
            g.DrawImage(resizedLogo, new Point(x, y));
        }
    }
}