using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ToXmlConverter
{
    class FileHandler
    {
        FileInfo textFile;

        public FileHandler(string path)
        {
            textFile = new FileInfo(path);
            if (!textFile.Exists)
            {
                textFile.Create();
            }
        }

        public string ReadData()
        {
            StreamReader reader;
            using ( reader = textFile.OpenText())
            {
                return reader.ReadToEnd();
            }
        }

        public void WriteData(string data)
        {
            StreamWriter writer;
            using ( writer = textFile.CreateText())
            {
                writer.WriteLine(data);
            }
        }
    }
}
