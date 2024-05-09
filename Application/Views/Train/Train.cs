using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Components;
using Entities;
using Entities.EmptyShapes;
using Entities.Shapes;
using Utils;

namespace Views;

public partial class Train : Form
{
    private string userName = "";

    public Security security { get; set; }
    private Stopwatch basewatch;

    public int MoveCounter;
    public int UsedPiecesCount;

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

    InputUser inputLogin;
    InputUser inputCircle = null;
    InputUser inputTriangle = null;
    InputUser inputSquare = null;

    TextBox textBox = null;
    InputUser crrInput = null;

    bool showLine = false;
    int counter = 0;
    BtnConfirm btnConfirm;
    Challenge challenge = null;

    BtnReset btnReset;
    BtnInitial btnVerify;
    Image BackRectTrain;
    Image BackRect;

    public Train()
    {
        basewatch = new(new(1460, 96), new(310, 90));

        BackRectTrain = Resources.BackRectTrain;
        BackRect = Resources.BackRectRight;

        this.WindowState = FormWindowState.Maximized;
        this.FormBorderStyle = FormBorderStyle.None;
        this.Text = "Teste";

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
            UserData.New();
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
            if (btnReset.Hitbox.Contains(cursor))
                Cursor.Current = Cursors.Hand;
            if (btnVerify.Hitbox.Contains(cursor))
                Cursor.Current = Cursors.Hand;
            if (btnConfirm.Hitbox.Contains(cursor))
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

        DateTime lastChecked = DateTime.Now;
        int frameCount = 0;
        float fps = 0;

        this.tm.Tick += (o, e) =>
        {
            g.Clear(Color.FromArgb(255, 255, 255));

            DrawBackground(g);

            textForResult(o, e);
            Frame();

            frameCount++;
            TimeSpan elapsedTime = DateTime.Now - lastChecked;
            if (elapsedTime.TotalMilliseconds >= 50)
            {
                fps = frameCount / (float)elapsedTime.TotalSeconds;
                lastChecked = DateTime.Now;
                frameCount = 0;
            }

            g.DrawString($"FPS: {fps}", SystemFonts.DefaultFont, Brushes.Black, 10, 50);

            pb.Refresh();
        };

        pb.MouseClick += (o, e) =>
        {
            if (btnVerify.Hitbox.Contains(e.X, e.Y))
            {
                btnVerify.OnClick(balance);
                MoveCounter++;
            }

            if (btnReset.Hitbox.Contains(e.X, e.Y))
            {
                InitializeBalances();
                InitializeShapes();
            }

            if (btnConfirm.Hitbox.Contains(e.X, e.Y))
            {
                if (this.userName.Length > 0)
                {
                    UserData.Current.UserName = this.userName;
                    UserData.Current.DateStart = DateTime.Now;
                    this.Hide();
                    challenge = new();
                    challenge.Show();

                    // var challenge = new Challenge();
                    // challenge.Show();
                }
                else
                {
                    MessageBox.Show("Vazio, Preencha os campos com seus dados");
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
                inputLogin.IsTyping = false;
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
                inputLogin.IsTyping = false;
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
                inputLogin.IsTyping = false;
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
                inputLogin.Rect.Contains(e.X, e.Y)
                && !inputLogin.IsTyping
                && !inputLogin.Disable
            )
            {
                inputSquare.IsTyping = false;
                inputCircle.IsTyping = false;
                inputTriangle.IsTyping = false;
                inputLogin.IsTyping = true;
                if (inputLogin.Content == "")
                    textBox.Text = "";
                else
                    textBox.Text = inputLogin.Content;
                crrInput = inputLogin;
                textBox.Enabled = true;
                textBox.Select(textBox.Text.Length, 0);
                textBox.Focus();
            }
            else
            {
                inputCircle.IsTyping = false;
                inputTriangle.IsTyping = false;
                inputSquare.IsTyping = false;
                inputLogin.IsTyping = false;
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

    private int countSize = 0;
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
        // DrawLogo();
        DrawAttempts(1480, 225);

        // basewatch.DrawAwait(g);

        DrawInput();
        DrawBalances();

        btnReset.Draw(g);
        btnVerify.Draw(g);
        btnConfirm.Draw(g);

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
                UsedPiecesCount++;
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
                UsedPiecesCount++;
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
