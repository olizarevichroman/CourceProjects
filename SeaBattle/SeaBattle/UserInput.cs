using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBattle
{
    class UserInput : UserInputInterface
    {
        public string SetCoordinates()
        {
            Console.WriteLine("Enter shooting coordinates");
            return Console.ReadLine();
        }
    }
}
