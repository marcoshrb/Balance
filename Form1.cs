using Timer = System.Windows.Forms.Timer;

namespace Balance;

public partial class Form1 : Form
{
    PictureBox pb;
    Bitmap bmp;
    Graphics g;
    Timer tm;

    PositionWeight positionWeight = new DrawBalance();

    private Image shape {get; set;}
    List<(RectangleF? rect, Pieces piece, bool selected)> list = new();
    public void AddPiece(Pieces piece)
    {
        var rect = new RectangleF
        {
            Location = new PointF(pb.Width*0.677f, pb.Height*0.037f + list.Count * pb.Height*0.037f),
            Width = pb.Width*0.234f,
            Height = pb.Height*0.037f
        };
        list.Add((null, piece, false));
    }


    public Form1()
    {
        InitializeComponent();
        this.WindowState = FormWindowState.Maximized;
        this.FormBorderStyle = FormBorderStyle.None;
        this.pb = new PictureBox();
        this.pb.Dock = DockStyle.Fill;
        this.Controls.Add(pb);


        this.tm = new Timer();
        this.tm.Interval = 10;

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

            positionWeight.PiecePosition(pb, this.shape);
            if (list.Any(x => x.selected))
                positionWeight.Draw( cursor, isDown, pb);

            Frame();
            pb.Refresh();
        };
    }
    bool isDown = false;
    Point cursor = new Point(0, 0);
    Quadrado quadrado;
    Bola bola;
    Triangulo triangulo;
    Pentagono pentagono;
    Estrela estrela;

    List<Pieces> pieces = new List<Pieces>();
    Pieces selected;
    void Onstart()
    {
        for (int i = 0; i < 5; i++)
        {
            quadrado = new Quadrado();
            quadrado.position = new PointF(350, 800);
            pieces.Add(quadrado);
        }

        bola = new Bola();
        bola.position = new PointF(550, 800);
        pieces.Add(bola);

        triangulo = new Triangulo();
        triangulo.position = new PointF(750, 800);
        pieces.Add(triangulo);

        pentagono = new Pentagono();
        pentagono.position = new PointF(950, 800);
        pieces.Add(pentagono);

        estrela = new Estrela();
        estrela.position = new PointF(1150, 800);
        pieces.Add(estrela);

    }
    void Frame()
    {
        foreach (var piece in pieces)
        {

            var cusorInForm = piece.rectangle.Contains(cursor);

            if (isDown && cusorInForm && selected is null)
            {
                var selected = piece.OnSelect(cursor);
                this.selected = selected;
            }

            if (isDown && selected is not null)
                selected.OnMove(cursor);


            piece.Draw(this.g);
        }

        if (!isDown)
            this.selected = null;
    }
}
