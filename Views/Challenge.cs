using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Entities;
using Entities.Shapes;
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
        List<Shape> shapes;
        Shape selected;
        Point cursor = new Point(0, 0);
        bool isDown = false;

        public Challenge()
        {
            this.balanceLeft = new Balance(200 * ClientScreen.WidthFactor, 100 * ClientScreen.HeightFactor, 350 * ClientScreen.WidthFactor, 350 * ClientScreen.HeightFactor);
            this.balanceRight = new Balance(950 * ClientScreen.WidthFactor, 100 * ClientScreen.HeightFactor, 350 * ClientScreen.WidthFactor, 350 * ClientScreen.HeightFactor);
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Text = "Desafio";
            this.shapes = new List<Shape>();

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

            this.tm = new Timer { Interval = 20 };

            //sair
            // this.KeyDown += (o, e) =>
            // {
            //     if (e.KeyCode == Keys.Escape)
            //         Application.Exit();
            // };

            //popup
            this.KeyDown += (o, e) =>
            {
                if (e.KeyCode == Keys.Escape)
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

            this.pb.MouseMove += (o, e) =>
            {
                cursor = e.Location;
            };

            this.pb.MouseDown += (o, e) =>
            {
                isDown = true;
            };

            this.pb.MouseUp += (o, e) =>
            {
                isDown = false;
            };

            this.tm.Tick += (o, e) =>
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
            Size newSize = new Size(
                (int)(170 * ClientScreen.WidthFactor),
                (int)(38 * ClientScreen.WidthFactor)
            );
            Image resizedLogo = ImageProcessing.ResizeImage(logo, newSize);
            int margin = (int)(14 * ClientScreen.HeightFactor);
            int x = margin;
            int y = ClientScreen.Height - resizedLogo.Height - margin;
            g.DrawImage(resizedLogo, new Point(x, y));

            for (int i = 0; i < 5; i++)
            {
                Square quadrado = new(350 * ClientScreen.WidthFactor, 800 * ClientScreen.HeightFactor, 80 * ClientScreen.WidthFactor, 5);
                shapes.Add(quadrado);

                Circle bola = new(550 * ClientScreen.WidthFactor, 800 * ClientScreen.HeightFactor, 80 * ClientScreen.WidthFactor, 5);
                shapes.Add(bola);

                Triangle triangulo = new(750 * ClientScreen.WidthFactor, 800 * ClientScreen.HeightFactor, 80 * ClientScreen.WidthFactor, 80 * ClientScreen.WidthFactor, 5);
                shapes.Add(triangulo);

                Pentagon pentagono = new(950 * ClientScreen.WidthFactor, 800 * ClientScreen.HeightFactor, 80 * ClientScreen.WidthFactor, 80 * ClientScreen.WidthFactor, 5);
                shapes.Add(pentagono);

                Star estrela = new(1150 * ClientScreen.WidthFactor, 800 * ClientScreen.HeightFactor, 80 * ClientScreen.WidthFactor, 80 * ClientScreen.WidthFactor, 10);
                shapes.Add(estrela);
            }
        }

        void Frame()
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

            foreach (var shape in shapes)
            {
                // if (shape is Star)
                // MessageBox.Show();
                var cusorInForm = shape.Rectangle.Contains(cursor);

                if (isDown && cusorInForm && selected is null)
                {
                    this.selected = shape.OnSelect(cursor);
                    selected.LastPosition = selected.Position;
                }

                if (isDown && selected is not null)
                    selected.OnMove(cursor);

                if (!isDown && selected is not null)
                {
                    selected.Position = selected.LastPosition;
                }

                shape.Draw(this.g);
            }

            if (selected is not null)
            {
                var cusorInside = balanceLeft.LeftHitbox.IntersectsWith(selected.Hitbox);
                if (cusorInside && !isDown && selected.CanMove)
                {
                    balanceLeft.AddLeftShape(selected);
                }

                cusorInside = balanceLeft.RightHitbox.IntersectsWith(selected.Hitbox);
                if (cusorInside && !isDown && selected.CanMove)
                {
                    balanceLeft.AddRightShape(selected);
                }

                cusorInside = balanceRight.LeftHitbox.IntersectsWith(selected.Hitbox);
                if (cusorInside && !isDown && selected.CanMove)
                {
                    balanceRight.AddLeftShape(selected);
                }

                cusorInside = balanceRight.RightHitbox.IntersectsWith(selected.Hitbox);
                if (cusorInside && !isDown && selected.CanMove)
                {
                    balanceRight.AddRightShape(selected);
                }

                if (!isDown)
                    this.selected = null;
            }

            foreach (var shape in shapes)
                shape.UpdateHitbox();
        }
    }
}
