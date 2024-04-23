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
    // TODO:
    // public void UpdateBalanceSprite(){
    //     switch (this.BalanceState)
    //     {
    //         case BalanceState.Left:
    //             Sprite = 
    //         case BalanceState.Right:
    //             Sprite = 
    //         case BalanceState.None:
    //             Sprite = 
    //     }
    // }

    public void Update()
    {
        UpdateBalanceState();
    }

    public void Draw(Graphics g)
        => DrawBalance(g);

    private void DrawBalance(Graphics g)
    {
        float width = this.Width;
        float height = this.Height;
        float x = this.X + width / 2;
        float y = this.Y + height / 2;

        float factor  =  width / 450;

        var BaseBalance = new RectangleF(x - (width * 3 / 4) / 2, y + height / 2, width * 3 / 4, height / 15);
        var BalancerAxis = new RectangleF(x - 5, y - height / 2, 10, height);
        var BalancerSeesaw = new RectangleF(x - width / 2, y - width / 2 + 40, width, 40);

        var BalanceLeft = new RectangleF(x - width / 2 - BaseBalance.Width / 4 - 87.5f, y + 87.5f, BaseBalance.Width / 2 + 175, BaseBalance.Height);
        var BalanceRight = new RectangleF(x + width / 2 - BaseBalance.Width / 4 - 87.5f, y + 87.5f, BaseBalance.Width / 2 + 175, BaseBalance.Height);

        g.DrawLine(Pens.Black, BalancerSeesaw.Left, BalancerSeesaw.Bottom, BalanceLeft.Left, BalanceLeft.Top);
        g.DrawLine(Pens.Black, BalancerSeesaw.Left, BalancerSeesaw.Bottom, BalanceLeft.Left + BalanceLeft.Width / 2, BalanceLeft.Top);
        g.DrawLine(Pens.Black, BalancerSeesaw.Left, BalancerSeesaw.Bottom, BalanceLeft.Right, BalanceLeft.Top);

        g.DrawLine(Pens.Black, BalancerSeesaw.Right, BalancerSeesaw.Bottom, BalanceRight.Left, BalanceRight.Top);
        g.DrawLine(Pens.Black, BalancerSeesaw.Right, BalancerSeesaw.Bottom, BalanceRight.Left + BalanceRight.Width / 2, BalanceRight.Top);
        g.DrawLine(Pens.Black, BalancerSeesaw.Right, BalancerSeesaw.Bottom, BalanceRight.Right, BalanceRight.Top);

        // Desenhando os retângulos
        g.FillRectangle(Brushes.Black, BaseBalance);
        g.FillRectangle(Brushes.Black, BalancerAxis);
        g.FillRectangle(Brushes.DarkBlue, BalancerSeesaw);
        g.FillRectangle(Brushes.Gray, BalanceLeft);
        g.FillRectangle(Brushes.Gray, BalanceRight);

        var position1 = new RectangleF(BalanceLeft.Left + 5, BalanceLeft.Top - 75, 75, 75);
        var position2 = new RectangleF(position1.Right - 15, BalanceLeft.Top - 75, 75, 75);
        var position3 = new RectangleF(position2.Right - 15, BalanceLeft.Top - 75, 75, 75);
        var position4 = new RectangleF(position3.Right - 15, BalanceLeft.Top - 75, 75, 75);
        var position5 = new RectangleF(position4.Right - 15, BalanceLeft.Top - 75, 75, 75);

        g.FillRectangle(Brushes.Red, position1);
        g.FillRectangle(Brushes.Blue, position2);
        g.FillRectangle(Brushes.Green, position3);
        g.FillRectangle(Brushes.Yellow, position4);
        g.FillRectangle(Brushes.Orange, position5);


        // g.FillEllipse(Brushes.Red, x - 5, y - 5, 10, 10);
    }



    public int SumWeights(IEnumerable<Shape> shapes)
        => shapes.Sum(x => x.Weight);

}