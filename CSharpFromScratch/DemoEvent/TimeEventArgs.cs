using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DemoEvent
{
    public class TimeEventArgs :EventArgs
    {
        public int Hour { get; set; }
        public int Minute { get; set; }
        public int Second { get; set; }
    }
}
