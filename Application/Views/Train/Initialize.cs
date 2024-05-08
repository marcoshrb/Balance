using Components;
using Entities;
using Entities.EmptyShapes;
using Entities.Shapes;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Utils;

namespace Views;
public partial class Train
{
    private void InitializeWeights()
    {
        int[] array = { 1, 2, 3 };
        array = Functions.ShuffleWeights(array);
        
        var square = array[0];
        var circle = array[1];
        array[0] = circle;
        array[1] = square;

        UserData.Current.TrainValues = array.ToArray();
    }

    private void InitializeBalances()
    {
        this.balance = new Balance(
            530 * ClientScreen.WidthFactor,
            265 * ClientScreen.HeightFactor,
            350 * ClientScreen.WidthFactor,
            350 * ClientScreen.HeightFactor
        );
    }

    private void InitializeInputs()
    {
        inputCircle = new InputUser(
            ClientScreen.WidthFactor * 1565,
            ClientScreen.HeightFactor * 395,
            ClientScreen.WidthFactor * 205,
            ClientScreen.HeightFactor * 50,
            Resources.Circle
        )
        {
            Content = UserData.Current.TrainCircleWeight().ToString(),
            Disable = true
        };
        inputSquare = new InputUser(
            ClientScreen.WidthFactor * 1565,
            ClientScreen.HeightFactor * 500,
            ClientScreen.WidthFactor * 205,
            ClientScreen.HeightFactor * 50,
            Resources.Square
        );
        inputTriangle = new InputUser(
            ClientScreen.WidthFactor * 1565,
            ClientScreen.HeightFactor * 605,
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
            new PointF(425 * ClientScreen.WidthFactor, 865 * ClientScreen.HeightFactor),
            130 * ClientScreen.WidthFactor,
            130 * ClientScreen.HeightFactor
        );

        EmptySquare emptySquare = new EmptySquare(
            new PointF(635 * ClientScreen.WidthFactor, 865 * ClientScreen.HeightFactor),
            130 * ClientScreen.WidthFactor,
            130 * ClientScreen.HeightFactor
        );

        EmptyTriangle emptyTriangle = new EmptyTriangle(
            new PointF(845 * ClientScreen.WidthFactor, 865 * ClientScreen.HeightFactor),
            130 * ClientScreen.WidthFactor,
            130 * ClientScreen.HeightFactor
        );

        fixedPositions.Add(emptyCircle);
        fixedPositions.Add(emptySquare);
        fixedPositions.Add(emptyTriangle);

        Circle circle = new(
            424 * ClientScreen.WidthFactor,
            425 * ClientScreen.HeightFactor,
            130 * ClientScreen.WidthFactor,
            UserData.Current.TrainCircleWeight()
        );
        AddShapes(emptyCircle, circle);

        Square square = new(
            636 * ClientScreen.WidthFactor,
            645 * ClientScreen.HeightFactor,
            130 * ClientScreen.WidthFactor,
            UserData.Current.TrainSquareWeight()
        );
        AddShapes(emptySquare, square);

        Triangle triangle = new(
            855 * ClientScreen.WidthFactor,
            865 * ClientScreen.HeightFactor,
            130 * ClientScreen.WidthFactor,
            130 * ClientScreen.HeightFactor,
            UserData.Current.TrainTriangleWeight()
        );
        AddShapes(emptyTriangle, triangle);
    }

    private void InitializeButtons()
    {
        btnVerify = new BtnInitial(595 * ClientScreen.WidthFactor, 710 * ClientScreen.HeightFactor, 220 * ClientScreen.WidthFactor, 92 * ClientScreen.HeightFactor, "Pesar");
        btnReset = new BtnReset(1490 * ClientScreen.WidthFactor, 880 * ClientScreen.HeightFactor, 246 * ClientScreen.WidthFactor, 104 * ClientScreen.HeightFactor, "Resetar");
    }
}