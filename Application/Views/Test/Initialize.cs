using Components;
using Entities;
using Entities.EmptyShapes;
using Entities.Shapes;
using System.Collections.Generic;
using System.Drawing;
using Utils;

namespace Views;
public partial class Train
{
    private void InitializeWeights()
    {
        int[] array = { 1, 2, 3 };
        array = Functions.ShuffleWeights(array);

        UserData.Current.RealCircleWeight = array[1];
        UserData.Current.RealSquareWeight = array[0];
        UserData.Current.RealTriangleWeight = array[2];
    }

    private void InitializeBalances()
    {
        this.balance = new Balance(
            474 * ClientScreen.WidthFactor,
            235 * ClientScreen.HeightFactor,
            464 * ClientScreen.WidthFactor,
            432 * ClientScreen.HeightFactor
        );
    }

    private void InitializeInputs()
    {
        inputCircle = new InputUser(
                ClientScreen.WidthFactor * 1565,
                ClientScreen.HeightFactor * 394,
                ClientScreen.WidthFactor * 205,
                ClientScreen.HeightFactor * 50,
                Resources.Circle
        )
        {
            Content = UserData.Current.RealCircleWeight.ToString(),
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
            ClientScreen.HeightFactor * 606,
            ClientScreen.WidthFactor * 205,
            ClientScreen.HeightFactor * 50,
            Resources.Triangle
        );
    }
    private void InitializeShapes()
    {
        this.fixedPositions = new List<EmptyShape>();
        this.shapes = new List<Shape>();

        EmptySquare emptySquare = new EmptySquare(
            new PointF(424 * ClientScreen.WidthFactor, 865 * ClientScreen.HeightFactor),
            130 * ClientScreen.WidthFactor,
            130 * ClientScreen.HeightFactor
        );

        EmptyCircle emptyCircle = new EmptyCircle(
            new PointF(636 * ClientScreen.WidthFactor, 865 * ClientScreen.HeightFactor),
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

        Square square = new(
            424 * ClientScreen.WidthFactor,
            435 * ClientScreen.HeightFactor,
            130 * ClientScreen.WidthFactor,
            UserData.Current.RealSquareWeight
        );
        AddShapes(emptySquare, square);

        Circle circle = new(
            636 * ClientScreen.WidthFactor,
            645 * ClientScreen.HeightFactor,
            130 * ClientScreen.WidthFactor,
            UserData.Current.RealCircleWeight
        );
        AddShapes(emptyCircle, circle);

        Triangle triangle = new(
            855 * ClientScreen.WidthFactor,
            865 * ClientScreen.HeightFactor,
            130 * ClientScreen.WidthFactor,
            130 * ClientScreen.HeightFactor,
            UserData.Current.RealTriangleWeight
        );
        AddShapes(emptyTriangle, triangle);
    }

    private void InitializeButtons()
    {
        btnVerify = new BtnInitial(595 * ClientScreen.WidthFactor, 710 * ClientScreen.HeightFactor, 220 * ClientScreen.WidthFactor, 92 * ClientScreen.HeightFactor, "Pesar");
        btnReset = new BtnReset(1490 * ClientScreen.WidthFactor, 762 * ClientScreen.HeightFactor, 246 * ClientScreen.WidthFactor, 104 * ClientScreen.HeightFactor, "Resetar");
        btnContinue = new BtnConfirm(1490 * ClientScreen.WidthFactor, 880 * ClientScreen.HeightFactor, 246 * ClientScreen.WidthFactor, 104 * ClientScreen.HeightFactor, "Continuar");
    }
}