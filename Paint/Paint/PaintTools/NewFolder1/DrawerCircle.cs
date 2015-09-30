using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApplication1.PaintTools.NewFolder1
{
    class DrawerCircle
    {
        public void Draw(PictureBox pictureBox, Point startPoint, Point temporaryPoint, Pen pen)
        {
            using (Graphics g = Graphics.FromImage(pictureBox.Image))
            {
                Size size = new Size(temporaryPoint.X - startPoint.X, temporaryPoint.Y - startPoint.Y);
                Rectangle rectangle = new Rectangle(startPoint, size);
                g.DrawEllipse(pen, rectangle);
            }
        }
    }
}
