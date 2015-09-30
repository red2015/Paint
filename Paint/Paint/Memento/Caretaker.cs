using System.Collections.Generic;

namespace WindowsFormsApplication1.Memento
{
    class Caretaker
    {
        private Stack<Memento> _mementos = new Stack<Memento>();
        public void SaveState(Originator orig)
        {
            _mementos.Push(orig.CreateMemento());
        }

        public void RestoreState(Originator orig)
        {
            if(_mementos.Count > 1)
                orig.SetMemento(_mementos.Pop());
        }
    }
}
