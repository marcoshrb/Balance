using System;
using System.Drawing;
using Utils;

namespace Entities.Shapes;

public abstract class Shape : Entity, ICloneable
{
    protected Shape(float x, float y, float width, float height, int weight, Bitmap Img)
        : base(x, y, width, height)
    {
        this.Location = new PointF(x, y);
        Sprite spriteCreate = new Sprite(Img) { Rect = new RectangleF(0, 0, width, width) };
        this.Sprite = spriteCreate;
        this.Weight = weight;
        this.Hitbox = new RectangleF(this.Location, new SizeF(width, width));
    }

    public Sprite Sprite { get; set; }
    public SizeF Size => Sprite.Rect.Size;
    public PointF Location { get; set; }
    public bool CanMove = true;
    public string Name { get; set; }
    public PointF LastLocation { get; set; }
    public int Weight { get; set; }
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

    public RectangleF Hitbox = new();
    internal PointF? ptClick = null;

    public override void Draw(Graphics g)
    {
        var rect = new RectangleF(
            (int)Location.X,
            (int)Location.Y,
            (int)Size.Width,
            (int)Size.Height
        );

        // g.DrawRectangle(Pens.Red, rect);
        Sprite.DrawSprite(g, rect);
    }

    public void UpdateHitbox()
    {
        var rect = new RectangleF(
            (int)Location.X,
            (int)Location.Y,
            (int)Size.Width,
            (int)Size.Height
        );
        Hitbox = rect;
    }

    public Shape OnSelect(Point cursor)
    {
        float _x,
            _y;
        _x = cursor.X - this.Location.X;
        _y = cursor.Y - this.Location.Y;
        ptClick = new PointF(_x, _y);
        return this;
    }

    public void OnMove(Point cursor)
    {
        if (CanMove)
        {
            if (ptClick is null)
                return;

            Location = new PointF(cursor.X - ptClick.Value.X, cursor.Y - ptClick.Value.Y);
        }
    }

    public abstract object Clone();
        

}
