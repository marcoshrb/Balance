using System;
using System.Drawing;

namespace Utils;
public static class Functions
{
    public static PointF[] ToPolygon(this RectangleF rect, PointF Anchor, double Angle)
    {
        PointF[] vertices = new PointF[4];

        float[] xCoords = { rect.Left, rect.Right, rect.Right, rect.Left };
        float[] yCoords = { rect.Top, rect.Top, rect.Bottom, rect.Bottom };

        for (int i = 0; i < 4; i++)
        {
            double deltaX = xCoords[i] - Anchor.X;
            double deltaY = yCoords[i] - Anchor.Y;

            double newX = Anchor.X + deltaX * Math.Cos(Angle * Math.PI / 180) - deltaY * Math.Sin(Angle * Math.PI / 180);
            double newY = Anchor.Y + deltaX * Math.Sin(Angle * Math.PI / 180) + deltaY * Math.Cos(Angle * Math.PI / 180);

            vertices[i] = new PointF((float)newX, (float)newY);
        }

        return vertices;
    }
}