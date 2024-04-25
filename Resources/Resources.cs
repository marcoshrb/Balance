using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;

public static class Resources
{
    public static readonly Bitmap Balance = LoadImage(@"Assets\Balance.png");
    public static readonly Bitmap Logo = LoadImage(@"Assets\logo.png");
    public static readonly Bitmap Rainbow = LoadImage(@"Assets\rainbow.png");

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
            throw new FileNotFoundException($"O arquivo de imagem '{filePath}' não foi encontrado.");
    }
}