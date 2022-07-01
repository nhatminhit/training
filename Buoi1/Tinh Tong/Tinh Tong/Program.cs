using System;

namespace Tinh_Tong
{
    class Program
    {
        public static int SUM(int s1,int s2)
        {
            int tong;
            tong = s1 + s2;
            return tong;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("\nNhap so thu nhat:");
            int a = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("\nNhap so thu hai:");
            int b = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("\nTong hai so: {0} \n", SUM(a, b));
        }
    }
}
