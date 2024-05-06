using System.Drawing;
using System.IO;
using OfficeOpenXml;
using System.Linq;
using System.Threading;

namespace Components;

public class BtnFinish : BtnBase
{
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

        ShadowRect(this.Rect);
        DrawShadow(g);

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
        StreamWriter writer = new StreamWriter(csvPath, false);

        writer.WriteLine(
            $"{UserData.Current.UserName},{UserData.Current.DateStart},{UserData.Current.DateFinish},{UserData.Current.RealCircleWeight},{UserData.Current.RealPentagonWeight},{UserData.Current.RealSquareWeight},{UserData.Current.RealStarWeight},{UserData.Current.RealTriangleWeight},{UserData.Current.InputCircleWeight},{UserData.Current.InputPentagonWeight},{UserData.Current.InputSquareWeight},{UserData.Current.InputStarWeight},{UserData.Current.InputTriangleWeight},{UserData.Current.Counter}");

        writer.Flush();
        writer.Close();
    }

    public void CsvToExcel()
    {
        string excelFilePath = @"S:\COM\Human_Resources\01.Engineering_Tech_School\02.Internal\5 - Aprendizes\2 - Desenvolvimento de Sistemas\3 - Desenvolvimento de Sistemas 2023\Marcos Henrique\teste.xlsx";
        string csvFilePath = "teste.csv";
        string defaultCsvFilePath = "default.csv";

        bool exists = File.Exists(excelFilePath);

        using (ExcelPackage package = new ExcelPackage(new FileInfo(excelFilePath)))
        {
            ExcelWorksheet worksheet = package.Workbook.Worksheets.FirstOrDefault();

            if (worksheet == null)
            {
                worksheet = package.Workbook.Worksheets.Add("Sheet1");

                string[] defaultCsvContent = File.ReadAllLines(defaultCsvFilePath);
                for (int col = 0; col < defaultCsvContent.Length; col++)
                {
                    string[] fields = defaultCsvContent[col].Split(',');
                    for (int i = 0; i < fields.Length; i++)
                    {
                        worksheet.Cells[1, col + i + 1].Value = fields[i];
                    }
                }
            }

            int lastUsedRow = worksheet.Dimension?.End.Row ?? 0;
            int newRow = lastUsedRow + 1;

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

            SaveExcel(package, excelFilePath);
        }
    }

    private void SaveExcel(ExcelPackage package, string excelFilePath)
    {
        bool saved = false;
        while (!saved)
        {
            try
            {
                using (FileStream fileStream = new FileStream(excelFilePath, FileMode.Create))
                {
                    package.SaveAs(fileStream);
                }
                saved = true;
            }
            catch (System.Exception)
            {
                Thread.Sleep(1000);
            }
        }
    }
}
