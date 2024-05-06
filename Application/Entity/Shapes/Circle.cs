using System.Drawing;
using System.Drawing.Drawing2D;
using Utils;

namespace Entities.Shapes;

public class Circle : Shape
{
    public Circle(float x, float y, float radius, int weight)
        : base(
            x,
            y,
            radius,
            radius,
            weight,
            ImageProcessing.ResizeImage(Resources.Circle, new Size((int)radius, (int)radius))
        )
    {
        this.Name = "Bola";
    }

    public override object Clone()
        => new Circle(this.X, this.Y, this.Width, this.Weight);
    
    public override void DrawShadow(Graphics g)
    {
        var distance = 10;
        var rec = new Rectangle(
            (int)(Location.X + distance),
            (int)(Location.Y + distance),
            (int)Size.Width + 2,
            (int)Size.Height + 2
        );

        Color startColor = Color.FromArgb(150, Color.Black);
        Color endColor = Color.Transparent;

        var shadowBrush = new LinearGradientBrush(rec, startColor, endColor, LinearGradientMode.ForwardDiagonal);

        g.FillEllipse(shadowBrush, rec);
    }
}
