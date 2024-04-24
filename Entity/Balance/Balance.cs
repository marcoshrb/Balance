using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Utils;

public class Balance
{
    public BalanceState BalanceState;
    public float X { get; set; }
    public float Y { get; set; }
    public float Width { get; set; }
    public float Height { get; set; }
    public Rectangle leftHitbox;
    public Rectangle rightHitbox;
    private List<Shape> leftShapes;
    private List<Shape> rightShapes;
    public List<Shape> RightShapes => rightShapes.ToList();
    public List<Shape> LeftShapes => leftShapes.ToList();
    public Balance(float x, float y, float width, float height)
    {
        this.BalanceState = BalanceState.None;
        this.leftShapes = new();
        this.rightShapes = new();
        this.X = x;
        this.Y = y;
        this.Width = width;
        this.Height = height;
    }

    public void AddLeft(Shape shape)
    {
        this.leftShapes.Add(shape);
        UpdateBalanceState();
    }
    public void AddRight(Shape shape)
    {
        this.rightShapes.Add(shape);
        UpdateBalanceState();
    }

    private void UpdateBalanceState()
    {
        var sumLeft = SumWeights(this.leftShapes);
        var sumRight = SumWeights(this.rightShapes);

        if (sumLeft > sumRight)
            BalanceState = BalanceState.Left;
        else if (sumLeft < sumRight)
            BalanceState = BalanceState.Right;
        else
            BalanceState = BalanceState.None;
    }

    public void Update()
    {
        UpdateBalanceState();
    }

    public void Draw(Graphics g)
        => DrawBalance(g);

    int angle = 0;
    private void DrawBalance(Graphics g)
    {
        float width = this.Width;
        float height = this.Height;
        float x = this.X + width / 2;
        float y = this.Y + height / 2;

        float widthFactor = width / 400;
        float heightFactor = height / 400;

        var BaseBalance = new RectangleF(x - (width * 3f / 4f) / 2f, y + height / 2f, width * 3f / 4f, height / 15f);
        var BalancerAxis = new RectangleF(x - (widthFactor * 10f / 2f), y - height / 2f, widthFactor * 10f, height);
        var BalancerSeesaw = new RectangleF(x - width / 2f, y - height / 2f + heightFactor * 40f, width, heightFactor * 40f);

        g.FillRectangle(Brushes.Black, BaseBalance);
        g.FillRectangle(Brushes.Black, BalancerAxis);

        var rotateBalancerSeesaw = Functions.ToPolygon(BalancerSeesaw, new(BalancerSeesaw.Left + BalancerSeesaw.Width / 2f, BalancerSeesaw.Top + BalancerSeesaw.Height / 2f), angle);
        var BalanceLeft = new RectangleF(rotateBalancerSeesaw[3].X - (BaseBalance.Width / 2f + widthFactor * 180f) / 2f, rotateBalancerSeesaw[3].Y + (183f * heightFactor), BaseBalance.Width / 2f + widthFactor * 180f, BaseBalance.Height);
        var BalanceRight = new RectangleF(rotateBalancerSeesaw[2].X - (BaseBalance.Width / 2f + widthFactor * 180f) / 2f, rotateBalancerSeesaw[2].Y + (183f * heightFactor), BaseBalance.Width / 2f + widthFactor * 180f, BaseBalance.Height);


        g.DrawLine(Pens.Black, rotateBalancerSeesaw[3].X, rotateBalancerSeesaw[3].Y, BalanceLeft.Left, BalanceLeft.Top);
        g.DrawLine(Pens.Black, rotateBalancerSeesaw[3].X, rotateBalancerSeesaw[3].Y, BalanceLeft.Left + BalanceLeft.Width / 2, BalanceLeft.Top);
        g.DrawLine(Pens.Black, rotateBalancerSeesaw[3].X, rotateBalancerSeesaw[3].Y, BalanceLeft.Right, BalanceLeft.Top);

        g.DrawLine(Pens.Black, rotateBalancerSeesaw[2].X, rotateBalancerSeesaw[2].Y, BalanceRight.Left, BalanceRight.Top);
        g.DrawLine(Pens.Black, rotateBalancerSeesaw[2].X, rotateBalancerSeesaw[2].Y, BalanceRight.Left + BalanceRight.Width / 2, BalanceRight.Top);
        g.DrawLine(Pens.Black, rotateBalancerSeesaw[2].X, rotateBalancerSeesaw[2].Y, BalanceRight.Right, BalanceRight.Top);

        g.TranslateTransform(
            BalancerSeesaw.Left + BalancerSeesaw.Width / 2,
            BalancerSeesaw.Top + BalancerSeesaw.Height / 2
        );


        g.RotateTransform(angle);

        g.TranslateTransform(
            -(BalancerSeesaw.Left + BalancerSeesaw.Width / 2),
            -(BalancerSeesaw.Top + BalancerSeesaw.Height / 2)
        );


        g.FillRectangle(Brushes.DarkBlue, BalancerSeesaw);

        g.ResetTransform();

        angle--;

        g.FillRectangle(Brushes.Gray, BalanceLeft);
        g.FillRectangle(Brushes.Gray, BalanceRight);

        var position1 = new RectangleF(BalanceLeft.Left, BalanceLeft.Top - heightFactor * 70, widthFactor * 70, heightFactor * 70);
        var position2 = new RectangleF(position1.Right - widthFactor * 5, BalanceLeft.Top - heightFactor * 70, widthFactor * 70, heightFactor * 70);
        var position3 = new RectangleF(position2.Right - widthFactor * 5, BalanceLeft.Top - heightFactor * 70, widthFactor * 70, heightFactor * 70);
        var position4 = new RectangleF(position3.Right - widthFactor * 5, BalanceLeft.Top - heightFactor * 70, widthFactor * 70, heightFactor * 70);
        var position5 = new RectangleF(position4.Right - widthFactor * 5, BalanceLeft.Top - heightFactor * 70, widthFactor * 70, heightFactor * 70);

        g.FillRectangle(Brushes.Red, position1);
        g.FillRectangle(Brushes.Blue, position2);
        g.FillRectangle(Brushes.Green, position3);
        g.FillRectangle(Brushes.Yellow, position4);
        g.FillRectangle(Brushes.Orange, position5);
    }

    public void Animate(){
        
    }

    public int SumWeights(IEnumerable<Shape> shapes)
        => shapes.Sum(x => x.Weight);

}