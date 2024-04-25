using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Entities.Shapes;
using Utils;

namespace Entities;

public class Balance : Entity
{
    public int State;
    public RectangleF LeftHitbox;
    public RectangleF RightHitbox;
    private List<FixedBalance> LeftShapes;
    private List<FixedBalance> RightShapes;
    public List<FixedBalance> ShapesOnLeftSide => LeftShapes.ToList();
    public List<FixedBalance> ShapesOnRightSide => RightShapes.ToList();
    private int SlowFrameRate = 0;
    private int Angle = 10;
    private EmptyCircle emptyCircle;
    private EmptyPentagon emptyPentagon;
    private EmptySquare emptySquare;
    private EmptyStar emptyStar;
    private EmptyTriangle emptyTriangle;
    private EmptyCircle emptyCircle2;
    private EmptyPentagon emptyPentagon2;
    private EmptySquare emptySquare2;
    private EmptyStar emptyStar2;
    private EmptyTriangle emptyTriangle2;


    public Balance(float x, float y, float width, float height) : base(x, y, width, height)
    {
        State = (int)BalanceState.None;

        // LeftShapes
        LeftShapes = new();

        emptyCircle = new EmptyCircle();
        LeftShapes.Add(emptyCircle);

        emptyPentagon = new EmptyPentagon();
        LeftShapes.Add(emptyPentagon);

        emptySquare = new EmptySquare();
        LeftShapes.Add(emptySquare);

        emptyStar = new EmptyStar();
        LeftShapes.Add(emptyStar);

        emptyTriangle = new EmptyTriangle();
        LeftShapes.Add(emptyTriangle);

        // RightShapes
        RightShapes = new();

        emptyCircle2 = new EmptyCircle();
        RightShapes.Add(emptyCircle2);

        emptyPentagon2 = new EmptyPentagon();
        RightShapes.Add(emptyPentagon2);

        emptySquare2 = new EmptySquare();
        RightShapes.Add(emptySquare2);

        emptyStar2 = new EmptyStar();
        RightShapes.Add(emptyStar2);

        emptyTriangle2 = new EmptyTriangle();
        RightShapes.Add(emptyTriangle2);
    }

    public void AddLeftShape(Shape shape)
    {
        foreach (var fixedBalance in LeftShapes)
        {
            if (shape.Name == fixedBalance.Name)
            {
                shape.CanMove = false;
                shape.Position = fixedBalance.position;
                fixedBalance.Add(shape);
                UpdateBalanceState();
            }
        }
    }

    public void AddRightShape(Shape shape)
    {
        foreach (var fixedBalance in RightShapes)
        {
            if (shape.Name == fixedBalance.Name)
            {
                shape.CanMove = false;
                shape.Position = fixedBalance.position;
                fixedBalance.Add(shape);
                UpdateBalanceState();
            }
        }
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

    public int CalculateTotalWeight(IEnumerable<FixedBalance> SideBalance)
    {
        var sum = 0;
        foreach (var fixedBalance in SideBalance)
        {
            foreach (var item in fixedBalance.pieces)
            {
                sum += item.Weight;
            }
        }
        return sum;
    }

    public override void Update() => UpdateBalanceState();

    public override void Draw(Graphics g) => DrawBalance(g);

    public void DrawShapesEmptys(Graphics g)
    {

    }


    RectangleF position1;
    RectangleF position2;
    RectangleF position3;
    RectangleF position4;
    RectangleF position5;
    RectangleF position6;
    RectangleF position7;
    RectangleF position8;
    RectangleF position9;
    RectangleF position10;
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

        this.position1 = new RectangleF(
            balanceLeft.Left,
            balanceLeft.Top - heightFactor * 70,
            widthFactor * 70,
            heightFactor * 70
        );
        this.position2 = new RectangleF(
            position1.Right - widthFactor * 5,
            balanceLeft.Top - heightFactor * 70,
            widthFactor * 70,
            heightFactor * 70
        );
        this.position3 = new RectangleF(
            position2.Right - widthFactor * 5,
            balanceLeft.Top - heightFactor * 70,
            widthFactor * 70,
            heightFactor * 70
        );
        this.position4 = new RectangleF(
            position3.Right - widthFactor * 5,
            balanceLeft.Top - heightFactor * 70,
            widthFactor * 70,
            heightFactor * 70
        );
        this.position5 = new RectangleF(
            position4.Right - widthFactor * 5,
            balanceLeft.Top - heightFactor * 70,
            widthFactor * 70,
            heightFactor * 70
        );

        this.position6 = new RectangleF(
            balanceRight.Left,
            balanceRight.Top - heightFactor * 70,
            widthFactor * 70,
            heightFactor * 70
        );
        this.position7 = new RectangleF(
            position6.Right - widthFactor * 5,
            balanceRight.Top - heightFactor * 70,
            widthFactor * 70,
            heightFactor * 70
        );
        this.position8 = new RectangleF(
            position7.Right - widthFactor * 5,
            balanceRight.Top - heightFactor * 70,
            widthFactor * 70,
            heightFactor * 70
        );
        this.position9 = new RectangleF(
            position8.Right - widthFactor * 5,
            balanceRight.Top - heightFactor * 70,
            widthFactor * 70,
            heightFactor * 70
        );
        this.position10 = new RectangleF(
            position9.Right - widthFactor * 5,
            balanceRight.Top - heightFactor * 70,
            widthFactor * 70,
            heightFactor * 70
        );


        // LeftShapes

        emptyCircle.position = new (position1.Left, position1.Top);

        emptyPentagon.position = new(position2.Left, position2.Top);
    
        emptySquare.position = new(position3.Left, position3.Top);
  
        emptyStar.position = new(position4.Left, position4.Top);

        emptyTriangle.position = new(position5.Left, position5.Top);


        // RightShapes

        emptyCircle2.position = new(position6.Left, position6.Top);

        emptyPentagon2.position = new(position7.Left, position7.Top);

        emptySquare2.position = new(position8.Left, position8.Top);

        emptyStar2.position = new(position9.Left, position9.Top);

        emptyTriangle2.position = new(position10.Left, position10.Top);

        // emptyCircle.Draw(g);
        // emptyPentagon.Draw(g);
        // emptySquare.Draw(g);
        // emptyStar.Draw(g);
        // emptyTriangle.Draw(g);
        // emptyCircle2.Draw(g);
        // emptyPentagon2.Draw(g);
        // emptySquare2.Draw(g);
        // emptyStar2.Draw(g);
        // emptyTriangle2.Draw(g);

        // g.DrawRectangle(Pens.Red, LeftHitbox);
        // g.DrawRectangle(Pens.Red, RightHitbox);
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


}
