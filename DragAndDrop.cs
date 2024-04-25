using Timer = System.Windows.Forms.Timer;
using DragAndDrop;

namespace Balance;

public partial class DragAndDrop : Form
{
    PictureBox pb;
    Bitmap bmp;
    Graphics g;
    Timer tm;
    Point cursor = new Point(0, 0);
    List<FixedBalance> fixedBalances = new List<FixedBalance>();
    List<Pieces> pieces = new List<Pieces>();
    Pieces selected; 
    bool isDown = false;
    public DragAndDrop()
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

        this.pb.MouseMove += (o, e) => cursor = e.Location;

        this.pb.MouseDown += (o, e) => isDown = true;

        this.pb.MouseUp += (o, e) => isDown = false;


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


    void Onstart()
    {
        // Shape Space 1
        FixedBalance square1 = new EmptySquare(new PointF(50, 400)); 
        fixedBalances.Add(square1);
        FixedBalance circle1 = new EmptyCircle(new PointF(130, 400)); 
        fixedBalances.Add(circle1);
        FixedBalance triangle1 = new EmptyTriangle(new PointF(210, 400)); 
        fixedBalances.Add(triangle1);
        FixedBalance pentagon1 = new EmptyPentagon(new PointF(290, 400)); 
        fixedBalances.Add(pentagon1);
        FixedBalance star1 = new EmptyStar(new PointF(370, 400)); 
        fixedBalances.Add(star1);

        // Shape Space 2
        FixedBalance square2 = new EmptySquare(new PointF(500, 400)); 
        fixedBalances.Add(square2);
        FixedBalance circle2 = new EmptyCircle(new PointF(580, 400)); 
        fixedBalances.Add(circle2);
        FixedBalance triangle2 = new EmptyTriangle(new PointF(660, 400)); 
        fixedBalances.Add(triangle2);
        FixedBalance polygon2 = new EmptyPentagon(new PointF(740, 400)); 
        fixedBalances.Add(polygon2);
        FixedBalance star2 = new EmptyStar(new PointF(820, 400)); 
        fixedBalances.Add(star2);

        // Shape Space 3
        FixedBalance square3 = new EmptySquare(new PointF(950, 400)); 
        fixedBalances.Add(square3);
        FixedBalance circle3 = new EmptyCircle(new PointF(1030, 400)); 
        fixedBalances.Add(circle3);
        FixedBalance triangle3 = new EmptyTriangle(new PointF(1110, 400)); 
        fixedBalances.Add(triangle3);
        FixedBalance polygon3 = new EmptyPentagon(new PointF(1190, 400)); 
        fixedBalances.Add(polygon3);
        FixedBalance star3 = new EmptyStar(new PointF(1270, 400)); 
        fixedBalances.Add(star3);

        // Shape Space 4
        FixedBalance square4 = new EmptySquare(new PointF(1400, 400)); 
        fixedBalances.Add(square4);
        FixedBalance circle4 = new EmptyCircle(new PointF(1480, 400)); 
        fixedBalances.Add(circle4);
        FixedBalance triangle4 = new EmptyTriangle(new PointF(1560, 400)); 
        fixedBalances.Add(triangle4);
        FixedBalance polygon4 = new EmptyPentagon(new PointF(1640, 400)); 
        fixedBalances.Add(polygon4);
        FixedBalance star4 = new EmptyStar(new PointF(1720, 400)); 
        fixedBalances.Add(star4);

        // Add Shapes
        for (int i = 0; i < 5; i++)
        {
            Square square = new Square();
            pieces.Add(square);

            Circle circle = new Circle();
            pieces.Add(circle);

            Triangle triangle = new Triangle();
            pieces.Add(triangle);

            Pentagon pentagon = new Pentagon();
            pieces.Add(pentagon);

            Star star = new Star();
            pieces.Add(star);
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
                selected.Position = selected.LastPosition;    
            

            piece.DrawPieces(this.g);
        }

        foreach (var fixedBalance in fixedBalances)
        {
            var cusorInFixed = fixedBalance.rectangle.Contains(cursor);

            fixedBalance.DrawFixedPiece(this.g);

            if(cusorInFixed && !isDown && selected is not null && selected.CanMove)
                fixedBalance.AddPiece(selected);
        }

        if (!isDown)
            this.selected = null;
    }
}
