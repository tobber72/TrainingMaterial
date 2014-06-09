using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;

namespace WorkingWithStringData.UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        Calc c = new Calc();

        [TestMethod]
        public void TestMethod1()
        {
            for (int x = 0; x < 10000; x++)
            {
                c.Add(x, x);
            }
        }

        [TestMethod]
        public void TestMethod2()
        {
            for (int x = 0; x < 10000; x++)
            {
                c.Add(x.ToString(), x.ToString());
            }
        }

        [TestMethod]
        public void TestMethod3()
        {
            Assert.IsTrue(c.Add(1, 1) == 2);
        }

        [TestMethod]
        public void TestMethod4()
        {
            Assert.IsTrue(c.Add("1", "1") == "2");
        }

        [TestMethod]
        public void StringMunipulation()
        {
            string s = string.Empty;
            for (int x = 0; x < 10000; x++)
            {
                s += Guid.NewGuid().ToString();
            }
        }

        [TestMethod]
        public void StringBuilderMunipulation()
        {
            StringBuilder s = new StringBuilder();
            for (int x = 0; x < 10000; x++)
            {
                //s.Clear();
                //s.Append( x.ToString() );
                s.Append(Guid.NewGuid().ToString());
            }
        }
    }
}
