using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
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
            return new Bitmap(100, 50);
        }

    }
}
