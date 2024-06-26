using Components;
using Entities;
using Entities.EmptyShapes;
using Entities.Shapes;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System;
using System.Windows.Forms;
using Utils;

namespace Views;
public partial class Challenge
{
    private void InitializeWeights()
    {
        int[] array = {
            UserData.Current.JsonValues.f1,
            UserData.Current.JsonValues.f2,
            UserData.Current.JsonValues.f3,
            UserData.Current.JsonValues.f4,
            UserData.Current.JsonValues.f5
        };

        Array.Sort(array);
        array = Functions.ShuffleWeights(array);

        var square = array[0];
        var circle = array[2];
        array[0] = circle;
        array[2] = square;

        UserData.Current.RealValues = array.ToArray();
    }
    private void InitializeBalances()
    {
        this.balanceLeft = new Balance(
            190 * ClientScreen.WidthFactor,
            265 * ClientScreen.HeightFactor,
            350 * ClientScreen.WidthFactor,
            350 * ClientScreen.HeightFactor
        );
        this.balanceRight = new Balance(
            865 * ClientScreen.WidthFactor,
            265 * ClientScreen.HeightFactor,
            350 * ClientScreen.WidthFactor,
            350 * ClientScreen.HeightFactor
        );
    }

    private void InitializeInputs()
    {
        inputCircle = new InputUser(
            ClientScreen.WidthFactor * 1565,
            ClientScreen.HeightFactor * 320,
            ClientScreen.WidthFactor * 205,
            ClientScreen.HeightFactor * 50,
            Resources.Circle
        )
        {
            Content = UserData.Current.RealCircleWeight().ToString(),
            Disable = true
        };
        inputPentagon = new InputUser(
            ClientScreen.WidthFactor * 1565,
            ClientScreen.HeightFactor * 425,
            ClientScreen.WidthFactor * 205,
            ClientScreen.HeightFactor * 50,
            Resources.Pentagon
        );
        inputSquare = new InputUser(
            ClientScreen.WidthFactor * 1565,
            ClientScreen.HeightFactor * 530,
            ClientScreen.WidthFactor * 205,
            ClientScreen.HeightFactor * 50,
            Resources.Square
        );
        inputStar = new InputUser(
            ClientScreen.WidthFactor * 1565,
            ClientScreen.HeightFactor * 635,
            ClientScreen.WidthFactor * 205,
            ClientScreen.HeightFactor * 50,
            Resources.Star
        );
        inputTriangle = new InputUser(
            ClientScreen.WidthFactor * 1565,
            ClientScreen.HeightFactor * 740,
            ClientScreen.WidthFactor * 205,
            ClientScreen.HeightFactor * 50,
            Resources.Triangle
        );
    }

    private void InitializeShapes()
    {
        this.fixedPositions = new List<EmptyShape>();
        this.shapes = new List<Shape>();
        EmptyCircle emptyCircle = new EmptyCircle(
            new PointF(205 * ClientScreen.WidthFactor, 865 * ClientScreen.HeightFactor),
            130 * ClientScreen.WidthFactor,
            130 * ClientScreen.HeightFactor
        );

        EmptyPentagon emptyPentagon = new EmptyPentagon(
            new PointF(425 * ClientScreen.WidthFactor, 865 * ClientScreen.HeightFactor),
            130 * ClientScreen.WidthFactor,
            130 * ClientScreen.HeightFactor
        );

        EmptySquare emptySquare = new EmptySquare(
            new PointF(645 * ClientScreen.WidthFactor, 865 * ClientScreen.HeightFactor),
            130 * ClientScreen.WidthFactor,
            130 * ClientScreen.HeightFactor
        );

        EmptyStar emptyStar = new EmptyStar(
            new PointF(865 * ClientScreen.WidthFactor, 865 * ClientScreen.HeightFactor),
            130 * ClientScreen.WidthFactor,
            130 * ClientScreen.HeightFactor
        );

        EmptyTriangle emptyTriangle = new EmptyTriangle(
            new PointF(1085 * ClientScreen.WidthFactor, 865 * ClientScreen.HeightFactor),
            130 * ClientScreen.WidthFactor,
            130 * ClientScreen.HeightFactor
        );

        fixedPositions.Add(emptyCircle);
        fixedPositions.Add(emptyPentagon);
        fixedPositions.Add(emptySquare);
        fixedPositions.Add(emptyStar);
        fixedPositions.Add(emptyTriangle);

        Circle circle = new(
            220 * ClientScreen.WidthFactor,
            205 * ClientScreen.HeightFactor,
            130 * ClientScreen.WidthFactor,
            UserData.Current.RealCircleWeight()
        );
        AddShapes(emptyCircle, circle);

        Pentagon pentagon = new(
            950 * ClientScreen.WidthFactor,
            425 * ClientScreen.HeightFactor,
            130 * ClientScreen.WidthFactor,
            130 * ClientScreen.WidthFactor,
            UserData.Current.RealPentagonWeight()
        );
        AddShapes(emptyPentagon, pentagon);

        Square square = new(
            350 * ClientScreen.WidthFactor,
            645 * ClientScreen.HeightFactor,
            130 * ClientScreen.WidthFactor,
            UserData.Current.RealSquareWeight()
        );
        AddShapes(emptySquare, square);

        Star star = new(
             1150 * ClientScreen.WidthFactor,
             865 * ClientScreen.HeightFactor,
             130 * ClientScreen.WidthFactor,
             130 * ClientScreen.WidthFactor,
             UserData.Current.RealStarWeight()
        );
        AddShapes(emptyStar, star);

        Triangle triangle = new(
            750 * ClientScreen.WidthFactor,
            1085 * ClientScreen.HeightFactor,
            130 * ClientScreen.WidthFactor,
            130 * ClientScreen.WidthFactor,
            UserData.Current.RealTriangleWeight()
        );
        AddShapes(emptyTriangle, triangle);
    }

    private void InitializeButtons()
    {
        btnVerify = new BtnInitial(595 * ClientScreen.WidthFactor, 710 * ClientScreen.HeightFactor, 220 * ClientScreen.WidthFactor, 92 * ClientScreen.HeightFactor, "Pesar");
        btnFinish = new BtnFinish(1490 * ClientScreen.WidthFactor, 880 * ClientScreen.HeightFactor, 246 * ClientScreen.WidthFactor, 104 * ClientScreen.HeightFactor, "Finalizar");
    }
}