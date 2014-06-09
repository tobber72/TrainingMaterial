using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkingWithStringData
{
    public class CheckedKeyword
    {
        static int Add(int x, int y)
        {
            return x + y;
        }

        static string ProcessBytes()
        {
            byte b1 = 100;
            byte b2 = 250;
            byte sum = (byte)Add(b1, b2);
            // sum should hold the value 350. However, we find the value 94!
            return string.Format("sum = {0}", sum);
        }

        static void ProcessBytes_exec()
        {
            byte b1 = 100;
            byte b2 = 250;
            // This time, tell the compiler to add CIL code
            // to throw an exception if overflow/underflow
            // takes place.
            try
            {
                byte sum = checked((byte)Add(b1, b2));
                Console.WriteLine("sum = {0}", sum);
            }
            catch (OverflowException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// If you wish to force overflow checking to occur over a block of code statements, you can do so by defining a “checked scope” as follows:
        /// </summary>
        static void ProcessBytes_checked()
        {
            try
            {
                checked
                {
                    byte sum = (byte)Add(b1, b2);
                    Console.WriteLine("sum = {0}", sum);
                }
            }
            catch (OverflowException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


    }
}
