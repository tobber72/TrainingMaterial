using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoInheritance
{
    public class Employee
    {
        public string name { get; set; }

        public Employee()
        {

        }

        public Employee(string name)
        {
            this.name = name;
        }

        public virtual string DoWork()
        {
            return "Employee doing work";
        }

        public override string ToString()
        {
            string retVal = string.Format("{0}", name);

            return retVal;
        }

    }
}
