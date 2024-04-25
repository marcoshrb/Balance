using System.Drawing;

namespace Entities;
public abstract class Entity
{
    public float X { get; set; }
    public float Y { get; set; }
    public float Width { get; set; }
    public float Height { get; set; }

    protected Entity(float x, float y, float width, float height)
    {
        this.X = x;
        this.Y = y;
        this.Width = width;
        this.Height = height;
    }

    public abstract void Draw(Graphics g);

    public virtual void Update() { }
}
