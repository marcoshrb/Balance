using System.Drawing;
using System.IO;
using OfficeOpenXml;
using System.Linq;
using System.Threading;
using OfficeOpenXml.Style;

namespace Components;

public class BtnFinish : BtnBase
{
    private string text { get; set; }

    public BtnFinish(float X, float Y, float width, float height, string text)
    {
        this.Hitbox = new RectangleF(X, Y, width, height);
        this.text = text;
    }

    public override void Draw(Graphics g)
    {
        Font font = new Font("Arial bold", this.Hitbox.Width * 0.12f);
        SizeF textSize = g.MeasureString(this.text, font);

        ShadowRect(this.Hitbox);
        DrawShadow(g);

        g.FillRectangle(Brushes.Green, this.Hitbox);
        g.DrawString(
            this.text,
            font,
            Brushes.White,
            new PointF(
                this.Hitbox.X + (this.Hitbox.Width / 2 - textSize.Width / 2),
                this.Hitbox.Y + (this.Hitbox.Height / 2 - textSize.Height / 2)
            )
        );
    }

    public override void FinishChallenge()
    {
        string csvPath = "./teste.csv";
        StreamWriter writer = new StreamWriter(csvPath, false);

        string content = $"";
        content += UserData.Current.UserName + ",";
        content += UserData.Current.MoveCounter + ",";

        var inputValues = UserData.Current.InputValues();
        for (int i = 0; i < 5; i++)
        {
            if (inputValues[i] == 0)
                content += "-,";
            else if (inputValues[i] == UserData.Current.RealValues[i])
                content += "true,";
            else
                content += "false,";
        }

        content += UserData.Current.DateStart + ",";
        content += UserData.Current.DateFinish + ",";

        for (int i = 0; i < 5; i++)
            content += UserData.Current.RealValues[i] + ",";

        for (int i = 0; i < 5; i++)
            content += inputValues[i] + ",";

        content = content.Remove(content.Length - 1, 1);

        writer.WriteLine(content);

        writer.Flush();
        writer.Close();
    }

    public void CsvToExcel()
    {
        string excelFilePath = @"S:\COM\Human_Resources\01.Engineering_Tech_School\02.Internal\5 - Aprendizes\2 - Desenvolvimento de Sistemas\3 - Desenvolvimento de Sistemas 2023\Marcos Henrique\teste.xlsx";
        string csvFilePath = "teste.csv";
        string defaultCsvFilePath = "default.csv";

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
                        worksheet.Cells[1, col + i + 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        worksheet.Cells[1, col + i + 1].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                        worksheet.Cells[1, col + i + 1].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(47, 117, 181));
                        worksheet.Cells[1, col + i + 1].Style.Font.Color.SetColor(System.Drawing.Color.White);
                        worksheet.Cells[1, col + i + 1].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                        worksheet.Cells[1, col + i + 1].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                        worksheet.Cells[1, col + i + 1].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                        worksheet.Cells[1, col + i + 1].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
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
                    worksheet.Cells[newRow, col].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    worksheet.Cells[newRow, col].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    worksheet.Cells[newRow, col].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    worksheet.Cells[newRow, col].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    worksheet.Cells[newRow, col].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    if (field == "true")
                    {
                        worksheet.Cells[newRow, col].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                        worksheet.Cells[newRow, col].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(198, 239, 206));
                        worksheet.Cells[newRow, col].Style.Font.Color.SetColor(System.Drawing.Color.FromArgb(0, 97, 0));
                        worksheet.Cells[newRow, col].Value = "✔";
                    }
                    else if (field == "false")
                    {
                        worksheet.Cells[newRow, col].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                        worksheet.Cells[newRow, col].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(255, 199, 206));
                        worksheet.Cells[newRow, col].Style.Font.Color.SetColor(System.Drawing.Color.FromArgb(156, 0, 6));
                        worksheet.Cells[newRow, col].Value = "❌";
                    }
                    else
                    {
                        worksheet.Cells[newRow, col].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                        worksheet.Cells[newRow, col].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.White);
                        worksheet.Cells[newRow, col].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                        worksheet.Cells[newRow, col].Value = field;
                    }
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
