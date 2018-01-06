using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToXmlConverter
{
    /// <summary>
    /// Class get text data to constructor and have a method,
    /// which convert this data to the required format
    /// (dictionary with root element and list of CarStruct)
    /// </summary>
    public class ToCarStructsConverter
    {
        string data;

        public ToCarStructsConverter(string data)
        {
            this.data = data;
        }

        /// <summary>
        /// method convert input text data to dictionary with 1 length
        /// </summary>
        /// <returns> dictionary, where
        /// key is a name of root element , second parametr is a list, which contains
        /// child element corresponding to the CarStruct</returns>
        public Dictionary<string, List<CarStruct>> ConvertData()
        {
            Dictionary<string, List<CarStruct>> convertedData = new Dictionary<string, List<CarStruct>>();
            return convertedData;

        }
    }
}
