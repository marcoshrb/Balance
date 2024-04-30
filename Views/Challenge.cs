using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Entities;
using Entities.EmptyShapes;
using Entities.Shapes;
using Utils;
using Views.Components;

namespace Views
{
    public class Challenge : Form
    {
        bool saveFlag = false;
        Label horario;
        PictureBox cronometro;
        PictureBox borda;
        DateTime horarioFuturo;
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

        TextBox textBox = null;
        InputUser crrInput = null;

        InputUser inputCircle = null;
        InputUser inputTriangle = null;
        InputUser inputSquare = null;
        InputUser inputPentagon = null;
        InputUser inputStar = null;
        bool showLine = false;
        int counter = 0;
        Font font = new Font("neology", 72, FontStyle.Bold);
        SolidBrush brush = new SolidBrush(Color.FromArgb(234, 0, 22));

        int[] weights;

        BtnFinish btnFinish = null;
        public Challenge()
        {
            UserData.Current.DateStart = DateTime.Now;
            Completed completed = new();

            horario = new Label
            {
                Text = "Horas",
                Size = new Size(
                    (int)(185 * ClientScreen.WidthFactor),
                    (int)(50 * ClientScreen.HeightFactor)
                    ),
                BackColor = Color.White,
                Font = new Font("Arial", 30 * ClientScreen.WidthFactor, FontStyle.Bold),
                Location = new Point(
                    ClientSize.Width - (int)(282 * ClientScreen.WidthFactor),
                    (int)(43 * ClientScreen.HeightFactor)
                ),
                Anchor = AnchorStyles.Top | AnchorStyles.Right
            };
            Controls.Add(horario);

            cronometro = new PictureBox
            {
                BackColor = Color.White,
                Size = new Size(
                    (int)(190 * ClientScreen.WidthFactor),
                    (int)(55 * ClientScreen.HeightFactor)
                    ),
                Location = new Point(
                    ClientSize.Width - (int)(285 * ClientScreen.WidthFactor),
                    (int)(40 * ClientScreen.HeightFactor)
                ),
                Anchor = AnchorStyles.Top | AnchorStyles.Right
            };
            Controls.Add(cronometro);

            borda = new PictureBox
            {
                BackColor = Color.Black,
                Size = new Size(
                    (int)(200 * ClientScreen.WidthFactor),
                    (int)(65 * ClientScreen.HeightFactor)
                    ),
                Location = new Point(ClientSize.Width - (int)(290 * ClientScreen.WidthFactor), (int)(35 * ClientScreen.HeightFactor)),
                Anchor = AnchorStyles.Top | AnchorStyles.Right
            };
            Controls.Add(borda);

            horarioFuturo = DateTime.Now.AddMinutes(30); //tempo

            int[] array = { 2, 3, 5, 8, 10 };
            this.weights = Functions.ShuffleWeights(array);
            this.balanceLeft = new Balance(
                200 * ClientScreen.WidthFactor,
                300 * ClientScreen.HeightFactor,
                350 * ClientScreen.WidthFactor,
                350 * ClientScreen.HeightFactor
            );
            this.balanceRight = new Balance(
                950 * ClientScreen.WidthFactor,
                300 * ClientScreen.HeightFactor,
                350 * ClientScreen.WidthFactor,
                350 * ClientScreen.HeightFactor
            );

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

            this.tm = new Timer { Interval = 10 };

            // sair
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

                UserData.Current.RealCircleWeight = weights[0];
                UserData.Current.RealPentagonWeight = weights[1];
                UserData.Current.RealSquareWeight = weights[2];
                UserData.Current.RealStarWeight = weights[3];
                UserData.Current.RealTriangleWeight = weights[4];

                inputCircle = new InputUser(
                    pb.Width * 0.85f,
                    pb.Height * 0.15f,
                    pb.Width * 0.1f,
                    pb.Height * 0.04f,
                    ImageProcessing.GetImage(@"./Assets/Shapes/pieces/Bola.png") as Bitmap
                );
                inputPentagon = new InputUser(
                    pb.Width * 0.85f,
                    pb.Height * 0.20f,
                    pb.Width * 0.1f,
                    pb.Height * 0.04f,
                    ImageProcessing.GetImage(@"./Assets/Shapes/pieces/Pentagono.png") as Bitmap
                );
                inputSquare = new InputUser(
                    pb.Width * 0.85f,
                    pb.Height * 0.25f,
                    pb.Width * 0.1f,
                    pb.Height * 0.04f,
                    ImageProcessing.GetImage(@"./Assets/Shapes/pieces/Quadrado.png") as Bitmap
                )
                {
                    Content = weights[2].ToString(),
                    Disable = true
                };
                inputStar = new InputUser(
                    pb.Width * 0.85f,
                    pb.Height * 0.30f,
                    pb.Width * 0.1f,
                    pb.Height * 0.04f,
                    ImageProcessing.GetImage(@"./Assets/Shapes/pieces/Estrela.png") as Bitmap
                );
                inputTriangle = new InputUser(
                    pb.Width * 0.85f,
                    pb.Height * 0.35f,
                    pb.Width * 0.1f,
                    pb.Height * 0.04f,
                    ImageProcessing.GetImage(@"./Assets/Shapes/pieces/Triangulo.png") as Bitmap
                );

                btnFinish = new BtnFinish(pb.Width * 0.85f, pb.Height * 0.85f, pb.Width * 0.104f, pb.Height * 0.092f, "Finalizar");
                btnFinish.DrawButton(g);
            };

            this.pb.MouseMove += (o, e) =>
            {
                cursor = e.Location;
                if (btnFinish.Rect.Contains(cursor))
                    Cursor.Current = Cursors.Hand;

            };

            this.pb.MouseDown += (o, e) =>
            {
                isDown = true;
            };

            this.pb.MouseUp += (o, e) =>
            {
                isDown = false;
            };

            //Tirar quando for gerar o executavel
            this.FormClosed += delegate
            {
                Application.Exit();
            };

            this.tm.Tick += (o, e) =>
            {
                g.Clear(Color.FromArgb(250, 249, 246));
                int x_Title = (int)(500 * ClientScreen.WidthFactor);
                int y_Title = (int)(100 * ClientScreen.HeightFactor);
                g.DrawString(
                    "DESAFIO",
                    font,
                    brush,
                    x_Title,
                    y_Title);
                DrawRectangleBack(290, 750, 1000, 200);
                DrawRectangleBack(1550, -100, 500, 1300);
                balanceLeft.Draw(this.g);
                balanceRight.Draw(this.g);
                inputCircle.DrawInputSprite(g, pb);
                inputTriangle.DrawInputSprite(g, pb);
                inputSquare.DrawInputSprite(g, pb);
                inputPentagon.DrawInputSprite(g, pb);
                inputStar.DrawInputSprite(g, pb);
                textForResult(o, e);
                horario.Text = string.Format("{0:mm\\:ss}", horarioFuturo - DateTime.Now);
                if (0 > (horarioFuturo - DateTime.Now).TotalMinutes && !saveFlag)
                {
                    try
                    {
                        UserData.Current.InputCircleWeight = TryParseOrDefault(inputCircle.Content);
                        UserData.Current.InputPentagonWeight = TryParseOrDefault(inputPentagon.Content);
                        UserData.Current.InputSquareWeight = TryParseOrDefault(inputSquare.Content);
                        UserData.Current.InputStarWeight = TryParseOrDefault(inputStar.Content);
                        UserData.Current.InputTriangleWeight = TryParseOrDefault(inputTriangle.Content);
                        UserData.Current.DateFinish = DateTime.Now;
                        btnFinish.FinishChallenge();
                        btnFinish.CsvToExcel();
                        this.Hide();
                        completed.Show();
                        saveFlag = true;
                    }
                    catch (System.Exception)
                    { }
                }
                btnFinish.DrawButton(g);
                Frame();
                pb.Refresh();
            };

            int TryParseOrDefault(string content)
            {
                // Remove todos os caracteres não numéricos da string
                string numericOnly = Regex.Replace(content, @"[^\d]", "");

                int result;
                return int.TryParse(numericOnly, out result) ? result : 0;
            }

            pb.MouseClick += (o, e) =>
            {
                if (btnFinish.Rect.Contains(e.X, e.Y))
                {
                    try
                    {
                        if (!int.TryParse(inputCircle.Content, out var valor1) ||
                            !int.TryParse(inputPentagon.Content, out var valor2) ||
                            !int.TryParse(inputSquare.Content, out var valor3) ||
                            !int.TryParse(inputStar.Content, out var valor4) ||
                            !int.TryParse(inputTriangle.Content, out var valor5)
                        )
                        {
                            MessageBox.Show("Valores inválidos");
                            return;
                        }
                        UserData.Current.InputCircleWeight = valor1;
                        UserData.Current.InputPentagonWeight = valor2;
                        UserData.Current.InputSquareWeight = valor3;
                        UserData.Current.InputStarWeight = valor4;
                        UserData.Current.InputTriangleWeight = valor5;
                        UserData.Current.DateFinish = DateTime.Now;
                        btnFinish.FinishChallenge();
                        btnFinish.CsvToExcel();
                        this.Hide();
                        completed.Show();
                    }
                    catch (System.Exception)
                    {
                        MessageBox.Show("Valores inválidos");
                    }
                }

                if (
                    inputCircle.Rect.Contains(e.X, e.Y)
                    && !inputCircle.IsTyping
                    && !inputCircle.Disable
                )
                {
                    inputCircle.IsTyping = true;
                    inputTriangle.IsTyping = false;
                    inputSquare.IsTyping = false;
                    inputPentagon.IsTyping = false;
                    inputStar.IsTyping = false;
                    if (inputCircle.Content == "")
                        textBox.Text = "";
                    else
                        textBox.Text = inputCircle.Content;
                    crrInput = inputCircle;
                    textBox.Enabled = true;
                    textBox.Select(textBox.Text.Length, 0);
                    textBox.Focus();
                }
                else if (
                    inputTriangle.Rect.Contains(e.X, e.Y)
                    && !inputTriangle.IsTyping
                    && !inputTriangle.Disable
                )
                {
                    inputTriangle.IsTyping = true;
                    inputCircle.IsTyping = false;
                    inputSquare.IsTyping = false;
                    inputPentagon.IsTyping = false;
                    inputStar.IsTyping = false;
                    if (inputTriangle.Content == "")
                        textBox.Text = "";
                    else
                        textBox.Text = inputTriangle.Content;
                    crrInput = inputTriangle;
                    textBox.Enabled = true;
                    textBox.Select(textBox.Text.Length, 0);
                    textBox.Focus();
                }
                else if (
                    inputSquare.Rect.Contains(e.X, e.Y)
                    && !inputSquare.IsTyping
                    && !inputSquare.Disable
                )
                {
                    inputSquare.IsTyping = true;
                    inputCircle.IsTyping = false;
                    inputTriangle.IsTyping = false;
                    inputPentagon.IsTyping = false;
                    inputStar.IsTyping = false;
                    if (inputSquare.Content == "")
                        textBox.Text = "";
                    else
                        textBox.Text = inputSquare.Content;
                    crrInput = inputSquare;
                    textBox.Enabled = true;
                    textBox.Select(textBox.Text.Length, 0);
                    textBox.Focus();
                }
                else if (
                    inputPentagon.Rect.Contains(e.X, e.Y)
                    && !inputPentagon.IsTyping
                    && !inputPentagon.Disable
                )
                {
                    inputPentagon.IsTyping = true;
                    inputCircle.IsTyping = false;
                    inputTriangle.IsTyping = false;
                    inputSquare.IsTyping = false;
                    inputStar.IsTyping = false;
                    if (inputPentagon.Content == "")
                        textBox.Text = "";
                    else
                        textBox.Text = inputPentagon.Content;
                    crrInput = inputPentagon;
                    textBox.Enabled = true;
                    textBox.Select(textBox.Text.Length, 0);
                    textBox.Focus();
                }
                else if (
                    inputStar.Rect.Contains(e.X, e.Y)
                    && !inputStar.IsTyping
                    && !inputStar.Disable
                )
                {
                    inputStar.IsTyping = true;
                    inputCircle.IsTyping = false;
                    inputTriangle.IsTyping = false;
                    inputSquare.IsTyping = false;
                    inputPentagon.IsTyping = false;
                    if (inputStar.Content == "")
                        textBox.Text = "";
                    else
                        textBox.Text = inputStar.Content;
                    crrInput = inputStar;
                    textBox.Enabled = true;
                    textBox.Select(textBox.Text.Length, 0);
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
            textBox = new TextBox
            {
                Location = new Point(pb.Width / 2 - 75, pb.Height / 2 - 10),
                Size = new Size(150, 20),
                Visible = true,
                ReadOnly = false
            };
            textBox.TextChanged += textForResult;

            this.Controls.Add(textBox);

            void textForResult(object sender, EventArgs e)
            {
                if (crrInput is null)
                    return;
                if (crrInput.IsTyping)
                {
                    crrInput.Content = textBox.Text;
                    string text = "";
                    if (counter % 15 == 0)
                        this.showLine = !this.showLine;
                    if (showLine)
                        text = textBox.Text + "|";
                    else
                        text = textBox.Text;
                    Font font = new Font("Arial", pb.Width * 0.0125f);
                    Brush brush = Brushes.Black;
                    SolidBrush white = new SolidBrush(Color.FromArgb(250, 249, 246));
                    g.FillRectangle(white, crrInput.Rect);
                    crrInput.DrawInputSprite(g, pb);
                    g.DrawString(text, font, brush, crrInput.Rect);
                }
            }
        }

        private List<EmptyShape> fixedInitials = new List<EmptyShape>();
        Image BackRect;
        void Onstart()
        {
            BackRect = Resources.BackRect;
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

            EmptyCircle emptyCircle = new EmptyCircle(
                new PointF(350 * ClientScreen.WidthFactor, 800 * ClientScreen.HeightFactor),
                100,
                100
            );

            EmptyPentagon emptyPentagon = new EmptyPentagon(
                new PointF(550 * ClientScreen.WidthFactor, 800 * ClientScreen.HeightFactor),
                100,
                100
            );

            EmptySquare emptySquare = new EmptySquare(
                new PointF(750 * ClientScreen.WidthFactor, 800 * ClientScreen.HeightFactor),
                100,
                100
            );

            EmptyStar emptyStar = new EmptyStar(
                new PointF(950 * ClientScreen.WidthFactor, 800 * ClientScreen.HeightFactor),
                100,
                100
            );

            EmptyTriangle emptyTriangle = new EmptyTriangle(
                new PointF(1150 * ClientScreen.WidthFactor, 800 * ClientScreen.HeightFactor),
                100,
                100
            );

            fixedInitials.Add(emptyCircle);
            fixedInitials.Add(emptyPentagon);
            fixedInitials.Add(emptySquare);
            fixedInitials.Add(emptyStar);
            fixedInitials.Add(emptyTriangle);

            for (int i = 0; i < 5; i++)
            {
                circle = new(
                    550 * ClientScreen.WidthFactor,
                    800 * ClientScreen.HeightFactor,
                    100 * ClientScreen.WidthFactor,
                    weights[0]
                );
                shapes.Add(circle);
                emptyCircle.AddFirst(circle);

                pentagon = new(
                    950 * ClientScreen.WidthFactor,
                    800 * ClientScreen.HeightFactor,
                    100 * ClientScreen.WidthFactor,
                    100 * ClientScreen.WidthFactor,
                    weights[1]
                );
                shapes.Add(pentagon);
                emptyPentagon.AddFirst(pentagon);

                square = new(
                    350 * ClientScreen.WidthFactor,
                    800 * ClientScreen.HeightFactor,
                    100 * ClientScreen.WidthFactor,
                    weights[2]
                );
                shapes.Add(square);
                emptySquare.AddFirst(square);

                star = new(
                    1150 * ClientScreen.WidthFactor,
                    800 * ClientScreen.HeightFactor,
                    100 * ClientScreen.WidthFactor,
                    100 * ClientScreen.WidthFactor,
                    weights[3]
                );
                shapes.Add(star);
                emptyStar.AddFirst(star);

                triangle = new(
                    750 * ClientScreen.WidthFactor,
                    800 * ClientScreen.HeightFactor,
                    100 * ClientScreen.WidthFactor,
                    100 * ClientScreen.WidthFactor,
                    weights[4]
                );
                shapes.Add(triangle);
                emptyTriangle.AddFirst(triangle);
            }
        }

        Circle circle;
        Pentagon pentagon;
        Square square;
        Star star;
        Triangle triangle;

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

            foreach (var fixedBalance in fixedInitials)
                fixedBalance.Draw(this.g);

            foreach (var shape in shapes)
            {
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
                    foreach (var fixedInitial in fixedInitials)
                    {
                        if (fixedInitial.Shapes.Contains(selected))
                            fixedInitial.Shapes.Remove(selected);
                    }
                }

                cusorInside = balanceLeft.RightHitbox.IntersectsWith(selected.Hitbox);
                if (cusorInside && !isDown && selected.CanMove)
                {
                    balanceLeft.AddRightShape(selected);
                    foreach (var fixedInitial in fixedInitials)
                    {
                        if (fixedInitial.Shapes.Contains(selected))
                            fixedInitial.Shapes.Remove(selected);
                    }
                }

                cusorInside = balanceRight.LeftHitbox.IntersectsWith(selected.Hitbox);
                if (cusorInside && !isDown && selected.CanMove)
                {
                    balanceRight.AddLeftShape(selected);
                    foreach (var fixedInitial in fixedInitials)
                    {
                        if (fixedInitial.Shapes.Contains(selected))
                            fixedInitial.Shapes.Remove(selected);
                    }
                }

                cusorInside = balanceRight.RightHitbox.IntersectsWith(selected.Hitbox);
                if (cusorInside && !isDown && selected.CanMove)
                {
                    balanceRight.AddRightShape(selected);
                    foreach (var fixedInitial in fixedInitials)
                    {
                        if (fixedInitial.Shapes.Contains(selected))
                            fixedInitial.Shapes.Remove(selected);
                    }
                }

                if (!isDown)
                    this.selected = null;
            }

            foreach (var item in balanceLeft.ShapesOnLeftSide)
                if (item.Shapes.Count != 0)
                    item.DrawString(this.g);

            foreach (var item in balanceLeft.ShapesOnRightSide)
                if (item.Shapes.Count != 0)
                    item.DrawString(this.g);

            foreach (var item in balanceRight.ShapesOnLeftSide)
                if (item.Shapes.Count != 0)
                    item.DrawString(this.g);

            foreach (var item in balanceRight.ShapesOnRightSide)
                if (item.Shapes.Count != 0)
                    item.DrawString(g);

            foreach (var shape in shapes)
                shape.UpdateHitbox();

            foreach (var fixedInitial in fixedInitials)
                fixedInitial.DrawString(this.g);


        }
        void DrawRectangleBack(int x_, int y_, int width_, int height_)
        {
            Size backSize = new Size(
                (int)(width_ * ClientScreen.WidthFactor),
                (int)(height_ * ClientScreen.HeightFactor)
            );
            Image resizedBack = ImageProcessing.ResizeImage(BackRect, backSize);
            int x_Back = (int)(x_ * ClientScreen.WidthFactor);
            int y_Back = (int)(y_ * ClientScreen.HeightFactor);
            g.DrawImage(resizedBack, new Point(x_Back, y_Back));
        }
    }
}
