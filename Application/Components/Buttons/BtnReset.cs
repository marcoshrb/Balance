using System.Drawing;
using System.Drawing.Drawing2D;

namespace Components;

public class BtnReset : BtnBase
{
    private string text { get; set; }

    public BtnReset(float X, float Y, float width, float height, string text)
    {
        this.Hitbox = new RectangleF(X, Y, width, height);
        this.text = text;
    }

    public override void Draw(Graphics g)
    {
        Font font = new Font("Arial bold", 25);
        SizeF textSize = g.MeasureString(this.text, font);

        Color cor = ColorTranslator.FromHtml("#F9A400");
        SolidBrush brush = new SolidBrush(cor);

        // Define a largura da borda
        Color borderColor = ColorTranslator.FromHtml("#313131");
        float borderWidth = 3.0f;
        Pen pen = new Pen(borderColor, borderWidth);

        g.FillRectangle(brush, this.Hitbox); // Desenha o retângulo preenchido
        g.DrawRectangle(pen, Rectangle.Round(this.Hitbox)); // Desenha a borda do retângulo

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
}
