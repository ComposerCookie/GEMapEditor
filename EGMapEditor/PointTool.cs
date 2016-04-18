using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EGMapEditor
{
    class PointTool : Tools
    {
        public ToolType ToolType { get; set; }
        public int Size { get; set; }
        public List<KeyValuePair<int, int>> Use()
        {
            List<KeyValuePair<int, int>> drawArea = new List<KeyValuePair<int, int>>();
            for (int y = -(Size/2); y < Size / 2; y++)
            {
                for (int x = -(Size / 2); x < Size / 2; x++)
                {
                    drawArea.Add(new KeyValuePair<int, int>(x, y));
                }
            }

            return drawArea;
        }
    }
}
