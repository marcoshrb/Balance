using System;
using System.Collections.Generic;
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

            double newX =
                Anchor.X
                + deltaX * Math.Cos(Angle * Math.PI / 180)
                - deltaY * Math.Sin(Angle * Math.PI / 180);
            double newY =
                Anchor.Y
                + deltaX * Math.Sin(Angle * Math.PI / 180)
                + deltaY * Math.Cos(Angle * Math.PI / 180);

            vertices[i] = new PointF((float)newX, (float)newY);
        }

        return vertices;
    }
    public static int[] ShuffleWeights(int[] array)
    {
        List<int> lista = new List<int>(array);
        int meio = lista[lista.Count / 2];
        lista.RemoveAt(lista.Count / 2);
        Random rand = new Random();
        for (int i = 0; i < lista.Count; i++)
        {
            int j = rand.Next(i, lista.Count);
            int temp = lista[i];
            lista[i] = lista[j];
            lista[j] = temp;
        }
        int indiceInsercao = lista.Count / 2;
        lista.Insert(indiceInsercao, meio);
        return lista.ToArray();
    }
}
