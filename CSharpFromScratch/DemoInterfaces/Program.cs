using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoInterfaces
{
    class Program
    {
        static void Main(string[] args)
        {
            var mydoc = new Document();
            mydoc.Print();
            mydoc.CountCharacters();

            IPrintable printItem = mydoc;
            printItem.Print();
            //printItem.CountCharacters();
            Document theDoc = printItem as Document;
            if (theDoc != null)
                theDoc.CountCharacters();

            Console.ReadLine();

        }
    }
}
