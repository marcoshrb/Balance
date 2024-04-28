using System.Drawing;
using System.Windows.Forms;

namespace Utils;

public static class ImageProcessing
{
    public static Image ResizeImage(Image image, Size newSize) => new Bitmap(image, newSize);

    public static Bitmap ResizeImage(Bitmap image, Size newSize) => new Bitmap(image, newSize);

    public static Image GetImage(string imagePath) => Image.FromFile(imagePath);
}
