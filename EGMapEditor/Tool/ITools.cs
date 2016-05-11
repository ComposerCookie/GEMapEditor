using System.Collections.Generic;

namespace EGMapEditor
{
    interface ITools
    {
        ToolType ToolType { get; set; }
        List<KeyValuePair<int, int>> Use();
    }
}
