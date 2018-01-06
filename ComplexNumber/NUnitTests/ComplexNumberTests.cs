using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using ComplexNumberProject;
using NUnit.Compatibility;

namespace NUnitTests
{
    [TestFixture]
    public class ComplexNumberTests
    {
        private static object[] positiveSumOperatorDataSource =
        {
            new object[] { new ComplexNumber(0,0), new ComplexNumber(0, 0), new ComplexNumber(0, 0)},
            new object[] { new ComplexNumber(50, -7), new ComplexNumber(-49, -6), new ComplexNumber(1, -13)},
            new object[] { new ComplexNumber(0,1), new ComplexNumber (1,0), new ComplexNumber(1, 1) }
        };
        
        [Test, TestCaseSource("positiveSumOperatorDataSource")]
        public void TestSumOperand(ComplexNumber left, ComplexNumber right, ComplexNumber expected)
        {
            Assert.AreEqual(left + right, expected);           
        }

        private static object[] positiveDivideOperatorDataSource =
        {
            new object[] { new ComplexNumber(20,0), new ComplexNumber(10,-10), new ComplexNumber(1,1)},
            new object[] { new ComplexNumber(0,1), new ComplexNumber(1,0), new ComplexNumber(0,1)},
            new object[] { new ComplexNumber(40,40), new ComplexNumber (10,-10), new ComplexNumber(0,4) }
        };

        [Test, TestCaseSource("positiveDivideOperatorDataSource")]
        public void TestDivideOperatorPorisive(ComplexNumber left, ComplexNumber right,ComplexNumber expected)
        {
            Assert.AreEqual(left / right, expected);
        }



       private static object[] negativeDivideOperatorDataSource =
        {
            new object[] { new ComplexNumber(double.NaN,0), new ComplexNumber(0, 0)},
            new object[] { new ComplexNumber(50, -7), new ComplexNumber(0,0)},
            new object[] { new ComplexNumber(0,1), new ComplexNumber (1,double.PositiveInfinity)}
        };

        [Test, TestCaseSource("negativeDivideOperatorDataSource")]
        
        public void TestDivideOperatorNegative(ComplexNumber left, ComplexNumber right)
        {
            Exception ex = 
            Assert.That<ArgumentException>();
           
        }
        
    }
}
