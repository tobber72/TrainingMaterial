using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkingWithStringData;

namespace WorkingWithStringDataConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Calc c = new Calc();
            int ans = c.Add(10, 84);
            Console.WriteLine("10 + 84 is {0}.", ans);


            decimal ans2 = c.Add((decimal)3.65, (decimal)0.05);
            Console.WriteLine("3.65 + 0.05 is {0}.", ans2);

            double ans3 = c.Add(3.65, 0.05);
            Console.WriteLine("3.65 + 0.05 is {0}.", ans3);

            string ans4 = c.Add("10", "84");
            Console.WriteLine("10 + 84 is {0}.", ans4);

            double x = 3.65, y = 0.05, z = 3.7;
            Console.WriteLine((x + y) == z); // false
            Console.WriteLine((x + y));

            decimal a = (decimal)3.65, b = (decimal)0.05, d = (decimal)3.7;
            Console.WriteLine((a + b) == d); // false
            Console.WriteLine((a + b));


            // Wait for user to press the Enter key before shutting down.
            Console.ReadLine();  
        }
    }
}
