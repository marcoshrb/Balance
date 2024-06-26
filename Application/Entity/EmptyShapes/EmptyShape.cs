using System;
using System.Collections.Generic;
using System.Drawing;
using Entities.Shapes;
using Utils;

namespace Entities.EmptyShapes;

public abstract class EmptyShape
{
    public Sprite Sprite { get; set; }
    public SizeF Size => Sprite.Rect.Size;
    public PointF Location { get; set; }
    public List<Shape> Shapes = new List<Shape>();
    public string Name { get; set; }
    protected int qtd { get; set; } = 0;
    public RectangleF Rectangle
    {
        get
        {
            return new RectangleF(
                (int)Location.X,
                (int)Location.Y,
                (int)Size.Width,
                (int)Size.Height
            );
        }
    }
    Brush brush = new SolidBrush(Color.Black);
    Font font = new Font("Arial", 12);

    public EmptyShape(Bitmap image, float width, float height)
    {
        Sprite spriteCreate = new Sprite(
            ImageProcessing.ResizeImage(
                image,
                new Size(
                    (int)(width * ClientScreen.WidthFactor),
                    (int)(height * ClientScreen.WidthFactor)
                )
            )
        )
        {
            Rect = new RectangleF(
            Location.X,
            Location.Y,
            (int)(width * ClientScreen.WidthFactor),
            (int)(height * ClientScreen.WidthFactor)
        )
        };
        this.Sprite = spriteCreate;
    }

    public void Draw(Graphics g)
    {
        var rect = new RectangleF(
            (int)Location.X,
            (int)Location.Y,
            (int)Size.Width,
            (int)Size.Height
        );

        Sprite.DrawSprite(g, rect);

        // foreach (var shape in Shapes)
        //     shape.Draw(g);

        DrawString(g);
    }

    public void DrawString(Graphics g, bool drawZero = false)
    {
        var count = Shapes.Count;
        if (!drawZero && count == 0)
            return;

        foreach (var item in Shapes)
            item.Location = this.Location;

        Font font = new Font("Arial", 22);
        var format = new StringFormat
        {
            Alignment = StringAlignment.Center,
            LineAlignment = StringAlignment.Center
        };
        var Qty = Shapes.Count;

        g.DrawString(
            Qty.ToString(),
            font,
            brush,
            this.Location.X + (Size.Width / 2),
            this.Location.Y + (Size.Height / 2),
            format
        );
    }

    public void Add(Shape shape)
    {
        if (shape.Name == this.Name)
        {
            Shapes.Add(shape);
            shape.Sprite.img = ImageProcessing.ResizeImage(shape.Sprite.img, new((int)this.Size.Width, (int)this.Size.Height));
            shape.CanMove = false;
            shape.Location = this.Location;
            qtd++;
        }
    }

    public void AddFirst(Shape shape)
    {
        if (shape.Name == this.Name)
        {
            Shapes.Add(shape);
            shape.Sprite.img = ImageProcessing.ResizeImage(shape.Sprite.img, new((int)this.Size.Width, (int)this.Size.Height));
            shape.Location = this.Location;
            qtd++;
        }
    }

}
