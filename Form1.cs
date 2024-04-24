using Timer = System.Windows.Forms.Timer;

namespace Balance;

public partial class Form1 : Form
{
    PictureBox pb;
    Bitmap bmp;
    Graphics g;
    Timer tm;

    Point cursor = new Point(0, 0);
    List<Pieces> pieces = new List<Pieces>();
    List<FixedBalance> fixedBalances = new List<FixedBalance>();
    Pieces selected; 
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

            Frame();
            pb.Refresh();
        };
    }
    bool isDown = false;

    void Onstart()
    {
        // Shape 1
        FixedBalance square1 = new QuadradoEmpty(new PointF(100, 400)); 
        fixedBalances.Add(square1);
        FixedBalance circle1 = new BolaEmpty(new PointF(180, 400)); 
        fixedBalances.Add(circle1);
        FixedBalance triangle1 = new TrianguloEmpty(new PointF(260, 400)); 
        fixedBalances.Add(triangle1);
        FixedBalance pentagon1 = new PentagonoEmpty(new PointF(340, 400)); 
        fixedBalances.Add(pentagon1);
        FixedBalance star1 = new EstrelaEmpty(new PointF(420, 400)); 
        fixedBalances.Add(star1);

        // Shape 2
        FixedBalance square2 = new QuadradoEmpty(new PointF(500, 400)); 
        fixedBalances.Add(square2);
        FixedBalance circle2 = new BolaEmpty(new PointF(580, 400)); 
        fixedBalances.Add(circle2);
        FixedBalance triangle2 = new TrianguloEmpty(new PointF(660, 400)); 
        fixedBalances.Add(triangle2);
        FixedBalance polygon2 = new PentagonoEmpty(new PointF(740, 400)); 
        fixedBalances.Add(polygon2);
        FixedBalance star2 = new EstrelaEmpty(new PointF(820, 400)); 
        fixedBalances.Add(star2);

        // Shape 3
        FixedBalance square3 = new QuadradoEmpty(new PointF(900, 400)); 
        fixedBalances.Add(square3);
        FixedBalance circle3 = new BolaEmpty(new PointF(980, 400)); 
        fixedBalances.Add(circle3);
        FixedBalance triangle3 = new TrianguloEmpty(new PointF(1060, 400)); 
        fixedBalances.Add(triangle3);
        FixedBalance polygon3 = new PentagonoEmpty(new PointF(1140, 400)); 
        fixedBalances.Add(polygon3);
        FixedBalance star3 = new EstrelaEmpty(new PointF(1220, 400)); 
        fixedBalances.Add(star3);

        // Shape 4
        FixedBalance square4 = new QuadradoEmpty(new PointF(1300, 400)); 
        fixedBalances.Add(square4);
        FixedBalance circle4 = new BolaEmpty(new PointF(1380, 400)); 
        fixedBalances.Add(circle4);
        FixedBalance triangle4 = new TrianguloEmpty(new PointF(1460, 400)); 
        fixedBalances.Add(triangle4);
        FixedBalance polygon4 = new PentagonoEmpty(new PointF(1540, 400)); 
        fixedBalances.Add(polygon4);
        FixedBalance star4 = new EstrelaEmpty(new PointF(1620, 400)); 
        fixedBalances.Add(star4);



        for (int i = 0; i < 5; i++)
        {
            Quadrado quadrado = new Quadrado();
            pieces.Add(quadrado);

            Bola bola = new Bola();
            pieces.Add(bola);

            Triangulo triangulo = new Triangulo();
            pieces.Add(triangulo);

            Pentagono pentagono = new Pentagono();
            pieces.Add(pentagono);

            Estrela estrela = new Estrela();
            pieces.Add(estrela);
        }


    }
    
    void Frame()
    {
        
        foreach (var piece in pieces)
        {
            var cusorInForm = piece.Rectangle.Contains(cursor);

            if (isDown && cusorInForm && selected is null)
            {
                this.selected = piece.OnSelect(cursor);
                selected.LastPosition = selected.Position;
            }

            if (isDown && selected is not null)
                selected.OnMove(cursor);

            if (!isDown && selected is not null)
            {
                selected.Position = selected.LastPosition;    
            }


            piece.DrawPieces(this.g);
            
        }

        foreach (var fixedBalance in fixedBalances)
        {
            var cusorInFixed = fixedBalance.rectangle.Contains(cursor);

            fixedBalance.DrawFixedPiece(this.g);

            if(cusorInFixed && !isDown && selected is not null && selected.CanMove)
            {
                fixedBalance.AddPiece(selected);
            }
        }

        if (!isDown)
            this.selected = null;
    }
}
