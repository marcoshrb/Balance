using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using Utils;

namespace Entities.Shapes;

public class Star : Shape
{
    PointF[] points = new PointF[10];
    double angle = -Math.PI / 2;
    double angleIncrement = Math.PI / 5;

    public Star(float x, float y, float width, float height, int weight)
        : base(
            x,
            y,
            width,
            height,
            weight,
            ImageProcessing.ResizeImage(Resources.Star, new Size((int)width, (int)height))
        )
    {
        this.Name = "Estrela";
    }

    public override object Clone()
        => new Star(this.X, this.Y, this.Width, this.Height, this.Weight);

    public override void DrawShadow(Graphics g)
    {
        var distance = 10;
        var center = new PointF(Location.X + this.Size.Width / 2, Location.Y + this.Size.Height / 2);
        var positionShadowX = (int)(center.X + distance);
        var positionShadowY = (int)(center.Y + distance);
        int centerX = positionShadowX;
        int centerY = positionShadowY;

        int size = (int)(this.Size.Height * 0.6);

        PointF[] starPoints = GetStarPoints(centerX, centerY, size);

        Color[] shadowColors = {
        Color.FromArgb(200, Color.Black),
        Color.FromArgb(100, Color.Black),
        Color.FromArgb(50, Color.Black),
        Color.Transparent
    };

        float[] shadowPositions = { 0f, 0.5f, 0.8f, 1f };

        var shadowBrush = new LinearGradientBrush(
            new RectangleF(starPoints.Min(p => p.X), starPoints.Min(p => p.Y),
                           starPoints.Max(p => p.X) - starPoints.Min(p => p.X),
                           starPoints.Max(p => p.Y) - starPoints.Min(p => p.Y)),
            Color.Black,
            Color.Transparent,
            LinearGradientMode.ForwardDiagonal);

        ColorBlend colorBlend = new ColorBlend();
        colorBlend.Colors = shadowColors;
        colorBlend.Positions = shadowPositions;
        shadowBrush.InterpolationColors = colorBlend;

        g.FillPolygon(shadowBrush, starPoints);
    }
    private PointF[] GetStarPoints(int centerX, int centerY, int size)
    {
        for (int i = 0; i < 10; i++)
        {
            double radius = i % 2 == 0 ? size : size / 2;

            double x = centerX + radius * Math.Cos(angle);
            double y = centerY + radius * Math.Sin(angle);
            points[i] = new PointF((float)x, (float)y);

            angle += angleIncrement;
        }

        return points;
    }
}
