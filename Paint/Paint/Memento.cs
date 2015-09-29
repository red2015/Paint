using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    class Memento
    {
        private Bitmap _bitmap;
        private int _height;
        private int _width;

        public Memento(Bitmap bitmap, int height, int width)
        {
            _bitmap = bitmap;
            _height = height;
            _width = width;
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
            return new Bitmap(_bitmap);
        }

    }
}
