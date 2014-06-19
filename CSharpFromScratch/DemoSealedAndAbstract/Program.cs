using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoSealedAndAbstract
{
    class Program
    {
        static void Main(string[] args)
        {
            // Control c = new Control();

            Control button = new Button(0, 0, "Click Me!");
            Control textblock = new TextBlock(20, 20, "Hello World");

            List<Control> controls = new List<Control>();
            controls.Add(button);
            controls.Add(textblock);
            controls.ForEach(x => { x.DrawMe(); });

            Console.ReadLine();

        }
    }
}
