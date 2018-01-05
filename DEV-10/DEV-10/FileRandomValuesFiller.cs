using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DEV_10
{
    class FileRandomValuesFiller
    {
        FileInfo filledFile;
        public FileRandomValuesFiller(string filePath)
        {
            filledFile = new FileInfo(filePath);
        }

        public void FillFile(int arraysAmount, int maxElemetsAmount)
        {
            using ( StreamWriter writer = filledFile.CreateText())
            {             
                Random random = new Random(100);
                for ( int i = 0; i < arraysAmount; i++)
                {
                    double value = (double)random.Next(300) / 5;
                    writer.Write(value);
                    for ( int j = random.Next(maxElemetsAmount); j > 0; j--)
                    {
                        writer.Write(" ");
                        value = (double)random.Next(300) / 6;
                        writer.Write(value);
                    }
                    writer.WriteLine();
                }
            }
        }
    }
}
