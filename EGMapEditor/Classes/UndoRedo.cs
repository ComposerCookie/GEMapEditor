using System;
using System.Collections.Generic;
using System.Linq;

namespace EGMapEditor
{
    class UndoRedo<T>
    {
        private Stack<T> UndoStack;
        private Stack<T> RedoStack;


        public T CurrentItem;
        //public Event UndoHappened As EventHandler(Of UndoRedoEventArgs)
        //public Event RedoHappened As EventHandler(Of UndoRedoEventArgs)

        public event EventHandler<UndoRedoEventArgs> UndoHappened;
        public event EventHandler<UndoRedoEventArgs> RedoHappened;


        public void New()
        {
            UndoStack = new Stack<T>();
            RedoStack = new Stack<T>();
        }


        public void Clear()
        {
            UndoStack.Clear();
            RedoStack.Clear();
            CurrentItem = default(T);
        }

        public void AddItem(T item)
        {
            if (!CurrentItem.Equals(default(T)))
            {
                UndoStack.Push(CurrentItem);
            }
            CurrentItem = item;
            RedoStack.Clear();
        }


        public void Undo() {
            RedoStack.Push(CurrentItem);
            CurrentItem = UndoStack.Pop();
            UndoHappened(this, new UndoRedoEventArgs(CurrentItem));
        }


        public void Redo() {
            UndoStack.Push(CurrentItem);
            CurrentItem = RedoStack.Pop();
            RedoHappened(this, new UndoRedoEventArgs(CurrentItem));
        }


        public bool CanUndo()
        {
            return UndoStack.Count > 0;
        }

        public bool CanRedo()
        {
            return RedoStack.Count > 0;
        }

        public List<T> UndoItems()
        {
            return UndoStack.ToList();
        }

        public List<T> RedoItems()
        {
            return RedoStack.ToList();
        }
    }
}
