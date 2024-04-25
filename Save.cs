using System;
using System.IO;

namespace Views
{
    public class Save
    {
        public MainForm MainForm { get; set; }

        public void Salvar()
        {
            if (string.IsNullOrEmpty(UserData.UserName) || UserData.DateStart == default(DateTime))
            {
                Console.WriteLine("Erro: UserName e/ou DateStart não estão definidos.");
                return;
            }

            string csvFilePath = @"C:\Users\disrct\Desktop\arquivo.csv";

            SaveUserDataToCsv(csvFilePath, UserData.UserName, UserData.DateStart);

            Console.WriteLine("Dados salvos em arquivo CSV com sucesso.");
            Console.ReadLine();
        }

        public static void SaveUserDataToCsv(string filePath, string userName, DateTime dateStart)
        {
            bool fileExists = File.Exists(filePath);

            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                if (!fileExists)
                {
                    writer.WriteLine("UserName,DateStart");
                }

                writer.WriteLine($"{userName},{dateStart.ToString("yyyy-MM-dd HH:mm:ss")}");

                writer.Flush();
                writer.Close();
            }
        }
    }
}
