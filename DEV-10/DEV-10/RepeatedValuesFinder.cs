using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEV_10
{
    class RepeatedValuesFinder
    {
      public double[] GetRepeatedElement(double[][] array)
        {
            IEnumerable<double> a = new HashSet<double>();
            
            for ( int i = 0; i < array.GetLength(0); i++)
            {
                for ( int j = i + 1; j < array.GetLength(0); j++)
                {
                    a = a.Union(array[i].Intersect(array[j]));
                }
            }
            return a.ToArray();
        }
    }
}
