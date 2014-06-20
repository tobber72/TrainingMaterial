using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace DemoIntroRegEx
{
    class Program
    {
        private const string MatchSuccess = "{0} @{1}:{2}";

        static void Main(string[] args)
        {
        }

        public void SampleOne(string[] args)
        {
            var pattern = args[0];
            var subject = args[1];
            var regex = new Regex(pattern);
            var match = regex.Match(subject);
            Console.WriteLine(match.Success);        
        }

        public void SampleTwo(string[] args)
        {
            var pattern = args[0];
            var subject = args[1];
            var regex = new Regex(pattern);
            var match = regex.Match(subject);
            if (match.Success)
            {
                Console.WriteLine(MatchSuccess, match.Success, match.Index, match.Length);
            }
            else {
                Console.WriteLine(match.Success);
            }
        }

        public void SampleThree(string[] args)
        {
            var pattern = args[0];
            var subject = args[1];
            var regex = new Regex(pattern);
            var match = regex.Match(subject);

            while (match.Success)
            {
                Console.WriteLine(MatchSuccess, match.Success, match.Index, match.Length);
                match = match.NextMatch();            
            }

            Console.WriteLine(match.Success);
        }

        /// <summary>
        /// EscapeMe TEST App
        /// </summary>
        /// <param name="args"></param>
        public void SampleFour(string[] args)
        {
            var pattern = args[0];
            var subject = args[1];
            var escapedPattern = Regex.Escape(pattern);

            Console.WriteLine("Escaped Pattern: \" {)}\"", escapedPattern);

            var regex = new Regex(escapedPattern);
            var match = regex.Match(subject);

            while (match.Success)
            {
                Console.WriteLine(MatchSuccess, match.Success, match.Index, match.Length);
                match = match.NextMatch();
            }

            Console.WriteLine(match.Success);
        }
    }
}
