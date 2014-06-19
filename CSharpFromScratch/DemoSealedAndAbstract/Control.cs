using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoSealedAndAbstract
{
    public abstract class Control
    {
        protected int top;
        protected int left;

        public Control() :this(0,0)
        {

        }

        public Control(int top, int left)
        {
            this.top = top;
            this.left = left;
        }

        public abstract void DrawMe();
    }
}
