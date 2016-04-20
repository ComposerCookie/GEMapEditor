using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EGMapEditor
{
    class AreaTool : Tools
    {
        public ToolType ToolType { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public List<KeyValuePair<int, int>> Use()
        {
            throw new NotImplementedException();
        }
    }
}
