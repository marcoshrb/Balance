using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using Utils;

namespace Entities.Shapes;

public class Pentagon : Shape
{
    private PointF[] points = new PointF[5];
    private double angle = -Math.PI / 2;
    private double angleIncrement = 2 * Math.PI / 5;
    public Pentagon(float x, float y, float width, float height, int weight)
        : base(
            x,
            y,
            width,
            height,
            weight,
            ImageProcessing.ResizeImage(Resources.Pentagon, new Size((int)width, (int)height))
        )
    {
        this.Name = "Pentagono";
    }

    public override object Clone()
        => new Pentagon(this.X, this.Y, this.Width, this.Height, this.Weight);

    public override void DrawShadow(Graphics g)
    {
        var distance = 10;
        var center = new PointF(Location.X + this.Size.Width / 2, Location.Y + this.Size.Height / 2);
        var positionShadowX = (int)(center.X + distance);
        var positionShadowY = (int)(center.Y + distance);

        int centerX = positionShadowX;
        int centerY = positionShadowY;

        int size = (int)(this.Size.Height * .6);

        PointF[] pentagonPoints = GetPentagonPoints(centerX, centerY, size);

        Color[] shadowColors = {
        Color.FromArgb(200, Color.Black),
        Color.FromArgb(100, Color.Black),
        Color.FromArgb(50, Color.Black),
        Color.Transparent
    };

        float[] shadowPositions = { 0f, 0.5f, 0.8f, 1f };

        var shadowBrush = new LinearGradientBrush(
            new RectangleF(pentagonPoints.Min(p => p.X), pentagonPoints.Min(p => p.Y),
                           pentagonPoints.Max(p => p.X) - pentagonPoints.Min(p => p.X),
                           pentagonPoints.Max(p => p.Y) - pentagonPoints.Min(p => p.Y)),
            Color.Black,
            Color.Transparent,
            LinearGradientMode.ForwardDiagonal);

        ColorBlend colorBlend = new ColorBlend
        {
            Colors = shadowColors,
            Positions = shadowPositions
        };
        shadowBrush.InterpolationColors = colorBlend;

        g.FillPolygon(shadowBrush, pentagonPoints);
    }
    private PointF[] GetPentagonPoints(int centerX, int centerY, int size)
    {
        for (int i = 0; i < 5; i++)
        {
            double x = centerX + size * Math.Cos(angle);
            double y = centerY + size * Math.Sin(angle);
            points[i] = new PointF((float)x, (float)y);

            angle += angleIncrement;
        }

        return points;
    }
}
