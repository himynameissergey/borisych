using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot
{
    class ReadingTextFile
    {
        public static List<string> GetLinesOfTextFile (int LinesCount)
        {
            //string path = @"..\..\settings.txt";
            string path = @"settings.txt";
            //string[] lines = new string[LinesCount];
            List<string> lines = new List<string>();
            string str = "";
            try
            {
                using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default))
                {
                    while ((str = sr.ReadLine()) != null)
                    {
                        lines.Add(str);
                    }
                }
                return lines;
            }
            catch (Exception exept)
            {
                Console.WriteLine(exept.Message);
                return null;
            }
        }
    }
}
