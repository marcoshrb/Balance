using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Utils;

namespace Views
{
    public class Challenge : Form
    {
        public MainForm MainForm { get; set; }
        PictureBox header;
        PictureBox pb;
        Bitmap bmp;
        Graphics g;
        Timer tm;
        Balance balanceLeft;
        Balance balanceRight;
        PictureBox cronometro;
        PictureBox borda;
        Label horario;


        public Challenge()
        {
            this.balanceLeft = new Balance(200, 100, 350, 350);
            this.balanceRight = new Balance(950, 100, 350, 350);
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Text = "Desafio";

            int tempoInicial = 600; 
            int tempoRestante = tempoInicial;


            horario = new Label
            {
                Text = "Horas",
                Size = new Size(185, 50),
                BackColor = Color.White,
                Font = new Font("Arial", 30, FontStyle.Bold),
                Location = new Point(ClientSize.Width - 242, 43),
                Anchor = AnchorStyles.Top | AnchorStyles.Right
            };
            Controls.Add(horario);

            cronometro = new PictureBox
            {
                BackColor = Color.White,
                Size = new Size(190, 55),
                Location = new Point(ClientSize.Width - 245, 40),
                Anchor = AnchorStyles.Top | AnchorStyles.Right
            };
            Controls.Add(cronometro);

            borda = new PictureBox
            {
                BackColor = Color.Black,
                Size = new Size(200, 65),
                Location = new Point(ClientSize.Width - 250, 35),
                Anchor = AnchorStyles.Top | AnchorStyles.Right
            };
            Controls.Add(borda);

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
                bool isLetterOrDigit = char.IsLetterOrDigit((char)e.KeyCode);

                if (!isLetterOrDigit)
                {
                    if (MainForm == null)
                    {
                        MainForm = new MainForm();
                        MainForm.FormClosed += (sender, args) =>
                        {
                            MainForm = null;
                        };
                        MainForm.Show();
                    }
                    else
                    {
                        MainForm.BringToFront();
                    }
                }
                if (e.KeyCode == Keys.A)
                    balanceLeft.State = (int)BalanceState.Left;
                if (e.KeyCode == Keys.S)
                    balanceLeft.State = (int)BalanceState.None;
                if (e.KeyCode == Keys.D)
                    balanceLeft.State = (int)BalanceState.Right;
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

                horario.Text = DateTime.Now.ToString("HH:mm:ss");

                // tempoRestante--;

                // if (tempoRestante <= 0)
                // {
                //     tempoRestante = 0;
                // }

                // int horas = tempoRestante / 3600;
                // int minutos = (tempoRestante % 3600) / 60;
                // int segundos = tempoRestante % 60;

                // horario.Text = string.Format("{0:00}:{1:00}:{2:00}", horas, minutos, segundos);

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
