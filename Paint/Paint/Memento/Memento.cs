using System.Drawing;

namespace WindowsFormsApplication1.Memento
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
            return (Bitmap) _bitmap.Clone();
        }

    }
}
