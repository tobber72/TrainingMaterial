using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoInheritance
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee Tom = new Employee("Tom");
            Employee Joe = new Employee("Joe");
            Manager Dave = new Manager("Dave");

            List<Employee> employees = new List<Employee>();
            employees.Add(Tom);
            employees.Add(Joe);
            employees.Add(Dave);

            employees.ForEach(x => {
                Console.WriteLine(x.ToString());
            });
            Console.ReadLine();
        }
    }
}
