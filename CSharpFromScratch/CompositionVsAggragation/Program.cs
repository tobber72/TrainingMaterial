using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositionVsAggragation
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee tom = new Employee("Tom", "123 NW Street", "Des Moines", "Iowa", "50000");
            Console.WriteLine(tom.ToString());
            tom.Insurance = new InsuranceInfo() { policyid="1", policyname="Policy Name" };
            Console.WriteLine(tom.ToString());
            Console.ReadLine();
        }
    }
}
