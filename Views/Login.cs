using System;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Utils;
using Views.Components;


namespace Views;

public class Login : Form
{
    private PictureBox header;
    private PictureBox pb;
    private Bitmap bmp;
    private Graphics g;
    private Timer tm;
    public string UserName;
    private bool showLine = false;
    private int counter = 0;
    private InputUser input = null;
    private string userName = "";

    public Login()
    {
        TextBox textBox = null;
        this.WindowState = FormWindowState.Maximized;
        this.FormBorderStyle = FormBorderStyle.None;
        this.Text = "Desafio";
        bool isTyping = false;
        int countSize = 0;
        BtnConfirm btnConfirm = null;
        Test test = new();

        this.header = new PictureBox
        {
            Dock = DockStyle.Top,
            Height = (int)(16 * ClientScreen.HeightFactor),
            BackgroundImage = Image.FromFile(@"Assets\rainbow.png"),
            BackgroundImageLayout = ImageLayout.Stretch
        };
        this.Controls.Add(header);

        this.pb = new PictureBox { Dock = DockStyle.Fill };
        this.Controls.Add(pb);

        this.tm = new Timer { Interval = 20 };

        this.KeyDown += (o, e) =>
        {
            if (e.KeyCode == Keys.Escape)
                Application.Exit();
        };

        this.Load += (o, e) =>
        {
            UserData.New();
            this.bmp = new Bitmap(pb.Width, pb.Height);
            g = Graphics.FromImage(this.bmp);
            g.InterpolationMode = InterpolationMode.NearestNeighbor;
            g.Clear(Color.FromArgb(250, 249, 246));
            this.pb.Image = bmp;
            Onstart();
            this.tm.Start();

            input = new InputUser(
                pb.Width * 0.5f - 200,
                pb.Height * 0.4f,
                400,
                40,
                "Insira seu nome completo:"
            );
            input.DrawInput(g);
            btnConfirm = new BtnConfirm(pb.Width * 0.85f, pb.Height * 0.85f, pb.Width*0.104f, pb.Height*0.092f, "Confirmar");
            btnConfirm.DrawButton(g);
        };

        void textForResult(object sender, EventArgs e)
        {
            if (isTyping)
            {
                userName = textBox.Text;
                string text = "";
                if (counter % 15 == 0)
                    this.showLine = !this.showLine;
                if (showLine)
                    text = textBox.Text + "|";
                else
                    text = textBox.Text;
                Font font = new Font("Arial", 24);
                SizeF textSize = g.MeasureString(text, font);
                if ((int)textSize.Width / (int)input.Rect.Width > countSize)
                {
                    input.Rect = new RectangleF(
                        input.Rect.X,
                        input.Rect.Y,
                        input.Rect.Width,
                        input.Rect.Height + textSize.Height
                    );
                    countSize = (int)textSize.Width / (int)input.Rect.Width;
                }
                if ((int)textSize.Width / (int)input.Rect.Width < countSize)
                {
                    g.Clear(Color.FromArgb(250, 249, 246));
                    Onstart();
                    input.Rect = new RectangleF(
                        input.Rect.X,
                        input.Rect.Y,
                        input.Rect.Width,
                        input.Rect.Height - textSize.Height
                    );
                    input.DrawInput(g);
                    countSize = (int)textSize.Width / (int)input.Rect.Width;
                    btnConfirm.DrawButton(g);
                }
                Brush brush = Brushes.Black;
                SolidBrush white = new SolidBrush(Color.FromArgb(250, 249, 246));
                g.FillRectangle(white, input.Rect);
                input.DrawInputRect(g);
                g.DrawString(text, font, brush, input.Rect);
            }
        }

        textBox = new TextBox
        {
            Location = new Point(pb.Width / 2 - 75, pb.Height / 2 - 10),
            Size = new Size(150, 20),
            Visible = true,
            Enabled = false
        };
        textBox.TextChanged += textForResult;
        this.Controls.Add(textBox);

        pb.MouseClick += (o, e) =>
        {
            if (input.Rect.Contains(e.X, e.Y) && !isTyping)
            {
                isTyping = true;
                textBox.Enabled = true;
                textBox.Focus();
            }
            else
            {
                isTyping = false;
                textBox.Enabled = false;
                this.showLine = false;
            }

            if (btnConfirm.Rect.Contains(e.X, e.Y))
            {
                if (this.userName.Length > 0)
                {
                    UserData.Current.UserName = this.userName;
                    UserData.Current.DateStart = DateTime.Now;
                    this.Hide();
                    test = new();
                    test.Show();
                }
                else
                    MessageBox.Show("Vazio");
            }
        };

        tm.Tick += (o, e) =>
        {
            Frame();
            pb.Refresh();
            textForResult(o, e);
        };
    }

    void Onstart()
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

    void Frame()
    {
        this.counter++;
    }
}
