using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using Utils;

namespace Entities.Shapes;

public class Triangle : Shape
{
    public Triangle(float x, float y, float width, float height, int weight)
        : base(
            x,
            y,
            width,
            height,
            weight,
            ImageProcessing.ResizeImage(Resources.Triangle, new Size((int)width, (int)height))
        )
    {
        this.Name = "Triangulo";
    }

    public override object Clone()
        => new Triangle(this.X, this.Y, this.Width, this.Height, this.Weight);

    public override void DrawShadow(Graphics g)
    {
        var distance = 10;
        var center = new PointF(Location.X + (float)(this.Size.Width * .6), Location.Y + (float)(this.Size.Height * 0.8));
        var positionShadowX = (int)(center.X + distance);
        var positionShadowY = (int)(center.Y + distance);
        int centerX = positionShadowX;
        int centerY = positionShadowY;

        int size = (int)(this.Size.Height * 0.6);

        PointF[] trianglePoints = GetTrianglePoints(centerX, centerY, size);

        Color[] shadowColors = {
        Color.FromArgb(200, Color.Black),
        Color.FromArgb(100, Color.Black),
        Color.FromArgb(50, Color.Black),
        Color.Transparent
    };

        float[] shadowPositions = { 0f, 0.5f, 0.8f, 1f };

        var shadowBrush = new LinearGradientBrush(
            new RectangleF(trianglePoints.Min(p => p.X), trianglePoints.Min(p => p.Y),
                           trianglePoints.Max(p => p.X) - trianglePoints.Min(p => p.X),
                           trianglePoints.Max(p => p.Y) - trianglePoints.Min(p => p.Y)),
            Color.Black,
            Color.Transparent,
            LinearGradientMode.ForwardDiagonal);

        ColorBlend colorBlend = new ColorBlend
        {
            Colors = shadowColors,
            Positions = shadowPositions
        };
        shadowBrush.InterpolationColors = colorBlend;

        g.FillPolygon(shadowBrush, trianglePoints);
    }

    private PointF[] GetTrianglePoints(int centerX, int centerY, int size)
    {
        PointF[] points = new PointF[3];

        points[0] = new PointF(centerX, (float)(centerY - size * 1.2));
        points[1] = new PointF(centerX - (float)(size * Math.Sqrt(3) / 2), centerY + size / 2);
        points[2] = new PointF(centerX + (float)(size * Math.Sqrt(3) / 2), centerY + size / 2);

        return points;
    }
}
