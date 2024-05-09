using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Entities;

namespace Components;

public class BtnHelp : BtnBase
{
    private string text { get; set; }

    public BtnHelp(float X, float Y, float width, float height)
    {
        this.Hitbox = new RectangleF(X, Y, width, height);
    }

    public override void Draw(Graphics g)
    {
        g.DrawImage(Resources.AjudaImage, this.Hitbox);
    }
}