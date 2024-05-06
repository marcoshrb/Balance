using System;
using System.Drawing;
using System.Windows.Forms;

namespace Views
{
    public class Security : Form
    {
        private Image backgroundImage = Image.FromFile("./Assets/back.png");
        private TextBox inputTextBox;
        private Button validarBotao;

        public Security()
        {
            InitializeForm();
            this.DoubleBuffered = true;

            var fecharBotao = new Button
            {
                Text = "Fechar",
                Size = new Size(100, 30),
                Location = new Point(
                    (this.ClientSize.Width - 100) / 2,
                    (this.ClientSize.Height + 10) / 2 + 160
                ),
                Font = new Font("Arial", 12, FontStyle.Bold),
                BackColor = Color.White
            };
            fecharBotao.Click += (sender, e) => this.Close();
            this.Controls.Add(fecharBotao);


            validarBotao = new Button
            {
                Text = "Confirmar",
                Size = new Size(100, 30),
                Location = new Point(
                    (this.ClientSize.Width - 100) / 2,
                    (this.ClientSize.Height + 10) / 2 + 120
                ),
                Font = new Font("Arial", 12, FontStyle.Bold),
                BackColor = Color.White
            };
            validarBotao.Click += ButtonClick;
            this.Controls.Add(validarBotao);
        }

        private void InitializeForm()
        {
            this.Size = new Size(1000, 600);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackgroundImage = backgroundImage;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Paint += Elements;

            Draw();
        }

        private void Draw()
        {
            inputTextBox = new TextBox
            {
                Size = new Size(
                    (int)(this.ClientSize.Width * 0.4),
                    (int)(this.ClientSize.Height * 0.15)
                ),
                Font = new Font("Arial", 18),
                BackColor = Color.White,
                ForeColor = Color.Black,
                TextAlign = HorizontalAlignment.Center
            };

            int centerY = (this.ClientSize.Height - inputTextBox.Height) / 2 + 100;
            inputTextBox.Location = new Point(
                (this.ClientSize.Width - inputTextBox.Width) / 2,
                centerY
            );
            this.Controls.Add(inputTextBox);
        }

        private void Input(object sender, EventArgs e)
        {
            inputTextBox.Size = new Size(
                (int)(this.ClientSize.Width * 0.4),
                (int)(this.ClientSize.Height * 0.15)
            );
            int centerY = (this.ClientSize.Height - inputTextBox.Height) / 2;
            inputTextBox.Location = new Point(
                (this.ClientSize.Width - inputTextBox.Width) / 2,
                centerY
            );
        }

        private void Elements(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(backgroundImage, new Rectangle(Point.Empty, this.ClientSize));
            Text(
                "CHAME UM INSTRUTOR",
                new Font("Arial", 50, FontStyle.Bold),
                Brushes.White,
                e.Graphics,
                -105
            );
            Text(
                "Insira o código para sair",
                new Font("Arial", 30, FontStyle.Bold),
                Brushes.White,
                e.Graphics,
                50
            );
        }

        private void Text(string text, Font font, Brush brush, Graphics graphics, int offsetY = 0)
        {
            SizeF textSize = graphics.MeasureString(text, font);
            PointF location = new PointF(
                (this.ClientSize.Width - textSize.Width) / 2,
                (this.ClientSize.Height - textSize.Height * 2) / 2 + offsetY
            );
            graphics.DrawString(text, font, brush, location);
        }

        private void ButtonClick(object sender, EventArgs e)
        {
            if (inputTextBox.Text != "0000")
            {
                MessageBox.Show("Senha incorreta. Tente novamente.");
                inputTextBox.Text = "";
                this.Close();
            }
            else
            {
                Application.Exit();
            }
        }
        private void ButtonClose(object sender, EventArgs e)
        {
            var fecharBotao = new Button
            {
                Text = "Fechar",
                Size = new Size(100, 30),
                Location = new Point(
                    (this.ClientSize.Width - 100) / 2,
                    (this.ClientSize.Height + 10) / 2 + 170
                ),
                Font = new Font("Arial", 12, FontStyle.Bold),
                BackColor = Color.White
            };
            fecharBotao.Click += (sender, e) => this.Close();
            this.Controls.Add(fecharBotao);
        }
    }
}
