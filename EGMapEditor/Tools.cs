using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EGMapEditor
{
    class Tools
    {
        public virtual List<KeyValuePair<int, int>> Use()
        {
            return new List<KeyValuePair<int, int>>() { new KeyValuePair<int, int>(0, 0) };
        }
    }
}
