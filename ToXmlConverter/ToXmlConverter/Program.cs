using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ToXmlConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            FileHandler xmlFile = new FileHandler("xmlFile.xml");
            FileHandler textFile = new FileHandler("File.txt");
            string starterData = textFile.ReadData();
            ToCarStructsConverter toCarConverter = new ToCarStructsConverter(starterData);
            FromCarStructsToXmlFormat toXmlFormatter = new FromCarStructsToXmlFormat(toCarConverter.ConvertData());
            xmlFile.WriteData(toXmlFormatter.ConvertToXmlFormat());           
        }
    }
}
