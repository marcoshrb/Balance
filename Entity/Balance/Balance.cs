using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Entities.Shapes;
using Utils;

namespace Entities;

public class Balance : Entity
{
    public int State;
    public RectangleF LeftHitbox;
    public RectangleF RightHitbox;
    private List<Shape> LeftShapes;
    private List<Shape> RightShapes;
    public List<Shape> ShapesOnLeftSide => LeftShapes.ToList();
    public List<Shape> ShapesOnRightSide => RightShapes.ToList();
    private int SlowFrameRate = 0;
    private int Angle = 10;

    public Balance(float x, float y, float width, float height) : base(x, y, width, height)
    {
        State = (int)BalanceState.None;
        LeftShapes = new();
        RightShapes = new();
    }

    public void AddLeftShape(Shape shape)
    {
        shape.CanMove = false;
        shape.Position = new Point(0, 0);
        LeftShapes.Add(shape);
        UpdateBalanceState();
    }

    public void AddRightShape(Shape shape)
    {
        shape.CanMove = false;
        shape.Position = new Point(0, 0);
        RightShapes.Add(shape);
        UpdateBalanceState();
    }

    private void UpdateBalanceState()
    {
        var sumLeft = CalculateTotalWeight(LeftShapes);
        var sumRight = CalculateTotalWeight(RightShapes);

        if (sumLeft > sumRight)
            State = (int)BalanceState.Left;
        else if (sumLeft < sumRight)
            State = (int)BalanceState.Right;
        else
            State = (int)BalanceState.None;
    }

    public override void Update() => UpdateBalanceState();

    public override void Draw(Graphics g) => DrawBalance(g);

    private void DrawBalance(Graphics g)
    {
        Animate();
        float width = Width;
        float height = Height;
        float x = X + width / 2;
        float y = Y + height / 2;

        float widthFactor = width / 400;
        float heightFactor = height / 400;

        var baseBalance = new RectangleF(
            x - (width * 3f / 4f) / 2f,
            y + height / 2f,
            width * 3f / 4f,
            height / 15f
        );
        var balancerAxis = new RectangleF(
            x - (widthFactor * 10f / 2f),
            y - height / 2f,
            widthFactor * 10f,
            height
        );
        var balancerSeesaw = new RectangleF(
            x - width / 2f,
            y - height / 2f + heightFactor * 40f,
            width,
            heightFactor * 40f
        );

        g.FillRectangle(Brushes.Black, baseBalance);
        g.FillRectangle(Brushes.Black, balancerAxis);

        var rotatedBalancerSeesaw = Functions.ToPolygon(
            balancerSeesaw,
            new(
                balancerSeesaw.Left + balancerSeesaw.Width / 2f,
                balancerSeesaw.Top + balancerSeesaw.Height / 2f
            ),
            Angle
        );
        var balanceLeft = new RectangleF(
            rotatedBalancerSeesaw[3].X - (baseBalance.Width / 2f + widthFactor * 180f) / 2f,
            rotatedBalancerSeesaw[3].Y + (183f * heightFactor),
            baseBalance.Width / 2f + widthFactor * 180f,
            baseBalance.Height
        );
        var balanceRight = new RectangleF(
            rotatedBalancerSeesaw[2].X - (baseBalance.Width / 2f + widthFactor * 180f) / 2f,
            rotatedBalancerSeesaw[2].Y + (183f * heightFactor),
            baseBalance.Width / 2f + widthFactor * 180f,
            baseBalance.Height
        );

        this.LeftHitbox = new RectangleF((float)balanceLeft.Left, (float)rotatedBalancerSeesaw[3].Y, (float)balanceLeft.Width, (float)balanceLeft.Bottom - (float)rotatedBalancerSeesaw[3].Y);
        this.RightHitbox = new RectangleF((float)balanceRight.Left, (float)rotatedBalancerSeesaw[2].Y, (float)balanceRight.Width, (float)balanceRight.Bottom - (float)rotatedBalancerSeesaw[2].Y);


        g.DrawLine(
            Pens.Black,
            rotatedBalancerSeesaw[3].X,
            rotatedBalancerSeesaw[3].Y,
            balanceLeft.Left,
            balanceLeft.Top
        );
        g.DrawLine(
            Pens.Black,
            rotatedBalancerSeesaw[3].X,
            rotatedBalancerSeesaw[3].Y,
            balanceLeft.Left + balanceLeft.Width / 2,
            balanceLeft.Top
        );
        g.DrawLine(
            Pens.Black,
            rotatedBalancerSeesaw[3].X,
            rotatedBalancerSeesaw[3].Y,
            balanceLeft.Right,
            balanceLeft.Top
        );

        g.DrawLine(
            Pens.Black,
            rotatedBalancerSeesaw[2].X,
            rotatedBalancerSeesaw[2].Y,
            balanceRight.Left,
            balanceRight.Top
        );
        g.DrawLine(
            Pens.Black,
            rotatedBalancerSeesaw[2].X,
            rotatedBalancerSeesaw[2].Y,
            balanceRight.Left + balanceRight.Width / 2,
            balanceRight.Top
        );
        g.DrawLine(
            Pens.Black,
            rotatedBalancerSeesaw[2].X,
            rotatedBalancerSeesaw[2].Y,
            balanceRight.Right,
            balanceRight.Top
        );

        g.TranslateTransform(
            balancerSeesaw.Left + balancerSeesaw.Width / 2,
            balancerSeesaw.Top + balancerSeesaw.Height / 2
        );

        g.RotateTransform(Angle);

        g.TranslateTransform(
            -(balancerSeesaw.Left + balancerSeesaw.Width / 2),
            -(balancerSeesaw.Top + balancerSeesaw.Height / 2)
        );

        g.FillRectangle(Brushes.DarkBlue, balancerSeesaw);

        g.ResetTransform();

        g.FillRectangle(Brushes.Gray, balanceLeft);
        g.FillRectangle(Brushes.Gray, balanceRight);

        var position1 = new RectangleF(
            balanceLeft.Left,
            balanceLeft.Top - heightFactor * 70,
            widthFactor * 70,
            heightFactor * 70
        );
        var position2 = new RectangleF(
            position1.Right - widthFactor * 5,
            balanceLeft.Top - heightFactor * 70,
            widthFactor * 70,
            heightFactor * 70
        );
        var position3 = new RectangleF(
            position2.Right - widthFactor * 5,
            balanceLeft.Top - heightFactor * 70,
            widthFactor * 70,
            heightFactor * 70
        );
        var position4 = new RectangleF(
            position3.Right - widthFactor * 5,
            balanceLeft.Top - heightFactor * 70,
            widthFactor * 70,
            heightFactor * 70
        );
        var position5 = new RectangleF(
            position4.Right - widthFactor * 5,
            balanceLeft.Top - heightFactor * 70,
            widthFactor * 70,
            heightFactor * 70
        );

        var position6 = new RectangleF(
            balanceRight.Left,
            balanceRight.Top - heightFactor * 70,
            widthFactor * 70,
            heightFactor * 70
        );
        var position7 = new RectangleF(
            position6.Right - widthFactor * 5,
            balanceRight.Top - heightFactor * 70,
            widthFactor * 70,
            heightFactor * 70
        );
        var position8 = new RectangleF(
            position7.Right - widthFactor * 5,
            balanceRight.Top - heightFactor * 70,
            widthFactor * 70,
            heightFactor * 70
        );
        var position9 = new RectangleF(
            position8.Right - widthFactor * 5,
            balanceRight.Top - heightFactor * 70,
            widthFactor * 70,
            heightFactor * 70
        );
        var position10 = new RectangleF(
            position9.Right - widthFactor * 5,
            balanceRight.Top - heightFactor * 70,
            widthFactor * 70,
            heightFactor * 70
        );

        g.FillRectangle(Brushes.Red, position1);
        g.FillRectangle(Brushes.Blue, position2);
        g.FillRectangle(Brushes.Green, position3);
        g.FillRectangle(Brushes.Yellow, position4);
        g.FillRectangle(Brushes.Orange, position5);
        g.FillRectangle(Brushes.Red, position6);
        g.FillRectangle(Brushes.Blue, position7);
        g.FillRectangle(Brushes.Green, position8);
        g.FillRectangle(Brushes.Yellow, position9);
        g.FillRectangle(Brushes.Orange, position10);

        g.DrawRectangle(Pens.Red, LeftHitbox);
        g.DrawRectangle(Pens.Red, RightHitbox);
    }

    public void Animate()
    {
        SlowFrameRate += 1;
        State.ToString();

        if (Angle == State)
            return;

        if (SlowFrameRate > 1)
        {
            if (Angle < State)
                Angle++;
            else
                Angle--;
            SlowFrameRate = 0;
        }
    }

    public int CalculateTotalWeight(IEnumerable<Shape> shapes) => shapes.Sum(x => x.Weight);
}
