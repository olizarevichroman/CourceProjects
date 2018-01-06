using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToXmlConverter
{
    public struct CarStruct
    {
        string Model;
        string Type;
        public CarStruct(string model, string type)
        {
            Model = model;
            Type = type;
        }
    }
}
