using System.Drawing;
using Entities.Shapes;
using Utils;

namespace Views;

public partial class Train
{
    Font font = new Font("Open Sans", 92 * ClientScreen.WidthFactor, FontStyle.Bold);
    Font fontAttemps = new Font("Open Sans", 32 * ClientScreen.WidthFactor);
    SolidBrush brush = new SolidBrush(Color.FromArgb(0, 0, 0));

    void DrawRectangleBack(int x_, int y_, int width_, int height_)
    {
        Size backSize = new Size(
            (int)(width_ * ClientScreen.WidthFactor),
            (int)(height_ * ClientScreen.HeightFactor)
        );
        Image resizedBack = ImageProcessing.ResizeImage(BackRect, backSize);
        int x_Back = (int)(x_ * ClientScreen.WidthFactor);
        int y_Back = (int)(y_ * ClientScreen.HeightFactor);
        g.DrawImage(resizedBack, new Point(x_Back, y_Back));
    }

    public void DrawBalances()
        => balance.Draw(this.g);
    

    public void DrawInput()
    {
        inputCircle.DrawInputSprite(this.g, this.pb);
        inputTriangle.DrawInputSprite(this.g, this.pb);
        inputSquare.DrawInputSprite(this.g, this.pb);
    }
    public void DrawTitle(string title)
    {
        int x_Title = (int)(445 * ClientScreen.WidthFactor);
        int y_Title = (int)(75 * ClientScreen.HeightFactor);
        g.DrawString(
            title,
            font,
            brush,
            x_Title,
            y_Title);
    }
    public void DrawShape(Shape shape)
    {
        var cusorInForm = shape.Rectangle.Contains(cursor);
        if (isDown && cusorInForm && selected is null)
        {
            this.selected = shape.OnSelect(cursor);
            selected.LastPosition = selected.Position;
        }

        if (selected is not null)
        {
            if (isDown)
                selected.OnMove(cursor);
            if (!isDown)
                selected.Position = selected.LastPosition;
        }
        shape.Draw(this.g);
    }

    public void DrawShapes()
    {
        foreach (var fixedPosition in fixedPositions)
            fixedPosition.Draw(this.g);

        foreach (var shape in shapes)
            DrawShape(shape);

        DropShape();

        foreach (var item in balance.ShapesOnLeftSide)
            item.DrawString(this.g);

        foreach (var item in balance.ShapesOnRightSide)
            item.DrawString(this.g);

        foreach (var shape in shapes)
            shape.UpdateHitbox();

        foreach (var fixedPosition in fixedPositions)
            fixedPosition.DrawString(this.g, true);
    }

    public void DrawLogo()
    {
        Image logo = ImageProcessing.GetImage(@"Assets\logo.png");
        Size newSize = new Size(
            (int)(170 * ClientScreen.WidthFactor),
            (int)(38 * ClientScreen.WidthFactor)
        );
        Image resizedLogo = ImageProcessing.ResizeImage(logo, newSize);
        int margin = (int)(14 * ClientScreen.HeightFactor);
        int x = margin;
        int y = ClientScreen.Height - resizedLogo.Height - margin;
        g.DrawImage(resizedLogo, new Point(x, y));
    }

    public void DrawAttempts(int x, int y)
        => g.DrawString("Tentativas: " + Attemps, fontAttemps, Brushes.Black, x * ClientScreen.WidthFactor, y * ClientScreen.HeightFactor);

}