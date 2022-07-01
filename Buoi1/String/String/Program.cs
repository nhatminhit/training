using System;

namespace String
{
    class Program
    {
        static void Main(string[] args)
        {
            //string build
            string a = "buoi sang";
            Console.WriteLine($"Chao {a}");
            Console.WriteLine("");
            //string length
            string text = "ABSSASASASA";
            Console.WriteLine("Do dai chuoi la: " + text.Length);
            Console.WriteLine("");
            //date time
            var date = new DateTime(2022, 07, 01);
            Console.WriteLine(date);
            Console.WriteLine("");

            //TrimStart
            string s1 = "*****0000abc000****";
            char[] charsToTrim1 = { '*', '0' };
            string s2 = " abc";
            Console.WriteLine("Before: ");
            Console.WriteLine(s1);
            Console.WriteLine(s2);
            Console.WriteLine("");
            Console.WriteLine("after TrimStart:");
            Console.WriteLine(s1.TrimStart(charsToTrim1));
            Console.WriteLine(s2.TrimStart());

            //TrimEnd
            Console.WriteLine("");
            Console.WriteLine("after TrimEnd:");
            Console.WriteLine(s1.TrimEnd(charsToTrim1));
            Console.WriteLine(s2.TrimEnd());

            Console.WriteLine("");
            //Search String
            //truong hop dung
            string str = "ABCDFEGHY";
            int index1 = str.IndexOf('F');
            Console.WriteLine("VI tri cua 'F' " + index1);
            //truong hop sai
            int index2 = str.IndexOf('M');
            Console.WriteLine("VI tri cua 'M' " + index2);
            Console.WriteLine("");
            //Split string
            string phrase = "Viet Nam Chien Thang";
            string[] words = phrase.Split(' ');

            foreach (var word in words)
            {
                System.Console.WriteLine($"{word}");
            }

        }
    }
}
