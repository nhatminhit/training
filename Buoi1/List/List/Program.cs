using System;
using System.Collections.Generic;

namespace List
{
    class Program
    {
        static void Main()
        {
            List<string> Car = new List<string>();
            Car.Add("Mazda");
            Car.Add("Mecxedes");
            Car.Add("Kia");
            Car.Add("Huyndai");
            Console.WriteLine("Original List items");
            Console.WriteLine("===============");
            // Print original order
            foreach (string a in Car)
                Console.WriteLine(a);
            // Sort list items
            Car.Sort();
            Console.WriteLine();
            Console.WriteLine("Sorted List items");
            Console.WriteLine("===============");
            // Print sorted items
            foreach (string a in Car)
                Console.WriteLine(a);
            // Delete items
            Console.WriteLine("");
            Console.WriteLine("Delete List items");
            Console.WriteLine("===============");
            Car.Remove("Kia");
            foreach (string a in Car)
                Console.WriteLine(a);
            Console.WriteLine("");
            Console.WriteLine("Insert item");
            // insert item
            Car.Add("BMW");
            foreach (string a in Car)
                Console.WriteLine(a);
            //Find item
            Console.WriteLine("");
            Console.WriteLine("Find item");
            int idx = Car.IndexOf("BMW");
            if (idx > 0)
                Console.WriteLine($"Xe o vi tri: {idx}");
            else
                Console.WriteLine("Không tìm thấy xe này");
        }
    }
}
