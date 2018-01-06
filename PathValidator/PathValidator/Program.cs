using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter path: ");
            string path = Console.ReadLine();
            PathValidator validator = new PathValidator(path);
            if (validator.IsPathValid())
            {
                Console.WriteLine("Path is valid");
            }
            else Console.WriteLine("Path is not valid");
        }
    }
}
