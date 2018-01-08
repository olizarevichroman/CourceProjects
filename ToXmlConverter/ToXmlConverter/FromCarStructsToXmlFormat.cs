using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToXmlConverter
{
    class FromCarStructsToXmlFormat
    {
        const string declarationString = @"<?xml version=""1.0"" encoding=""utf-8""?>";
        Dictionary<string, List<CarStruct>> intermediateData;

        public FromCarStructsToXmlFormat(Dictionary<string,List<CarStruct>> intermediateData)
        {
            this.intermediateData = intermediateData;
        }

        public string ConvertToXmlFormat()
        {
            StringBuilder formatedString = new StringBuilder(declarationString);
            formatedString.AppendLine();

        }

    }
}
