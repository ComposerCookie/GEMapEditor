using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EGMapEditor
{
    class UndoRedo<T>
    {
        private Stack<T> UndoStack;
        private Stack<T> RedoStack;


        public T CurrentItem;
        //public Event UndoHappened As EventHandler(Of UndoRedoEventArgs)
        //public Event RedoHappened As EventHandler(Of UndoRedoEventArgs)

        public Event UndoHappened As EventHandler(Of UndoRedoEventArgs)
        public Event RedoHappened As EventHandler(Of UndoRedoEventArgs)


        public void New() {
            UndoStack = New Stack(Of T)
            RedoStack = New Stack(Of T)
        }


        public void Clear() {
            UndoStack.Clear()
            RedoStack.Clear()
            CurrentItem = Nothing
        }

        public void AddItem(ByVal item As T)
            If CurrentItem IsNot Nothing Then UndoStack.Push(CurrentItem)
            CurrentItem = item
            RedoStack.Clear()
        }


        public void Undo() {
            RedoStack.Push(CurrentItem)
            CurrentItem = UndoStack.Pop()
            RaiseEvent UndoHappened(Me, New UndoRedoEventArgs(CurrentItem))
        }


        public void Redo() {
            UndoStack.Push(CurrentItem)
            CurrentItem = RedoStack.Pop
            RaiseEvent RedoHappened(Me, New UndoRedoEventArgs(CurrentItem))
        }


        public Function CanUndo() { As Boolean
            Return UndoStack.Count > 0
        End Function


        public Function CanRedo() { As Boolean
            Return RedoStack.Count > 0
        End Function


        public Function UndoItems() { As List(Of T)
            Return UndoStack.ToList
        End Function


        public Function RedoItems() { As List(Of T)
            Return RedoStack.ToList
        End Function
    }
}
