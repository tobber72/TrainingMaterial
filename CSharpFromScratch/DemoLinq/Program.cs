using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoLinq
{
    class Program
    {
        static void Main(string[] args)
        {
            //// LINQ Simple Query
            //var primes = new List<int> {2,3,5,7,11,13,17,19,23 };
            //var query = from val in primes
            //            where val < 13
            //            select val;
            //foreach (var val in query) {
            //    Console.WriteLine(val);
            //}

            //// LINQ Orderby and Grouping
            //var query = from method in typeof(double).GetMethods()
            //            orderby method.Name
            //            group method by method.Name into groups
            //            select new { Methodname = groups.Key, NumberOfOverloads = groups.Count() };
                        
            //foreach (var item in query)
            //{
            //    Console.WriteLine(item);
            //}

            //// Any and Contains Operator
            //var listOne = Enumerable.Empty<int>();
            //var listTwo = Enumerable.Range(1,20);
            //bool listOneEmpty = listOne.Any();
            //bool listTwoEmpty = listTwo.Any();
            //Console.WriteLine("list one has members? " + listOneEmpty + " list two has members? " + listTwoEmpty);
            //Console.WriteLine("list two has 12? " + listTwo.Contains(12) + " list two has 30? " + listTwo.Contains(30));

            //// Take Operator
            //var bigList = Enumerable.Range(1, 20);
            //var littleList = bigList.Take(5).Select(x => x * 10);
            //foreach (var i in littleList)
            //{
            //    Console.WriteLine(i);
            //}

            // Zip Operator
            List<string> code = new List<string>() { "A","B","C","D","E" };
            List<string> value = new List<string>() { "1", "2", "3", "4", "5" };

            var output = code.Zip(value, (c, v) => c + ": " + v);
            foreach (var o in output)
            {
                Console.WriteLine(o);
            }

            Console.ReadLine();
        }
    }
}
