using System.Drawing;
using System.Drawing.Drawing2D;
using Entities;

namespace Components;

public class BtnInitial : BtnBase
{
    private string text { get; set; }

    public BtnInitial(float X, float Y, float width, float height, string text)
    {
        this.Rect = new RectangleF(X, Y, width, height);
        this.text = text;
    }

    public override void DrawButton(Graphics g)
    {
        Font font = new Font("Arial bold", this.Rect.Width * 0.085f);
        SizeF textSize = g.MeasureString(this.text, font);
        LinearGradientBrush gradientOrange = new LinearGradientBrush(this.Rect ,Color.FromArgb(255, 145, 77), Color.FromArgb(255, 222, 89), LinearGradientMode.Horizontal);

        ShadowRect(this.Rect);
        // DrawShadow(g);


        g.FillRectangle(gradientOrange, this.Rect);
        g.DrawString(
            this.text,
            font,
            Brushes.White,
            new PointF(
                this.Rect.X + (this.Rect.Width / 2 - textSize.Width / 2),
                this.Rect.Y + (this.Rect.Height / 2 - textSize.Height / 2)
            )
        );
    }      

    public void OnClick(Balance balanceRigth, Balance balanceLeft)
    {
        balanceRigth.Update();
        balanceLeft.Update();
    }
    public void OnClick(Balance balance)
    {
        balance.Update();
    }
}
