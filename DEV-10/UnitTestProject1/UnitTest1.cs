using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DEV_10;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {

            ToDoubleArrayConverter converter = new ToDoubleArrayConverter();
            string[][] array= new {  { "2.2", "2.7"}  ,  { "2.50", "1.34"} };
        }
    }
}
