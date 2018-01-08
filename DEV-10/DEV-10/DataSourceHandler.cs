using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace DEV_10
{
    interface DataSourceHandler
    {
         IEnumerable<string> GetAllLines();
    }
}
