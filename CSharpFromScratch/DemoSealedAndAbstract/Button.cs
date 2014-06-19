using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoSealedAndAbstract
{
    public class Button :Control
    {
        public string Contents { get; set; }

        public Button()
        {

        }

        public Button(int top, int left, string contents) :base (top,left)
        {
            this.Contents = contents;
        }

        public override void DrawMe()
        {
            Console.WriteLine("Drawing button with contents: " + Contents);
        }
    }
}
