using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EGMapEditor
{
    class UndoRedoEventArgs : EventArgs
    {
        public object Item { get; set; }

        public UndoRedoEventArgs(object item)
        {
            Item = item;
        }
    }
}
