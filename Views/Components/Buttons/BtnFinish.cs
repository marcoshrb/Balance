using System.Drawing;
using System.IO;
using System;
using System.Reflection.Metadata.Ecma335;
using System.Windows.Forms;
using OfficeOpenXml;
using System.Linq;
using System.Threading;

namespace Views.Components;

public class BtnFinish : BtnBase
{
    public RectangleF Rect { get; set; }
    private string text { get; set; }

    public BtnFinish(float X, float Y, float width, float height, string text)
    {
        this.Rect = new RectangleF(X, Y, width, height);
        this.text = text;
    }

    public override void DrawButton(Graphics g)
    {
        Font font = new Font("Arial bold", this.Rect.Width * 0.12f);
        SizeF textSize = g.MeasureString(this.text, font);

        g.FillRectangle(Brushes.Green, this.Rect);
        g.DrawString(
            this.text,
            font,
            Brushes.White,
            new PointF(
                this.Rect.X + (this.Rect.Width / 2 - textSize.Width / 2),
                this.Rect.Y + (this.Rect.Height / 2 - textSize.Height / 2)
            )
        );
    }

    public override void FinishChallenge()
    {
        string csvPath = "./teste.csv";
        // bool fileExists = File.Exists("teste.csv");
        StreamWriter writer = new StreamWriter(csvPath, false);
        // if(!fileExists)
        //     writer.WriteLine("Name,Start,End,RealCircle,RealPentagon,RealSquare,RealStar,RealTriangle,InputCircle,InputPentagon,InputSquare,InputStar,InputTriangle");
        
        writer.WriteLine(
            $"{UserData.Current.UserName
            },{UserData.Current.DateStart
            },{UserData.Current.DateFinish
            },{UserData.Current.RealCircleWeight
            },{UserData.Current.RealPentagonWeight
            },{UserData.Current.RealSquareWeight
            },{UserData.Current.RealStarWeight
            },{UserData.Current.RealTriangleWeight
            },{UserData.Current.InputCircleWeight
            },{UserData.Current.InputPentagonWeight
            },{UserData.Current.InputSquareWeight
            },{UserData.Current.InputStarWeight
            },{UserData.Current.InputTriangleWeight
        }");

        writer.Flush();
        writer.Close();
    }

    public void CsvToExcel()
    {
        string excelFilePath = $"S:/COM/Human_Resources/01.Engineering_Tech_School/02.Internal/5 - Aprendizes/2 - Desenvolvimento de Sistemas/3 - Desenvolvimento de Sistemas 2023/Felipe de Mello Vieira/teste.xlsx";
        string csvFilePath = "teste.csv";

        using (ExcelPackage package = new ExcelPackage(new FileInfo(excelFilePath)))
        {
            ExcelWorksheet worksheet = package.Workbook.Worksheets.FirstOrDefault();

            if (worksheet == null)
            {
                worksheet = package.Workbook.Worksheets.Add("Sheet1");
            }

            int lastUsedRow = worksheet.Dimension.End.Row;
            int newRow = lastUsedRow + 1;

            // Ler o conteúdo do arquivo CSV e escrever no Excel a partir da próxima linha vazia
            foreach (string line in File.ReadLines(csvFilePath))
            {
                string[] fields = line.Split(',');
                int col = 1;
                foreach (string field in fields)
                {
                    worksheet.Cells[newRow, col].Value = field;
                    col++;
                }
                newRow++;
            }

            // Salvar o arquivo Excel
            SaveExcel(package);
        }

        MessageBox.Show("Na teoria funcionou.");
    }

    private void SaveExcel(ExcelPackage package)
    {
        bool saved = false;
        while(!saved)
        {
            try
            {
                package.Save();
                saved = true;
            }
            catch (System.Exception)
            {
                Thread.Sleep(1000);
            }
        }
    }
}
