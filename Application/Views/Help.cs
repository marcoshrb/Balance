using System;
using System.Drawing;
using System.Windows.Forms;
using Utils;

namespace Views
{
    public class Help : Form
    {
        private Image backgroundImage = Image.FromFile("./Assets/back.png");
        private TextBox inputTextBox;
        private Button validarBotao;

        public Help()
        {
            InitializeForm();
            this.DoubleBuffered = true;

            var fecharBotao = new Button
            {
                Text = "Fechar",
                Size = new Size((int)(110 * ClientScreen.WidthFactor), (int)(30 * ClientScreen.HeightFactor)),
                Location = new Point(
                    (this.ClientSize.Width - (int)(140 * ClientScreen.HeightFactor)),
                    (this.ClientSize.Height - (int)(8 * ClientScreen.HeightFactor) )
                ),
                Font = new Font("Arial", 12, FontStyle.Bold),
                BackColor = Color.White
            };
            fecharBotao.Click += (sender, e) => this.Close();
            this.Controls.Add(fecharBotao);
        }

        private void InitializeForm()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackgroundImage = ImageProcessing.ResizeImage(Resources.HelpImage, new Size(
                (int)(Resources.HelpImage.Width * ClientScreen.WidthFactor),
                (int)(Resources.HelpImage.Height * ClientScreen.WidthFactor)));
            this.Size = new Size((int)(Resources.HelpImage.Width * ClientScreen.WidthFactor),
(int)(Resources.HelpImage.Height * ClientScreen.WidthFactor));
            this.FormBorderStyle = FormBorderStyle.None;
        }
    }
}