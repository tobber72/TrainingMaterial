using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoDelegates
{
    public class EmailSender
    {
        private int sendResults;
        public int SendEmail()
        {
            Console.WriteLine("Simulating sending email...");
            sendResults = 0;
            return sendResults;
        }
    }
}
