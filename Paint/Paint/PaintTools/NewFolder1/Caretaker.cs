using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaintApplication
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
