using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
namespace DEV_10
{
    class Program
    {
        static void Main(string[] args)
        {
            const string filePath = "DoubleArrays.txt";
            FileRandomValuesFiller filler = new FileRandomValuesFiller(filePath);
            int arraysAmount, maxElementsAmount;
            Console.Write("Enter arrays amount: ");
            try
            {
                arraysAmount = int.Parse(Console.ReadLine());
                Console.Write("Enter maximal elements in arrays amount: ");
                maxElementsAmount = int.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Entered values are not valid");
                return;
            }
            filler.FillFile(arraysAmount, maxElementsAmount);
            FileHandler handler = new FileHandler(filePath);
            IEnumerable <string> allLines = handler.GetAllLines();
            ToDoubleArrayConverter converter = new ToDoubleArrayConverter();
            double[][] array;
            try
            {
                array = converter.GetDoubleArray(allLines);
            }
            catch (FormatException)
            {
                Console.WriteLine("Data in source  does not meet the requirements");
                return;
            }
            RepeatedValuesFinder finder = new RepeatedValuesFinder();
            double[] decisions = finder.GetRepeatedElement(array);
            Console.Write("Values repeated more than 2 times: ");
            foreach (double value in decisions)
            {
                Console.Write("{0,6:F2}", value);
            }
            Console.WriteLine();
            Process.Start(filePath);
        }
    }
}
