using Entities.Shapes;
using System;
using System.Drawing;
using Utils;

namespace Views;
public partial class Challenge
{
    public Bitmap background = ImageProcessing.ResizeImage(
        ImageProcessing.GetImage(@"Assets\background.png") as Bitmap,
        new Size(ClientScreen.Width, ClientScreen.Height)
    );
    Font font = new Font("Open Sans", 92 * ClientScreen.WidthFactor, FontStyle.Bold);
    Font fontAttemps = new Font("Open Sans", 32 * ClientScreen.WidthFactor);
    SolidBrush brush = new SolidBrush(Color.FromArgb(163, 163, 163));
    public void DrawBackground(Graphics g) => g.DrawImage(background, new Point(0, 0));

    void DrawRectangleBack(Image img, int x_, int y_, int width_, int height_)
    {
        Size backSize = new Size(
            (int)(width_ * ClientScreen.WidthFactor),
            (int)(height_ * ClientScreen.HeightFactor)
        );
        Image resizedBack = ImageProcessing.ResizeImage(img, backSize);
        int x_Back = (int)(x_ * ClientScreen.WidthFactor);
        int y_Back = (int)(y_ * ClientScreen.HeightFactor);
        g.DrawImage(resizedBack, new Point(x_Back, y_Back));
    }

    public void DrawBalances()
    {
        balanceLeft.Draw(this.g);
        balanceRight.Draw(this.g);
    }

    public void DrawInput()
    {
        inputCircle.DrawInputSprite(this.g, this.pb);
        inputTriangle.DrawInputSprite(this.g, this.pb);
        inputSquare.DrawInputSprite(this.g, this.pb);
        inputPentagon.DrawInputSprite(this.g, this.pb);
        inputStar.DrawInputSprite(this.g, this.pb);
    }
    public void DrawTitle(string title)
    {
        int x_Title = (int)(96 * ClientScreen.WidthFactor);
        int y_Title = (int)(87 * ClientScreen.HeightFactor);
        g.DrawString(title, font, brush, x_Title, y_Title);
    }
    public void DrawShape(Shape shape)
    {
        var cusorInForm = shape.Rectangle.Contains(cursor);
        if (isDown && cusorInForm && selected is null)
        {
            this.selected = shape.OnSelect(cursor);
            selected.LastLocation = selected.Location;
        }

        if (selected is not null)
        {
            if (isDown)
                selected.OnMove(cursor);
            if (!isDown)
                selected.Location = selected.LastLocation;
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

        foreach (var item in balanceLeft.ShapesOnLeftSide)
            item.DrawString(this.g);

        foreach (var item in balanceLeft.ShapesOnRightSide)
            item.DrawString(this.g);

        foreach (var item in balanceRight.ShapesOnLeftSide)
            item.DrawString(this.g);

        foreach (var item in balanceRight.ShapesOnRightSide)
            item.DrawString(this.g);

        foreach (var shape in shapes)
            shape.UpdateHitbox();

        foreach (var fixedPosition in fixedPositions)
            fixedPosition.DrawString(this.g, true);
    }

    public void DrawLogo()
    {
        Image logo = Resources.Logo;
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
    {
        float height = 50f;

        float topLeftX = x * ClientScreen.WidthFactor;
        float topLeftY = y * ClientScreen.HeightFactor;

        string textAttempts = "Verificações: " + UserData.Current.MoveCounter;
        string textPieces = "Peças Usadas: " + UserData.Current.UsedPiecesCount;

        Font font = new Font("Open Sans", 23 * ClientScreen.WidthFactor, FontStyle.Bold);
        SizeF textSizeAttempts = g.MeasureString(textAttempts, font);
        SizeF textSizePieces = g.MeasureString(textPieces, font);

        float maxTextWidth = Math.Max(textSizeAttempts.Width, textSizePieces.Width);

        float textXAttempts = topLeftX;
        float textYPieces = topLeftY + height + 5;
        float textXPieces = topLeftX;

        g.DrawRectangle(Pens.Black, textXAttempts, topLeftY, maxTextWidth, textSizeAttempts.Height);
        g.DrawString(textAttempts, font, Brushes.Black, textXAttempts, topLeftY);

        g.DrawRectangle(Pens.Black, textXPieces, textYPieces, maxTextWidth, textSizePieces.Height);
        g.DrawString(textPieces, font, Brushes.Black, textXPieces, textYPieces);
    }
}