using System;
using System.IO;
namespace Input___Output
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader file = File.OpenText("test.txt");
            string line;
            int dem = 0;
            do
            {
                line = file.ReadLine();
                if (line != null)
                {
                    string[] words = line.Split(' ');
                    dem += words.Length;
                }
            }
            while (line != null);
            file.Close();
            Console.WriteLine("Trong file co so tu la: "+dem);
        }
    }
}
