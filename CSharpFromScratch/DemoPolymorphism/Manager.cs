using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoPolymorphism
{
    public class Manager : Employee
    {
        public Manager() : this("NONE", 1)
        {

        }

        public Manager(string name, int salary) : base(name, salary)
        {

        }

        public string GivePraise()
        {
            return "Good Job!";
        }

        public override string DoWork()
        {
            return "Manager doing work";
        }

        public override int GiveRaise()
        {
            salary = salary * 10;
            return salary;
        }

    }
}
