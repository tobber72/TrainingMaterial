using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoPolymorphism
{
    public class Employee
    {
        public string name { get; set; }
        public int salary { get; set; }

        public Employee() : this("none", 1)
        {

        }

        public Employee(string name, int salary)
        {
            this.name = name;
            this.salary = salary;
        }

        public virtual string DoWork()
        {
            return "Employee doing work";
        }

        public virtual int GiveRaise()
        {
            salary = salary * 2;
            return salary;
        }

        public override string ToString()
        {
            string retVal = string.Format("{0}: {1}", name, salary);

            return retVal;
        }

    }
}
