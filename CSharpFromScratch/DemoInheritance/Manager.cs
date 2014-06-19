using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoInheritance
{
    public class Manager : Employee
    {
        public Manager() : this("NONE")
        {

        }

        public Manager(string name) :
             base(name)
        {

        }

        public override string DoWork()
        {
            return "Manager doing work";
        }
    }
}
