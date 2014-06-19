using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoPolymorphism
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee Tom = new Employee("Tom", 10000);
            Employee Joe = new Employee("Joe", 20000);
            Manager Dave = new Manager("Dave", 30000);

            List<Employee> employees = new List<Employee>();
            employees.Add(Tom);
            employees.Add(Joe);
            employees.Add(Dave);

            employees.ForEach(x =>
            {
                Console.WriteLine(x.ToString());
            });

            employees.ForEach(x =>
            {
                x.GiveRaise();
                Console.WriteLine(x.ToString());
            });
            
            Console.ReadLine();
        }
    }
}
