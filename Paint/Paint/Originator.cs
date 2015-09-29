using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaintApplication
{
    class Originator
    {
        private Bitmap _bitmap;
        private int _height;
        private int _width;

        public Originator(Bitmap bitmap, int height, int width)
        {
            _bitmap = bitmap;
            _height = height;
            _width = width;
        }

        public Memento CreateMemento()
        {
            return new Memento(_bitmap, _height, _width);
        }

        public void SetMemento(Memento memento)
        {
            _bitmap = new Bitmap(memento.GetBitmap());
            _height = memento.GetHeight();
            _width = memento.GetWidth();
        }

        public int GetWidth()
        {
            return _width;
        }

        public int GetHeight()
        {
            return _height;
        }

        public Bitmap GetBitmap()
        {
            return _bitmap;
        }

    }
}
