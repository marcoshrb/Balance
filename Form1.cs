using Timer = System.Windows.Forms.Timer;

namespace Balance;

public partial class Form1 : Form
{
    PictureBox pb;
    Bitmap bmp;
    Graphics g;
    Timer tm;

    public Form1()
    {
        InitializeComponent();
        this.WindowState = FormWindowState.Maximized;
        this.FormBorderStyle = FormBorderStyle.None;
        this.pb = new PictureBox();
        this.pb.Dock = DockStyle.Fill;
        this.Controls.Add(pb);

        this.tm = new Timer();
        this.tm.Interval = 20;

        this.KeyDown += (o, e) =>
        {
            if (e.KeyCode == Keys.Escape)
                Application.Exit();
        };
        
        this.pb.MouseMove += (o, e) =>
        {
            cursor = e.Location;
        };

        this.pb.MouseDown += (o, e) =>
        {
            isDown = true;
        };

        this.pb.MouseUp += (o, e) =>
        {
            isDown = false;
        };

        this.Load += (o, e) =>
        {
            this.bmp = new Bitmap(pb.Width, pb.Height);
            g = Graphics.FromImage(this.bmp);
            g.Clear(Color.White);
            this.pb.Image = bmp;

            Onstart();

            this.tm.Start();
        };

        tm.Tick += (o, e) =>
        {
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;  
            g.Clear(Color.White);
            Frame();
            pb.Refresh();
        };
    }
    bool isDown = false;
    Point cursor = new Point(0, 0);
    Quadrado quadrado;
    Quadrado selected;
    void Onstart()
    {
        quadrado = new Quadrado();
        
    }
    void Frame()
    {
        var cusorInForm = quadrado.rectangle.Contains(cursor);

        if(isDown && cusorInForm && selected is null)
        {
            var selected = quadrado.OnSelect(cursor);        
            this.selected = selected;
        }

        if(isDown && selected is not null)
            selected.OnMove(cursor);


        if(!isDown && selected is not null)
            this.selected = null;

        quadrado.Draw(this.g);
    }
}
