using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoInterfaces
{
    interface IPrintable
    {
        void Print();
        int Status { get;  }
    }
}
