using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace ParseKeyValuePairs
{
    /// <summary>
    /// How to parse key/value pairs in C#
    /// http://answers.oreilly.com/topic/2124-how-to-parse-keyvalue-pairs-in-c/
    /// </summary>
    class Program
    {
        private const string MatchSuccess = " Success: {0} , Index: {1} , Length: {2} , Value , {3} ";
        public static List<string> pattern = new List<string>() { "Year", "Month", "Week", "Day" };

        static void Main(string[] args)
        {
            ParseByInterval("1 Year 1 Month 1 Week 1 Day");
            ParseByInterval("12 Year 23 Month 45 Week 67 Day");
            ParseByInterval("123 Year 234 Month 345 Week 456 Day");
            ParseByInterval("1 Year 1 Month");
            ParseByInterval("1 Year 1 Day");
            ParseByInterval("1 Year");
            //DemoGrouping("1 Year 1 Month 1 Week 1 Day");
            //TestFindMatchesInStringArray();
            Console.ReadLine();
        }
        
        public static DateTime ParseByInterval(string ByIntervalText)
        {
            // ByIntervalText = "1 Year 1 Month 1 Week 1 Day";
            // int spaceCount = ByIntervalText.Trim().Split(new Char[] { ' ' }).Length - 1;
            DateTime retDate = DateTime.Now;

            foreach (string x in pattern)
            {
                var regex = new Regex("\\d+ [" + x + "]");
                var match = regex.Match(ByIntervalText);
                if (match.Success)
                {
                    Console.WriteLine(x + " " + MatchSuccess, match.Success, match.Index, match.Length, match.Value);

                    int addValue = int.Parse(Regex.Match(match.Value, @"\d+").Value);
                    if (x == "Year") { retDate = retDate.AddYears(addValue); }
                    if (x == "Month") { retDate = retDate.AddMonths(addValue); }
                    if (x == "Week") { retDate = retDate.AddDays(addValue * 7); }
                    if (x == "Day") { retDate = retDate.AddDays(addValue); }
                }
                else
                {
                    Console.WriteLine("NO MATCH");
                }
            }
            Console.WriteLine("Return Date: {0}", retDate.ToShortDateString());

            return DateTime.Now;
        }

        //public static void TestFindMatchesInStringArray()
        //{
        //    string markup = "hi";
        //    string[] strArray = new string[] { "Hi", "Hello", "hi", "Good Morning" };
        //    FindMatchesInStringArray(markup, strArray);
        //}

        //static void FindMatchesInStringArray(string markup, string[] strArray)
        //{
        //    for (int i = 0; i < strArray.Length; i++)
        //    {
        //        Match Match = Regex.Match(markup, strArray[i], RegexOptions.IgnoreCase);
        //        if (Match.Success)
        //        {
        //            Console.WriteLine(Match.Groups[0]);
        //        }
        //    }
        //}        
        
        public static void DemoGrouping(string ByIntervalText)
        {
            string reg = @"^([\w]+) ([\w]+)$";

            Match m = Regex.Match(ByIntervalText, reg, RegexOptions.CultureInvariant);

            foreach (Group g in m.Groups)
            {
                Console.WriteLine(g.Value);
            }
        }

        public static List<string> RegexFindGroups(string input, string pattern)
        {
            Regex re = new Regex(pattern);
            var groups = re.Match(input).Groups;
            var values = new List<string>();
            foreach (Group g in groups)
                values.Add(g.Value);
            return values;
        }

        public static List<string> RegexFindKeyValue(string input)
        {
            var pattern = @"\s*(\w+)=([^\s]+)\s*";
            var groups = RegexFindGroups(input, pattern);
            var list = new List<string>();
            if (groups[0] == input)
            {
                list.Add(groups[1]);
                list.Add(groups[2]);
            }
            return list;
        }

        public static Dictionary<string, string>
          RegexFindKeysAndValues(List<string> keys, string input)
        {
            string keystrings = String.Join("|", keys.ToArray());
            string regex = String.Format(@"({0})=([^\s]+)", keystrings);
            Regex reg = new Regex(regex);
            var metadict = new Dictionary<string, string>();
            Match m = reg.Match(input);
            while (m.Success)
            {
                var key_value = RegexFindKeyValue(m.Groups[0].ToString());
                metadict.Add(key_value[0], key_value[1]);
                m = m.NextMatch();
            }
            return metadict;
        }
    }
}
