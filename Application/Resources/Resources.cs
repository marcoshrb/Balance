using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;

public static class Resources
{
    public static readonly Bitmap HelpImage = LoadImage(@"Assets\help.png");
    
    public static readonly Image BackRectChallenge = LoadImage(@"Assets\BackRectChallenge.png");
    public static readonly Image BackRectRight = LoadImage(@"Assets\BackRectRight.png");
    public static readonly Image BackRectTrain = LoadImage(@"Assets\BackRectTrain.png");
    public static readonly Bitmap Balance = LoadImage(@"Assets\Balance.png");
    public static readonly Bitmap Logo = LoadImage(@"Assets\logo.png");
    public static readonly Bitmap Rainbow = LoadImage(@"Assets\rainbow.png");
    public static readonly Bitmap Square = LoadImage(@"Assets\Shapes\pieces\Quadrado.png");
    public static readonly Bitmap SquareEmpty = LoadImage(
        @"Assets\Shapes\piecesEmpty\Quadrado.png"
    );
    public static readonly Bitmap Circle = LoadImage(@"Assets\Shapes\pieces\Bola.png");
    public static readonly Bitmap CircleEmpty = LoadImage(@"Assets\Shapes\piecesEmpty\Bola.png");
    public static readonly Bitmap Pentagon = LoadImage(@"Assets\Shapes\pieces\Pentagono.png");
    public static readonly Bitmap PentagonEmpty = LoadImage(
        @"Assets\Shapes\piecesEmpty\Pentagono.png"
    );
    public static readonly Bitmap Star = LoadImage(@"Assets\Shapes\pieces\Estrela.png");
    public static readonly Bitmap StarEmpty = LoadImage(@"Assets\Shapes\piecesEmpty\Estrela.png");
    public static readonly Bitmap Triangle = LoadImage(@"Assets\Shapes\pieces\Triangulo.png");
    public static readonly Bitmap TriangleEmpty = LoadImage(
        @"Assets\Shapes\piecesEmpty\Triangulo.png"
    );

    private static List<Bitmap> LoadImagesFromDirectory(string directoryPath)
    {
        if (Directory.Exists(directoryPath))
        {
            return Directory
                .GetFiles("assets/Maps/", "*.png")
                .Select(file => Bitmap.FromFile(file) as Bitmap)
                .ToList();
        }
        else
        {
            throw new DirectoryNotFoundException("O diretório especificado não foi encontrado.");
        }
    }

    private static Bitmap LoadImage(string filePath)
    {
        if (File.Exists(filePath))
            return new Bitmap(filePath);
        else
            throw new FileNotFoundException(
                $"O arquivo de imagem '{filePath}' não foi encontrado."
            );
    }
}
