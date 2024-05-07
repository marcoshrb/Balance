using System.Drawing;
using System.Windows.Forms;
using Entities;

namespace Components;

public class BtnInitial : BtnBase
{
    private string text { get; set; }

    public BtnInitial(float X, float Y, float width, float height, string text)
    {
        this.Hitbox = new RectangleF(X, Y, width, height);
        this.text = text;
    }

    public override void Draw(Graphics g)
    {
        Font font = new Font("Arial bold", this.Hitbox.Width * 0.085f);
        SizeF textSize = g.MeasureString(this.text, font);

        ShadowRect(this.Hitbox);
        DrawShadow(g);


        g.FillRectangle(Brushes.Orange, this.Hitbox);
        g.DrawString(
            this.text,
            font,
            Brushes.Black,
            new PointF(
                this.Hitbox.X + (this.Hitbox.Width / 2 - textSize.Width / 2),
                this.Hitbox.Y + (this.Hitbox.Height / 2 - textSize.Height / 2)
            )
        );
    }      

    public void OnClick(Balance balanceRigth, Balance balanceLeft)
    {
        balanceRigth.Update();
        balanceLeft.Update();
    }
}
