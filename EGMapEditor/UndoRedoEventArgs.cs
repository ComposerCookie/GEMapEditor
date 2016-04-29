using System;

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
