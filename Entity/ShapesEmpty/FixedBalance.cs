
using System;
using System.Collections.Generic;
using System.Drawing;
using Entities.Shapes;

public class FixedBalance
{
    public Sprite Sprite { get; set; }
    public SizeF Size => Sprite.Rect.Size;
    public PointF position { get; set; }
    public List<Shape> pieces = new List<Shape>();
    public String Name { get; set; }
    protected int qty { get; set; } = 0;
    public RectangleF rectangle
    {
        get
        {
            return new RectangleF(
                (int)position.X,
                (int)position.Y,
                (int)Size.Width,
                (int)Size.Height
            );
        }
    }
    Brush brush = new SolidBrush(Color.Black);
    Font font = new Font("Arial", 12);
    public void Draw(Graphics g)
    {
        var rect = new RectangleF(
            (int)position.X,
            (int)position.Y,
            (int)Size.Width,
            (int)Size.Height
            );

        Sprite.DrawSprite(g, rect);
    }
    public void DrawString(Graphics g)
    {
        foreach (var item in pieces)
        {
            item.Position = this.position;
        }

        Font font = new Font("Arial", 22);
        var format = new StringFormat();
        format.Alignment = StringAlignment.Center;
        format.LineAlignment = StringAlignment.Center;
        var Qty = pieces.Count;

        g.DrawString(
            Qty.ToString(),
            font,
            brush, this.position.X + (Size.Width / 2), this.position.Y + (Size.Height / 2),
            format
            );
    }
    public void Add(Shape shape)
    {
        if (shape.Name == this.Name)
        {
            pieces.Add(shape);
            shape.CanMove = false;
            shape.Position = this.position;
            qty++;
        }
    }

}