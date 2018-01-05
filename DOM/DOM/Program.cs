using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOM
{
    class Program
    {
        static void Main(string[] args)
        {
            FileHandler handler = new FileHandler("XmlFile.xml");
            string data = handler.ReadData();
            XmlDOM parser = new XmlDOM();
            parser.ParseDocument(data);
        }
    }
}
