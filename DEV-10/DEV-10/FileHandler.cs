using System.IO;
using System.Collections.Generic;

namespace DEV_10
{
    class FileHandler
    {
        FileInfo doubleArrays;

        public FileHandler(string filePath)
        {
            doubleArrays = new FileInfo(filePath);
        }

        public IEnumerable<string> GetAllLines()
        {
            List<string> linesArray = new List<string>(); 
              
            using ( StreamReader reader = doubleArrays.OpenText() )
            {
                while ( !reader.EndOfStream )
                {
                    linesArray.Add(reader.ReadLine());
                }                           
            }
            return linesArray;
        }
    }
}
