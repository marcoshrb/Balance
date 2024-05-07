using Components;
using Entities;
using Entities.EmptyShapes;
using Entities.Shapes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Utils;

namespace Views;

public partial class Train : Form
{
    Security security;
    private Stopwatch basewatch;

    PictureBox header;

    PictureBox pb;
    Bitmap bmp;
    Graphics g;
    Timer tm;

    Balance balance;

    List<Shape> shapes;
    private List<EmptyShape> fixedPositions;

    Shape selected;
    Point cursor = new Point(0, 0);
    bool isDown = false;


    InputUser inputCircle = null;
    InputUser inputTriangle = null;
    InputUser inputSquare = null;
    InputUser inputPentagon = null;
    InputUser inputStar = null;
    TextBox textBox = null;
    InputUser crrInput = null;

    bool showLine = false;
    int counter = 0;
    public int Attemps = 0;

    Challenge challenge = null;

    BtnReset btnReset;
    BtnConfirm btnContinue;
    BtnInitial btnVerify;

    private Stopwatch stopwatch;

    Image BackRectTrain;
    Image BackRect;

    public Train()
    {
        basewatch = new(new(1460, 96), new(310, 90));

        BackRectTrain = Resources.BackRectTrain;
        BackRect = Resources.BackRectRight;

        this.WindowState = FormWindowState.Maximized;
        this.FormBorderStyle = FormBorderStyle.None;
        this.Text = "Treino";

        this.header = new PictureBox
        {
            Dock = DockStyle.Top,
            Height = (int)(10 * ClientScreen.HeightFactor),
            BackgroundImage = Image.FromFile(@"Assets\rainbow.png"),
            BackgroundImageLayout = ImageLayout.Stretch
        };
        this.Controls.Add(header);

        this.pb = new PictureBox { Dock = DockStyle.Fill };
        this.Controls.Add(pb);

        this.tm = new Timer { Interval = 20 };

        this.KeyDown += (o, e) =>
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    if (security is not null)
                        security.BringToFront();

                    security = new Security();
                    security.FormClosed += (sender, args) =>
                    {
                        security = null;
                    };
                    security.Show();
                    break;
            }
        };

        this.Load += (o, e) =>
        {
            this.bmp = new Bitmap(pb.Width, pb.Height);
            g = Graphics.FromImage(this.bmp);
            g.InterpolationMode = InterpolationMode.NearestNeighbor;
            g.Clear(Color.FromArgb(255, 255, 255));
            this.pb.Image = bmp;
            this.tm.Start();

            Onstart();
        };

        this.pb.MouseMove += (o, e) =>
        {
            this.cursor = e.Location;
            if (btnContinue.Rect.Contains(cursor))
                Cursor.Current = Cursors.Hand;
            if (btnReset.Rect.Contains(cursor))
                Cursor.Current = Cursors.Hand;
            if (btnVerify.Rect.Contains(cursor))
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

        this.tm.Tick += (o, e) =>
        {
            g.Clear(Color.FromArgb(250, 250, 250));

            DrawRectangleBack(Resources.BackRectTrain, 362, 830, 688, 192);
            DrawRectangleBack(Resources.BackRectRight, 1415, 54, 400, 974);

            textForResult(o, e);
            Frame();

            pb.Refresh();
        };

        pb.MouseClick += (o, e) =>
        {
            if (btnVerify.Rect.Contains(e.X, e.Y))
            {
                btnVerify.OnClick(balance);
                Attemps++;
            }

            if (btnContinue.Rect.Contains(e.X, e.Y))
            {
                this.Hide();
                this.challenge = new();
                challenge.Show();
            }

            if (btnReset.Rect.Contains(e.X, e.Y))
                Onstart();

            if (
                inputCircle.Rect.Contains(e.X, e.Y)
                && !inputCircle.IsTyping
                && !inputCircle.Disable
            )
            {
                inputCircle.IsTyping = true;
                inputTriangle.IsTyping = false;
                inputSquare.IsTyping = false;
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
                if (inputSquare.Content == "")
                    textBox.Text = "";
                else
                    textBox.Text = inputSquare.Content;
                crrInput = inputSquare;
                textBox.Enabled = true;
                textBox.Select(textBox.Text.Length, 0);
                textBox.Focus();
            }
            else
            {
                inputCircle.IsTyping = false;
                inputTriangle.IsTyping = false;
                inputSquare.IsTyping = false;
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
    }

    private void textForResult(object sender, EventArgs e)
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

    private void Onstart()
    {
        InitializeWeights();
        InitializeBalances();
        InitializeButtons();
        InitializeInputs();
        InitializeShapes();
    }

    private void Frame()
    {
        this.counter++;

        DrawTitle("TREINO");
        DrawLogo();
        DrawAttempts(1480, 225);

        basewatch.DrawAwait(g);

        DrawInput();
        DrawBalances();

        btnReset.DrawButton(g);
        btnContinue.DrawButton(g);
        btnVerify.DrawButton(g);

        DrawShapes();
    }

    private void AddShapes(EmptyShape emptyShape, Shape shape, int qtd = 5)
    {
        for (int i = 0; i < qtd; i++)
        {
            var clonedShape = shape.Clone() as Shape;
            emptyShape.AddFirst(clonedShape);
            this.shapes.Add(clonedShape);
        }
    }

    private void DropShape()
    {
        if (selected is not null)
        {
            var cusorInside = balance.LeftHitbox.IntersectsWith(selected.Hitbox);
            if (cusorInside && !isDown && selected.CanMove)
            {
                balance.AddLeftShape(selected);
                foreach (var fixedInitial in fixedPositions)
                {
                    if (fixedInitial.Shapes.Contains(selected))
                        fixedInitial.Shapes.Remove(selected);
                }
            }

            cusorInside = balance.RightHitbox.IntersectsWith(selected.Hitbox);
            if (cusorInside && !isDown && selected.CanMove)
            {
                balance.AddRightShape(selected);
                foreach (var fixedInitial in fixedPositions)
                {
                    if (fixedInitial.Shapes.Contains(selected))
                        fixedInitial.Shapes.Remove(selected);
                }
            }
            if (!isDown)
                this.selected = null;
        }
    }
}

