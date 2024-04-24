using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Utils;

namespace Views;

public class Login : Form
{
    private PictureBox header;
    private PictureBox pb;
    private Bitmap bmp;
    private Graphics g;
    private Timer tm;
    public string UserName;

    public Login()
    {
        TextBox textBox = null;
        this.WindowState = FormWindowState.Maximized;
        this.FormBorderStyle = FormBorderStyle.None;
        this.Text = "Desafio";
        InputUser input = null;
        bool isTyping = false;
        bool resized = false;

        this.header = new PictureBox
        {
            Dock = DockStyle.Top,
            Height = (int)(16 * ClientScreen.HeightFactor),
            BackgroundImage = Image.FromFile(@"Assets\rainbow.png"),
            BackgroundImageLayout = ImageLayout.Stretch
        };
        this.Controls.Add(header);

        this.pb = new PictureBox
        {
            Dock = DockStyle.Fill
        };
        this.Controls.Add(pb);

        this.tm = new Timer
        {
            Interval = 20
        };

        this.KeyDown += (o, e) =>
        {
            if (e.KeyCode == Keys.Escape)
                Application.Exit();
                
        };

        this.Load += (o, e) =>
        {
            this.bmp = new Bitmap(pb.Width, pb.Height);
            g = Graphics.FromImage(this.bmp);
            g.InterpolationMode = InterpolationMode.NearestNeighbor;
            g.Clear(Color.FromArgb(250, 249, 246));
            this.pb.Image = bmp;
            Onstart();
            this.tm.Start();

            input = new InputUser(pb.Width*0.5f-200, pb.Height*0.4f, 400, 50, "Insira seu nome completo:");
            input.DrawInput(g);
        };
        
        
        void textForResult(object sender, EventArgs e)
        {
            if(isTyping)
            {
                string text = textBox.Text;
                Font font = new Font("Arial", 24);
                SizeF textSize = g.MeasureString(text, font);
                if(textSize.Width > input.Rect.Width && !resized)
                {
                    input.Rect = new RectangleF(input.Rect.X, input.Rect.Y, input.Rect.Width, input.Rect.Height + 40);
                    resized = true;
                }
                Brush brush = Brushes.Black;
                SolidBrush white = new SolidBrush(Color.FromArgb(250, 249, 246));
                g.FillRectangle(white, input.Rect);
                input.DrawInputRect(g);
                g.DrawString(text, font, brush, input.Rect);
            }
        }
        
        textBox = new TextBox();
        textBox.Location = new Point(pb.Width / 2 - 75, pb.Height / 2 - 10);
        textBox.Size = new Size(150, 20);
        textBox.Visible = true;
        textBox.ReadOnly = true;
        textBox.Focus();
        textBox.TextChanged += textForResult;
        this.Controls.Add(textBox);

        pb.MouseClick += (o, e) =>
        {
            if(input.Rect.Contains(e.X, e.Y) && !isTyping)
            {
                isTyping = true;
                textBox.ReadOnly = false;
            }
            else
            {
                isTyping = false;
                textBox.ReadOnly = true;
            }
        };

        tm.Tick += (o, e) =>
        {
            Frame();
            pb.Refresh();
        };
    }


    void Onstart()
    {
        Image logo = ImageProcessing.GetImage(@"Assets\logo.png");
        Size newSize = new Size((int)(170 * ClientScreen.WidthFactor), (int)(38 * ClientScreen.WidthFactor));
        Image resizedLogo = ImageProcessing.ResizeImage(logo, newSize);
        int margin = (int)(14 * ClientScreen.HeightFactor);
        int x = margin;
        int y = ClientScreen.Height - resizedLogo.Height - margin;
        g.DrawImage(resizedLogo, new Point(x, y));
    }

    void Frame()
    { }
}
