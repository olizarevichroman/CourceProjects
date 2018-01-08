using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using ToXmlConverter;

namespace NUnitTests
{
    [TestFixture]
    public class ToCarStructsConverterTests
    {

        private static object[] dataSource = {
            new object[] {"Cars { car { Model:BMW Type:Sedan}, car { Model:Opel Type:Sedan} }",
                new Dictionary<string,List<CarStruct>>()
                {
                    ["Cars"] = new List<CarStruct>
                    { new CarStruct("BMW","Sedan"),new CarStruct("Opel", "Sedan") }
                }

            },
            new object[] {"Cars { car { Model:Audi Type:Sedan}}",
                new Dictionary<string,List<CarStruct>>()
                {
                    ["Cars"] = new List<CarStruct>
                    { new CarStruct("Audi","Sedan")}
                }

            },
            new object[] {"Cars { car { Model:Citrien Type:SUV}, car { Model:BMW Type:Sedan}, car { Model:Opel Type:Sedan} }",
                new Dictionary<string,List<CarStruct>>()
                {
                    ["Cars"] = new List<CarStruct>
                    {new CarStruct("Citroen","SUV"),
                     new CarStruct("BMW","Sedan"),
                    new CarStruct("Opel", "Sedan") }
                }

            }
        };

        [Test, TestCaseSource("dataSource")]
        public void TestConvertData(string textData, Dictionary<string,List<CarStruct>> convertedData)
        {
            ToCarStructsConverter converter = new ToCarStructsConverter(textData);
            CollectionAssert.AreEqual(converter.ConvertData(), convertedData);
        }

    }
}