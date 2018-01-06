using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Data;
using System.Data.Common;

namespace Task1
{
    [TestClass]
    
    public class PathValidatorTests
    {
        public TestContext TestContext { get; set; }
        
        
        
        [TestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML",
            "DataSource.xml",
            "InvalidPath",
            DataAccessMethod.Sequential)]
        public void IsPathValidTest_InvalidPaths_returnedFalse()
        {
            string path = Convert.ToString(TestContext.DataRow["Path"]);
            Assert.IsFalse(new PathValidator(path).IsPathValid());
        }
        
       [TestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML",
            "DataSource.xml",
            "ValidPath",
            DataAccessMethod.Sequential)]
        public void IsPathValidTest_ValidPaths_returnedTrue()
        {
            string path = Convert.ToString(TestContext.DataRow["Path"]);
            Assert.IsTrue(new PathValidator(path).IsPathValid());
        }
    }
}
