using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApplication1.PaintTools.SaveAndLoad
{
    class LoadManager
    {
        public Bitmap LoadBmpPictureFile()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Open Image";
            openFileDialog.Filter = "BMP files (*.bmp)|*.bmp";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                return new Bitmap(openFileDialog.FileName);
            }
            return new Bitmap(800, 600);
        }

    }
}
