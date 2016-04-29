using System;
using System.Collections.Generic;
using System.Linq;

namespace EGMapEditor
{
    class UndoRedo<T>
    {
        private Stack<T> _undoStack;
        private Stack<T> _redoStack;


        public T CurrentItem;
        //public Event UndoHappened As EventHandler(Of UndoRedoEventArgs)
        //public Event RedoHappened As EventHandler(Of UndoRedoEventArgs)

        public event EventHandler<UndoRedoEventArgs> UndoHappened;
        public event EventHandler<UndoRedoEventArgs> RedoHappened;


        public void New()
        {
            _undoStack = new Stack<T>();
            _redoStack = new Stack<T>();
        }


        public void Clear()
        {
            _undoStack.Clear();
            _redoStack.Clear();
            CurrentItem = default(T);
        }

        public void AddItem(T item)
        {
            CurrentItem = item;
            _undoStack.Push(CurrentItem);
            _redoStack.Clear();
        }

        public void AddToUndo(T item)
        {
            _undoStack.Push(item);
        }

        public void AddToRedo(T item)
        {
            _redoStack.Push(item);
        }

        public void Undo() {
            if (!CanUndo())
                return;

            CurrentItem = _undoStack.Pop();
            UndoHappened?.Invoke(this, new UndoRedoEventArgs(CurrentItem));
        }


        public void Redo() {
            if (!CanRedo())
                return;

            CurrentItem = _redoStack.Pop();
            RedoHappened?.Invoke(this, new UndoRedoEventArgs(CurrentItem));
        }


        public bool CanUndo()
        {
            return _undoStack.Count > 0;
        }

        public bool CanRedo()
        {
            return _redoStack.Count > 0;
        }

        public List<T> UndoItems()
        {
            return _undoStack.ToList();
        }

        public List<T> RedoItems()
        {
            return _redoStack.ToList();
        }
    }
}
