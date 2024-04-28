using System.Drawing;
using Utils;

namespace Entities.Shapes;

public abstract class Shape : Entity
{
    protected Shape(float x, float y, float width, float height, int weight, Bitmap Img)
        : base(x, y, width, height)
    {
        this.Position = new PointF(x, y);
        Sprite spriteCreate = new Sprite(Img) { Rect = new RectangleF(0, 0, width, width) };
        this.Sprite = spriteCreate;
        this.Weight = weight;
        this.Hitbox = new RectangleF(this.Position, new SizeF(width, width));
    }

    public Sprite Sprite { get; set; }
    public SizeF Size => Sprite.Rect.Size;
    public PointF Position { get; set; }
    public bool CanMove = true;
    public string Name { get; set; }
    public PointF LastPosition { get; set; }
    public int Weight { get; set; }
    public RectangleF Rectangle
    {
        get
        {
            return new RectangleF(
                (int)Position.X,
                (int)Position.Y,
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
            (int)Position.X,
            (int)Position.Y,
            (int)Size.Width,
            (int)Size.Height
        );

        // g.DrawRectangle(Pens.Red, rect);
        Sprite.DrawSprite(g, rect);
    }

    public void UpdateHitbox()
    {
        var rect = new RectangleF(
            (int)Position.X,
            (int)Position.Y,
            (int)Size.Width,
            (int)Size.Height
        );
        Hitbox = rect;
    }

    public Shape OnSelect(Point cursor)
    {
        float _x,
            _y;
        _x = cursor.X - this.Position.X;
        _y = cursor.Y - this.Position.Y;
        ptClick = new PointF(_x, _y);
        return this;
    }

    public void OnMove(Point cursor)
    {
        if (CanMove)
        {
            if (ptClick is null)
                return;

            Position = new PointF(cursor.X - ptClick.Value.X, cursor.Y - ptClick.Value.Y);
        }
    }
}
