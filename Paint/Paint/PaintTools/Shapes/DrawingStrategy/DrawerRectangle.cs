using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApplication1.PaintTools.Shapes.DrawingStrategy
{
    class DrawerRectangle :IDrawerShape
    {
        public void Draw(ref PictureBox pictureBox, Point startPoint, Point temporaryPoint, Pen pen)
        {
            using (Graphics g = Graphics.FromImage(pictureBox.Image))
            {
                g.DrawRectangle(pen,startPoint.X, startPoint.Y, temporaryPoint.X-startPoint.X, temporaryPoint.Y-startPoint.Y);
            }
        }
    }
}
