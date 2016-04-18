using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EGMapEditor
{
    interface Tools
    {
        ToolType ToolType { get; set; }
        List<KeyValuePair<int, int>> Use();
    }
}
