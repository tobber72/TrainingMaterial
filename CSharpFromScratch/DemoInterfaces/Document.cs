using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoInterfaces
{
    public class Document : IPrintable
    {
        public string  DocName { get; set; }

        public void CountCharacters()
        {
            Console.WriteLine("1,000");
        }

        public void Print()
        {
            Console.WriteLine("Writing document to printer...");
        }

        public int Status
        {
            get { return 0; }
        }
    }
}
