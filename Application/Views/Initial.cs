using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Views
{
    public class Initial : Form
    {
        private Image backgroundImage = Image.FromFile("./Assets/new1.png");
        private Image circulo = Image.FromFile("./Assets/new/circulo.png");
        private Image quadrado = Image.FromFile("./Assets/new/quadrado.png");
        private Image triangulo = Image.FromFile("./Assets/new/triangulo.png");
        private Image estrela = Image.FromFile("./Assets/new/estrela.png");
        private Image pentagono = Image.FromFile("./Assets/new/pentagono.png");

        private TextBox inputBox;

        public Initial()
        {
            InitializeForm();
        }

        private void InitializeForm()
        {
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackgroundImage = backgroundImage;
            this.FormBorderStyle = FormBorderStyle.None;

            this.Paint += new PaintEventHandler(OnPaint);

            // inputBox = new TextBox();
            // inputBox.Size = new Size(416, 76);
            // inputBox.Location = new Point((this.ClientSize.Width - inputBox.Width) / 2, this.ClientSize.Height / 2);
            // inputBox.BackColor = Color.WhiteSmoke;
            // inputBox.Font = new Font("Arial", 12);
            // inputBox.BorderStyle = BorderStyle.FixedSingle;
            // this.Controls.Add(inputBox);
        }

        private void OnPaint(object sender, PaintEventArgs e)
        {
            int rectangleWidth = this.ClientSize.Width - 60;
            int rectangleHeight = this.ClientSize.Height - 60;
            int x = (this.ClientSize.Width - rectangleWidth) / 2;
            int y = (this.ClientSize.Height - rectangleHeight) / 2;

            GraphicsPath path = new GraphicsPath();
            path.AddArc(x, y, 40, 40, 180, 90);
            path.AddArc(x + rectangleWidth - 40, y, 40, 40, 270, 90);
            path.AddArc(x + rectangleWidth - 40, y + rectangleHeight - 40, 40, 40, 0, 90);
            path.AddArc(x, y + rectangleHeight - 40, 40, 40, 90, 90);
            path.CloseFigure();

            SolidBrush brush = new SolidBrush(Color.White);

            e.Graphics.FillPath(brush, path);

            // TREINO
            Font font = new Font("Arial", 119);
            SolidBrush textBrush = new SolidBrush(ColorTranslator.FromHtml("#A3A3A3")); 

            int textX = x + 23;
            int textY = y + 23;

            e.Graphics.DrawString("TREINO", font, textBrush, textX, textY);

            // Coloque seu Nome
            Font font2 = new Font("Arial", 32);
            SolidBrush textBrush2 = new SolidBrush(ColorTranslator.FromHtml("#424242")); 

            int textX2 = x + 43;
            int textY2 = y + 210;
            e.Graphics.DrawString("Coloque seu Nome:", font2, textBrush2, textX2, textY2);

            // Input Box
            inputBox = new TextBox();
            inputBox.Size = new Size(
                    (int)(this.ClientSize.Width * 0.31),
                    (int)(this.ClientSize.Height * 0.4)
                );
            inputBox.Location = new Point(x + 53, y + 280); // Posição abaixo do texto "Coloque seu Nome:"
            inputBox.BackColor = Color.WhiteSmoke;
            inputBox.Font = new Font("Arial", 12);
            inputBox.BorderStyle = BorderStyle.FixedSingle;
            this.Controls.Add(inputBox);

            //Coloque o Peso
            Font font3 = new Font("Arial", 32);
            SolidBrush textBrush3 = new SolidBrush(ColorTranslator.FromHtml("#424242")); 

            int textX3 = x + 43;
            int textY3 = y + 340;
            e.Graphics.DrawString("Coloque o Peso:", font3, textBrush3, textX3, textY3);
        }

    }
}



