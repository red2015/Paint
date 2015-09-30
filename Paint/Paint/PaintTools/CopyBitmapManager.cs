using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApplication1.PaintTools
{
    class CopyBitmapManager
    {
        public void CopyPictureBitmap(PictureBox pictureBox)
        {
            Bitmap oldBitmap = (Bitmap)pictureBox.Image;
            Rectangle rec = new Rectangle(0, 0, oldBitmap.Width, oldBitmap.Height);
            Bitmap newBitmap = Copy(oldBitmap, rec, pictureBox);
            pictureBox.Image.Dispose();
            pictureBox.Image = new Bitmap(newBitmap, newBitmap.Width, newBitmap.Height);
        }

        private Bitmap Copy(Bitmap sourceBitmap, Rectangle section, PictureBox pictureBox)
        {
            Bitmap bmp = new Bitmap(pictureBox.Width, pictureBox.Height);
            Graphics graphics = Graphics.FromImage(bmp);

            graphics.FillRectangle(Brushes.White, 0, 0, pictureBox.Width, pictureBox.Height);
            graphics.DrawImage(sourceBitmap, 0, 0, section, GraphicsUnit.Pixel);
            graphics.Dispose();

            return bmp;
        }
    }
}
