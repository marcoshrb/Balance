using System;
using System.IO;
using System.Windows.Forms;
using OfficeOpenXml;

public class UserData
{
    private static UserData current;
    public static UserData Current => current;
    private UserData() { }
    public static void New() => current = new UserData();
    public string UserName { get; set; }
    public DateTime DateStart { get; set; }
    public DateTime DateFinish { get; set; }
    public int RealSquareWheight { get; set; }
    public int RealTriangleWheight { get; set; }
    public int RealCircleWheight { get; set; }
    public int RealStartWheight { get; set; }
    public int RealPentagonWheight { get; set; }
    public int InputSquareWheight { get; set; }
    public int InputTriangleWheight { get; set; }
    public int InputCircleWheight { get; set; }
    public int InputStartWheight { get; set; }
    public int InputPentagonWheight { get; set; }
    public void Save()
    {
        if (string.IsNullOrEmpty(this.UserName) || this.DateStart == default)
        {
            Console.WriteLine("Error: UserName and/or DateStart are not defined.");
            return;
        }

        string csvFilePath = @"C:\Users\disrct\Desktop\userdata.csv";
        SaveToCsv(csvFilePath, this.UserName, this.DateStart);
        // string excelFilePath = @"C:\Users\disrct\Desktop\userdata.xlsx";
        // SaveToExcel(excelFilePath);

        Console.WriteLine("Data saved to CSV file successfully.");
        Console.ReadLine();
    }

    private static void SaveToCsv(string filePath, string userName, DateTime dateStart)
    {
        bool fileExists = File.Exists(filePath);

        using (StreamWriter writer = new StreamWriter(filePath, true))
        {
            if (!fileExists)
            {
                writer.WriteLine("UserName,DateStart");
            }

            writer.WriteLine($"{userName},{dateStart:yyyy-MM-dd HH:mm:ss}");

            writer.Flush();
        }
    }

    public void SaveToExcel(string filePath)
    {
        if (string.IsNullOrEmpty(this.UserName) || this.DateStart == default)
        {
            Console.WriteLine("Error: UserName and/or DateStart are not defined.");
            return;
        }

        MessageBox.Show(File.Exists(filePath).ToString());
        if (!File.Exists(filePath))
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            var newFile = new FileInfo(filePath);
            using (var package = new ExcelPackage(newFile))
            {
                package.Save();
            }
        }

        using (var package = new ExcelPackage(new FileInfo(filePath)))
        {
            var worksheet = package.Workbook.Worksheets.Add("UserData");
            worksheet.Cells["A1"].Value = "UserName";
            worksheet.Cells["B1"].Value = "DateStart";
            worksheet.Cells["C1"].Value = "DateFinish";
            worksheet.Cells["D1"].Value = "RealSquareWeight";
            worksheet.Cells["E1"].Value = "RealTriangleWeight";
            worksheet.Cells["F1"].Value = "RealCircleWeight";
            worksheet.Cells["G1"].Value = "RealStartWeight";
            worksheet.Cells["H1"].Value = "RealPentagonWeight";
            worksheet.Cells["I1"].Value = "InputSquareWeight";
            worksheet.Cells["J1"].Value = "InputTriangleWeight";
            worksheet.Cells["K1"].Value = "InputCircleWeight";
            worksheet.Cells["L1"].Value = "InputStartWeight";
            worksheet.Cells["M1"].Value = "InputPentagonWeight";

            worksheet.Cells["A2"].Value = this.UserName;
            worksheet.Cells["B2"].Value = this.DateStart;
            worksheet.Cells["C2"].Value = this.DateFinish;
            worksheet.Cells["D2"].Value = this.RealSquareWheight;
            worksheet.Cells["E2"].Value = this.RealTriangleWheight;
            worksheet.Cells["F2"].Value = this.RealCircleWheight;
            worksheet.Cells["G2"].Value = this.RealStartWheight;
            worksheet.Cells["H2"].Value = this.RealPentagonWheight;
            worksheet.Cells["I2"].Value = this.InputSquareWheight;
            worksheet.Cells["J2"].Value = this.InputTriangleWheight;
            worksheet.Cells["K2"].Value = this.InputCircleWheight;
            worksheet.Cells["L2"].Value = this.InputStartWheight;
            worksheet.Cells["M2"].Value = this.InputPentagonWheight;

            package.Save();
        }

        Console.WriteLine("Data saved to Excel file successfully.");
    }
}

