using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace DEV_10
{
    public class ToDoubleArrayConverter
    {
        private string[][] DivideNumbersIntoArrays( IEnumerable<string> allLinesArray )
        {
            int linesAmount = allLinesArray.Count();
            string[][] numbersArrays = new string[linesAmount][];
            int numberArraysIndex = 0;
            foreach (string line in allLinesArray)
            {
                numbersArrays[numberArraysIndex++] = line.Split();
            }
            return numbersArrays;
        }

        public double[][] GetDoubleArray( IEnumerable<string> allLinesArray )
        {
            string[][] numbersArray = DivideNumbersIntoArrays(allLinesArray);
            double[][] allNumbers = new double[numbersArray.GetLength(0)][];

            for ( int i = 0; i < numbersArray.GetLength(0) ; i++)
            {            
                allNumbers[i] = new double[numbersArray[i].Length];
                for ( int j = 0; j < numbersArray[i].Length; j++)
                {
                    allNumbers[i][j] = double.Parse(numbersArray[i][j]);
                }
            }
            return allNumbers;
        }
    }
}
