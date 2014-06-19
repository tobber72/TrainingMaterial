using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoEvent
{
    public class Logger
    {

        /// <summary>
        /// LAMBDA Method
        /// </summary>
        /// <param name="theClock"></param>
        public void Subscribe(Clock theClock)
        {
            theClock.TimeChanged += (sender, e)  =>
            {
                Console.WriteLine("Logging Time: {0},{1},{2}", e.Hour.ToString(), e.Minute.ToString(), e.Second.ToString());
            };
        }


        /// <summary>
        /// Anonymous Method
        /// </summary>
        /// <param name="theClock"></param>
        //public void Subscribe(Clock theClock)
        //{
        //    theClock.TimeChanged += delegate(object sender, TimeEventArgs e) {
        //        Console.WriteLine("Logging Time: {0},{1},{2}", e.Hour.ToString(), e.Minute.ToString(), e.Second.ToString());
        //    };
        //}

        
        //public void Subscribe(Clock theClock)
        //{
        //    theClock.TimeChanged += new Clock.TimeChangeHandler(NewTime);

        //}

        //private void NewTime(object clock, TimeEventArgs e)
        //{
        //    Console.WriteLine("Logging Time: {0},{1},{2}", e.Hour.ToString(), e.Minute.ToString(), e.Second.ToString());
        //}



    }
}
