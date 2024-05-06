using Components;
using Entities;
using Entities.EmptyShapes;
using Entities.Shapes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Utils;

namespace Views;

public partial class Challenge : Form
{
    private bool saveFlag = false;

    private Security security { get; set; }

    private PictureBox header;

    PictureBox pb;
    Bitmap bmp;
    Graphics g;
    Timer tm;

    private Stopwatch stopwatch;

    private Balance balanceLeft;
    private Balance balanceRight;

    private List<Shape> shapes;
    private List<EmptyShape> fixedPositions;

    private Shape selected;
    private Point cursor = new Point(0, 0);
    private bool isDown = false;

    private TextBox textBox;
    private InputUser crrInput;

    private InputUser inputCircle;
    private InputUser inputTriangle;
    private InputUser inputSquare;
    private InputUser inputPentagon;
    private InputUser inputStar;

    private bool showLine = false;
    private int counter = 0;

    private BtnFinish btnFinish;
    private BtnInitial btnVerify;

    private Image BackRect;

    public Challenge()
    {
        stopwatch = new(new(10, 100), new(200, 60));

        UserData.Current.DateStart = DateTime.Now;

        Completed completed = new();

        this.WindowState = FormWindowState.Maximized;
        this.FormBorderStyle = FormBorderStyle.None;
        this.Text = "Desafio";

        this.header = new PictureBox
        {
            Dock = DockStyle.Top,
            Height = (int)(16 * ClientScreen.HeightFactor),
            BackgroundImage = Resources.Rainbow,
            BackgroundImageLayout = ImageLayout.Stretch
        };
        this.Controls.Add(header);

        this.pb = new PictureBox { Dock = DockStyle.Fill };
        this.Controls.Add(pb);

        this.tm = new Timer { Interval = 10 };

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
            g.Clear(Color.FromArgb(250, 249, 246));
            this.pb.Image = bmp;
            this.tm.Start();

            Onstart();
        };

        this.pb.MouseMove += (o, e) =>
        {
            this.cursor = e.Location;
            if (btnFinish.Hitbox.Contains(cursor))
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
            g.Clear(Color.FromArgb(250, 249, 246));

            textForResult(o, e);
            stopwatch.Update();

            if (0 > stopwatch.GetTimeDifference().TotalMinutes && !saveFlag)
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


            Frame();
            pb.Refresh();
        };

        int TryParseOrDefault(string content)
        {
            string numericOnly = Regex.Replace(content, @"[^\d]", "");
            int result;
            return int.TryParse(numericOnly, out result) ? result : 0;
        }

        pb.MouseClick += (o, e) =>
        {
            if (btnFinish.Hitbox.Contains(e.X, e.Y))
                SaveData(completed);

            if (btnVerify.Hitbox.Contains(e.X, e.Y))
            {
                btnVerify.OnClick(balanceRight, balanceLeft);
                UserData.Current.MoveCounter++;
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
        BackRect = Resources.BackRect;

        InitializeWeights();
        InitializeBalances();
        InitializeButtons();
        InitializeInputs();
        InitializeShapes();
    }

    private void Frame()
    {
        this.counter++;

        DrawTitle("DESAFIO");
        DrawLogo();

        stopwatch.Draw(g);

        DrawInput();
        DrawBalances();

        btnFinish.Draw(g);
        btnVerify.Draw(g);

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
            var cusorInside = balanceLeft.LeftHitbox.IntersectsWith(selected.Hitbox);
            if (cusorInside && !isDown && selected.CanMove)
            {
                balanceLeft.AddLeftShape(selected);
                foreach (var fixedInitial in fixedPositions)
                {
                    if (fixedInitial.Shapes.Contains(selected))
                        fixedInitial.Shapes.Remove(selected);
                }
            }

            cusorInside = balanceLeft.RightHitbox.IntersectsWith(selected.Hitbox);
            if (cusorInside && !isDown && selected.CanMove)
            {
                balanceLeft.AddRightShape(selected);
                foreach (var fixedInitial in fixedPositions)
                {
                    if (fixedInitial.Shapes.Contains(selected))
                        fixedInitial.Shapes.Remove(selected);
                }
            }

            cusorInside = balanceRight.LeftHitbox.IntersectsWith(selected.Hitbox);
            if (cusorInside && !isDown && selected.CanMove)
            {
                balanceRight.AddLeftShape(selected);
                foreach (var fixedPosition in fixedPositions)
                {
                    if (fixedPosition.Shapes.Contains(selected))
                        fixedPosition.Shapes.Remove(selected);
                }
            }

            cusorInside = balanceRight.RightHitbox.IntersectsWith(selected.Hitbox);
            if (cusorInside && !isDown && selected.CanMove)
            {
                balanceRight.AddRightShape(selected);
                foreach (var fixedPosition in fixedPositions)
                {
                    if (fixedPosition.Shapes.Contains(selected))
                        fixedPosition.Shapes.Remove(selected);
                }
            }

            if (!isDown)
                this.selected = null;
        }
    }

    private void SaveData(Form nextForm)
    {
        try
        {
            if (!int.TryParse(inputCircle.Content, out var value1) ||
                        !int.TryParse(inputPentagon.Content, out var value2) ||
                        !int.TryParse(inputSquare.Content, out var value3) ||
                        !int.TryParse(inputStar.Content, out var value4) ||
                        !int.TryParse(inputTriangle.Content, out var value5)
                    )
            {
                MessageBox.Show("Valores são inválidos");
                return;
            }
            UserData.Current.InputCircleWeight = value1;
            UserData.Current.InputPentagonWeight = value2;
            UserData.Current.InputSquareWeight = value3;
            UserData.Current.InputStarWeight = value4;
            UserData.Current.InputTriangleWeight = value5;
            UserData.Current.DateFinish = DateTime.Now;
            btnFinish.FinishChallenge();
            btnFinish.CsvToExcel();
            this.Hide();
            nextForm.Show();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }
}