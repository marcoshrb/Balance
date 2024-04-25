using System;
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
        InputUser inputCircle = null;
        InputUser inputTriangle = null;
        InputUser inputSquare = null;
        InputUser inputPentagon = null;
        InputUser inputStar = null;
        bool showLine = false;
        int counter = 0;

        public Challenge()
        {
            TextBox textBox = null;
            InputUser crrInput = null;
            this.balanceLeft = new Balance(200, 100, 350, 350);
            this.balanceRight = new Balance(950, 100, 350, 350);
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
                // if (e.KeyCode == Keys.A)
                //     balanceLeft.State = (int)BalanceState.Left;
                // if (e.KeyCode == Keys.S)
                //     balanceLeft.State = (int)BalanceState.None;
                // if (e.KeyCode == Keys.D)
                //     balanceLeft.State = (int)BalanceState.Right;
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

                inputCircle = new InputUser(pb.Width*0.85f, pb.Height*0.15f, pb.Width*0.1f, pb.Height*0.04f, Bitmap.FromFile(@"./imgs/pieces/Bola.png") as Bitmap);
                inputTriangle = new InputUser(pb.Width*0.85f, pb.Height*0.20f, pb.Width*0.1f, pb.Height*0.04f, Bitmap.FromFile(@"./imgs/pieces/Triangulo.png") as Bitmap);
                inputSquare = new InputUser(pb.Width*0.85f, pb.Height*0.25f, pb.Width*0.1f, pb.Height*0.04f, Bitmap.FromFile(@"./imgs/pieces/Quadrado.png") as Bitmap);
                inputPentagon = new InputUser(pb.Width*0.85f, pb.Height*0.30f, pb.Width*0.1f, pb.Height*0.04f, Bitmap.FromFile(@"./imgs/pieces/Pentagono.png") as Bitmap);
                inputStar = new InputUser(pb.Width*0.85f, pb.Height*0.35f, pb.Width*0.1f, pb.Height*0.04f, Bitmap.FromFile(@"./imgs/pieces/Estrela.png") as Bitmap);
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

            this.FormClosed  += delegate
            {
                Application.Exit();
            };

            this.tm.Tick += (o, e) =>
            {
                g.Clear(Color.FromArgb(250, 249, 246));
                balanceLeft.Draw(this.g);
                balanceRight.Draw(this.g);
                inputCircle.DrawInputSprite(g, pb);
                inputTriangle.DrawInputSprite(g, pb);
                inputSquare.DrawInputSprite(g, pb);
                inputPentagon.DrawInputSprite(g, pb);
                inputStar.DrawInputSprite(g, pb);
                textForResult(o, e);
                Frame();
                pb.Refresh();
            };

            pb.MouseClick += (o, e) =>
            {
                if(inputCircle.Rect.Contains(e.X, e.Y) && !inputCircle.IsTyping)
                {
                    inputCircle.IsTyping = true;
                    inputTriangle.IsTyping = false;
                    inputSquare.IsTyping = false;
                    inputPentagon.IsTyping = false;
                    inputStar.IsTyping = false;
                    if(inputCircle.Content == "")
                        textBox.Text = "";
                    else
                        textBox.Text = inputCircle.Content;
                    crrInput = inputCircle;
                    textBox.Enabled = true;
                    textBox.Focus();
                }
                else if(inputTriangle.Rect.Contains(e.X, e.Y) && !inputTriangle.IsTyping)
                {
                    inputTriangle.IsTyping = true;
                    inputCircle.IsTyping = false;
                    inputSquare.IsTyping = false;
                    inputPentagon.IsTyping = false;
                    inputStar.IsTyping = false;
                    if(inputTriangle.Content == "")
                        textBox.Text = "";
                    else
                        textBox.Text = inputTriangle.Content;
                    crrInput = inputTriangle;
                    textBox.Enabled = true;
                    textBox.Focus();
                }
                else if(inputSquare.Rect.Contains(e.X, e.Y) && !inputSquare.IsTyping)
                {
                    inputSquare.IsTyping = true;
                    inputCircle.IsTyping = false;
                    inputTriangle.IsTyping = false;
                    inputPentagon.IsTyping = false;
                    inputStar.IsTyping = false;
                    if(inputSquare.Content == "")
                        textBox.Text = "";
                    else
                        textBox.Text = inputSquare.Content;
                    crrInput = inputSquare;
                    textBox.Enabled = true;
                    textBox.Focus();
                }
                else if(inputPentagon.Rect.Contains(e.X, e.Y) && !inputPentagon.IsTyping)
                {
                    inputPentagon.IsTyping = true;
                    inputCircle.IsTyping = false;
                    inputTriangle.IsTyping = false;
                    inputSquare.IsTyping = false;
                    inputStar.IsTyping = false;
                    if(inputPentagon.Content == "")
                        textBox.Text = "";
                    else
                        textBox.Text = inputPentagon.Content;
                    crrInput = inputPentagon;
                    textBox.Enabled = true;
                    textBox.Focus();
                }
                else if(inputStar.Rect.Contains(e.X, e.Y) && !inputStar.IsTyping)
                {
                    inputStar.IsTyping = true;
                    inputCircle.IsTyping = false;
                    inputTriangle.IsTyping = false;
                    inputSquare.IsTyping = false;
                    inputPentagon.IsTyping = false;
                    if(inputStar.Content == "")
                        textBox.Text = "";
                    else
                        textBox.Text = inputStar.Content;
                    crrInput = inputStar;
                    textBox.Enabled = true;
                    textBox.Focus();
                }
                else
                {
                    inputCircle.IsTyping = false;
                    inputTriangle.IsTyping = false;
                    inputSquare.IsTyping = false;
                    inputPentagon.IsTyping = false;
                    inputStar.IsTyping = false;
                    crrInput = null;
                    textBox.Enabled = false;
                }
            };
            
            textBox = new TextBox();
            textBox.Location = new Point(pb.Width / 2 - 75, pb.Height / 2 - 10);
            textBox.Size = new Size(150, 20);
            textBox.Visible = true;
            textBox.ReadOnly = false;
            textBox.TextChanged += textForResult;
            
            this.Controls.Add(textBox);

            void textForResult(object sender, EventArgs e)
            {
                if(crrInput is null)
                    return;
                if(crrInput.IsTyping)
                {
                    crrInput.Content = textBox.Text;
                    string text = "";
                    if(counter % 15 == 0)
                        this.showLine = !this.showLine;
                    if(showLine)
                        text = textBox.Text + "|";
                    else
                        text = textBox.Text;
                    Font font = new Font("Arial", pb.Width*0.0125f);
                    Brush brush = Brushes.Black;
                    SolidBrush white = new SolidBrush(Color.FromArgb(250, 249, 246));
                    g.FillRectangle(white, crrInput.Rect);
                    crrInput.DrawInputSprite(g, pb);
                    g.DrawString(text, font, brush, crrInput.Rect);
                }
            }
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
                Square quadrado = new(350, 800, 80, 5);
                shapes.Add(quadrado);

                Circle bola = new(550, 800, 80, 5);
                shapes.Add(bola);

                Triangle triangulo = new(750, 800, 80, 80, 5);
                shapes.Add(triangulo);

                Pentagon pentagono = new(950, 800, 80, 80, 5);
                shapes.Add(pentagono);

                Star estrela = new(1150, 800, 80, 80, 10);
                shapes.Add(estrela);
            }
        }

        void Frame()
        {
            this.counter++;
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
