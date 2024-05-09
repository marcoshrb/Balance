using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Components;
using Entities;
using Entities.EmptyShapes;
using Entities.Shapes;
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
            895 * ClientScreen.WidthFactor,
            155 * ClientScreen.HeightFactor,
            470 * ClientScreen.WidthFactor,
            470 * ClientScreen.HeightFactor
        );
    }

    private void InitializeInputs()
    {
        inputLogin = new InputUser(
            ClientScreen.WidthFactor * 130,
            ClientScreen.HeightFactor * 320,
            ClientScreen.WidthFactor * 450,
            ClientScreen.HeightFactor * 76,
            "Insira seu nome completo:"
        );
        inputCircle = new InputUser(
            ClientScreen.WidthFactor * 229,
            ClientScreen.HeightFactor * 475,
            ClientScreen.WidthFactor * 350,
            ClientScreen.HeightFactor * 76,
            Resources.Circle
        )
        {
            Content = UserData.Current.TrainCircleWeight().ToString(),
            Disable = true
        };
        inputSquare = new InputUser(
            ClientScreen.WidthFactor * 229,
            ClientScreen.HeightFactor * 580,
            ClientScreen.WidthFactor * 350,
            ClientScreen.HeightFactor * 76,
            Resources.Square
        );
        inputTriangle = new InputUser(
            ClientScreen.WidthFactor * 229,
            ClientScreen.HeightFactor * 685,
            ClientScreen.WidthFactor * 350,
            ClientScreen.HeightFactor * 76,
            Resources.Triangle
        );
    }

    private void InitializeShapes()
    {
        this.fixedPositions = new List<EmptyShape>();
        this.shapes = new List<Shape>();

        EmptyCircle emptyCircle = new EmptyCircle(
            new PointF(850 * ClientScreen.WidthFactor, 824 * ClientScreen.HeightFactor),
            130 * ClientScreen.WidthFactor,
            130 * ClientScreen.HeightFactor
        );

        EmptySquare emptySquare = new EmptySquare(
            new PointF(1060 * ClientScreen.WidthFactor, 824 * ClientScreen.HeightFactor),
            130 * ClientScreen.WidthFactor,
            130 * ClientScreen.HeightFactor
        );

        EmptyTriangle emptyTriangle = new EmptyTriangle(
            new PointF(1270 * ClientScreen.WidthFactor, 824 * ClientScreen.HeightFactor),
            130 * ClientScreen.WidthFactor,
            130 * ClientScreen.HeightFactor
        );

        fixedPositions.Add(emptyCircle);
        fixedPositions.Add(emptySquare);
        fixedPositions.Add(emptyTriangle);

        Circle circle =
            new(
                424 * ClientScreen.WidthFactor,
                425 * ClientScreen.HeightFactor,
                130 * ClientScreen.WidthFactor,
                UserData.Current.TrainCircleWeight()
            );
        AddShapes(emptyCircle, circle);

        Square square =
            new(
                636 * ClientScreen.WidthFactor,
                645 * ClientScreen.HeightFactor,
                130 * ClientScreen.WidthFactor,
                UserData.Current.TrainSquareWeight()
            );
        AddShapes(emptySquare, square);

        Triangle triangle =
            new(
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
        btnVerify = new BtnInitial(
            1026 * ClientScreen.WidthFactor,
            690 * ClientScreen.HeightFactor,
            240 * ClientScreen.WidthFactor,
            92 * ClientScreen.HeightFactor,
            "VERIFICAR"
        );
        btnReset = new BtnReset(
            130 * ClientScreen.WidthFactor,
            820 * ClientScreen.HeightFactor,
            ClientScreen.WidthFactor * 450,
            76 * ClientScreen.HeightFactor,
            "RESETAR BALANÇA"
        );
    }
}
