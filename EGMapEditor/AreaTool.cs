using System.Collections.Generic;

namespace EGMapEditor
{
    class AreaTool : ITools
    {
        public ToolType ToolType { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public List<KeyValuePair<int, int>> Use()
        {
            List<KeyValuePair<int, int>> drawArea = new List<KeyValuePair<int, int>>();
            for (int y = -(Height / 2); y < Height / 2; y++)
            {
                for (int x = -(Width / 2); x < Width / 2; x++)
                {
                    drawArea.Add(new KeyValuePair<int, int>(x, y));
                }
            }
            return drawArea;
        }
    }
}
