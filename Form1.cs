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
    Point cursor = new Point(0, 0);
    Quadrado quadrado;
    Bola bola;
    Triangulo triangulo;
    Pentagono pentagono;
    Estrela estrela;

    QuadradoEmpty quadradoEmpty;
    BolaEmpty bolaEmpty;
    TrianguloEmpty trianguloEmpty;
    PentagonoEmpty pentagonoEmpty;
    EstrelaEmpty estrelaEmpty;
    List<Pieces> pieces = new List<Pieces>();
    List<FixedBalance> fixedBalances = new List<FixedBalance>();
    Pieces selected; 
    void Onstart()
    {
        for (int i = 0; i < 1; i++)
        {
            quadradoEmpty = new QuadradoEmpty();   
            fixedBalances.Add(quadradoEmpty);

            bolaEmpty = new BolaEmpty();   
            fixedBalances.Add(bolaEmpty);

            trianguloEmpty = new TrianguloEmpty();   
            fixedBalances.Add(trianguloEmpty);

            pentagonoEmpty = new PentagonoEmpty();   
            fixedBalances.Add(pentagonoEmpty);
            
            estrelaEmpty = new EstrelaEmpty();   
            fixedBalances.Add(estrelaEmpty);
        }

        for (int i = 0; i < 5; i++)
        {
            quadrado = new Quadrado();
            pieces.Add(quadrado);

            bola = new Bola();
            pieces.Add(bola);

            triangulo = new Triangulo();
            pieces.Add(triangulo);

            pentagono = new Pentagono();
            pieces.Add(pentagono);

            estrela = new Estrela();
            pieces.Add(estrela);
        }


    }
    
    void Frame()
    {
        
        foreach (var piece in pieces)
        {
            var cusorInForm = piece.rectangle.Contains(cursor);

            if (isDown && cusorInForm && selected is null)
            {
                this.selected = piece.OnSelect(cursor);
                selected.LastPosition = selected.position;
            }

            if (isDown && selected is not null)
                selected.OnMove(cursor);

            if (!isDown && selected is not null)
            {
                selected.position = selected.LastPosition;
                
            }


            piece.Draw(this.g);
        }

        foreach (var fixedBalance in fixedBalances)
        {
            var cusorInFixed = fixedBalance.rectangle.Contains(cursor);

            fixedBalance.Draw(this.g);

            if(cusorInFixed && !isDown && selected is not null && selected.CanMove)
            {
                fixedBalance.Add(selected);
            }
        }

        if (!isDown)
            this.selected = null;
    }
}
