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
        int[] array = { 2, 3, 5, 8, 10 };
        array = Functions.ShuffleWeights(array);
        
        var sla= array[0];
        var sla2= array[2];
        array[0] = sla2;
        array[2] = sla;

        UserData.Current.RealValues = array.ToArray();
    }

    private void InitializeBalances()
    {
        this.balanceLeft = new Balance(
            200 * ClientScreen.WidthFactor,
            300 * ClientScreen.HeightFactor,
            350 * ClientScreen.WidthFactor,
            350 * ClientScreen.HeightFactor
        );
        this.balanceRight = new Balance(
            950 * ClientScreen.WidthFactor,
            300 * ClientScreen.HeightFactor,
            350 * ClientScreen.WidthFactor,
            350 * ClientScreen.HeightFactor
        );
    }

    private void InitializeInputs()
    {
        inputCircle = new InputUser(
                pb.Width * 0.85f,
                pb.Height * 0.15f,
                pb.Width * 0.1f,
                pb.Height * 0.04f,
                Resources.Circle
        )
        {
            Content = UserData.Current.RealCircleWeight().ToString(),
            Disable = true
        };
        inputPentagon = new InputUser(
            pb.Width * 0.85f,
            pb.Height * 0.20f,
            pb.Width * 0.1f,
            pb.Height * 0.04f,
            Resources.Pentagon
        );
        inputSquare = new InputUser(
            pb.Width * 0.85f,
            pb.Height * 0.25f,
            pb.Width * 0.1f,
            pb.Height * 0.04f,
            Resources.Square
        );
        inputStar = new InputUser(
            pb.Width * 0.85f,
            pb.Height * 0.30f,
            pb.Width * 0.1f,
            pb.Height * 0.04f,
            Resources.Star
        );
        inputTriangle = new InputUser(
            pb.Width * 0.85f,
            pb.Height * 0.35f,
            pb.Width * 0.1f,
            pb.Height * 0.04f,
            Resources.Triangle
        );
    }

    private void InitializeShapes()
    {
        this.fixedPositions = new List<EmptyShape>();
        this.shapes = new List<Shape>();
        EmptyCircle emptyCircle = new EmptyCircle(
            new PointF(350 * ClientScreen.WidthFactor, 800 * ClientScreen.HeightFactor),
            100,
            100
        );

        EmptyPentagon emptyPentagon = new EmptyPentagon(
            new PointF(550 * ClientScreen.WidthFactor, 800 * ClientScreen.HeightFactor),
            100,
            100
        );

        EmptySquare emptySquare = new EmptySquare(
            new PointF(750 * ClientScreen.WidthFactor, 800 * ClientScreen.HeightFactor),
            100,
            100
        );

        EmptyStar emptyStar = new EmptyStar(
            new PointF(950 * ClientScreen.WidthFactor, 800 * ClientScreen.HeightFactor),
            100,
            100
        );

        EmptyTriangle emptyTriangle = new EmptyTriangle(
            new PointF(1150 * ClientScreen.WidthFactor, 800 * ClientScreen.HeightFactor),
            100,
            100
        );

        fixedPositions.Add(emptyCircle);
        fixedPositions.Add(emptyPentagon);
        fixedPositions.Add(emptySquare);
        fixedPositions.Add(emptyStar);
        fixedPositions.Add(emptyTriangle);

        Circle circle = new(
            550 * ClientScreen.WidthFactor,
            800 * ClientScreen.HeightFactor,
            100 * ClientScreen.WidthFactor,
            UserData.Current.RealCircleWeight()
        );
        AddShapes(emptyCircle, circle);

        Pentagon pentagon = new(
            950 * ClientScreen.WidthFactor,
            800 * ClientScreen.HeightFactor,
            100 * ClientScreen.WidthFactor,
            100 * ClientScreen.WidthFactor,
            UserData.Current.RealPentagonWeight()
        );
        AddShapes(emptyPentagon, pentagon);

        Square square = new(
            350 * ClientScreen.WidthFactor,
            800 * ClientScreen.HeightFactor,
            100 * ClientScreen.WidthFactor,
            UserData.Current.RealSquareWeight()
        );
        AddShapes(emptySquare, square);

        Star star = new(
             1150 * ClientScreen.WidthFactor,
             800 * ClientScreen.HeightFactor,
             100 * ClientScreen.WidthFactor,
             100 * ClientScreen.WidthFactor,
             UserData.Current.RealStarWeight()
        );
        AddShapes(emptyStar, star);

        Triangle triangle = new(
            750 * ClientScreen.WidthFactor,
            800 * ClientScreen.HeightFactor,
            100 * ClientScreen.WidthFactor,
            100 * ClientScreen.WidthFactor,
            UserData.Current.RealTriangleWeight()
        );
        AddShapes(emptyTriangle, triangle);
    }

    private void InitializeButtons()
    {
        btnContinue = new BtnConfirm(pb.Width * 0.85f, pb.Height * 0.72f, pb.Width * 0.104f, pb.Height * 0.092f, "Continuar");
        btnReset = new BtnReset(pb.Width * 0.85f, pb.Height * 0.85f, pb.Width * 0.104f, pb.Height * 0.092f, "Resetar");
        btnVerify = new BtnInitial(pb.Width * 0.344f, pb.Height * 0.60f, pb.Width * 0.104f, pb.Height * 0.092f, "Verificar");
    }
}