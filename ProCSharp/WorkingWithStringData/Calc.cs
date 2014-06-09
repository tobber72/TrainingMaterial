using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkingWithStringData
{
    public class Calc
    {

        public int Add(int x, int y) { return x + y; }

        public decimal Add(decimal x, decimal y) { return x + y; }

        public double Add(double x, double y) { return x + y; }

        //public string Add( string x, string y ) {
        //	return ( int.Parse( x ) + int.Parse( y ) ).ToString();
        //}

        public string Add(string x, string y)
        {
            return (x + y);
        }
    }
}
