using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApplication1.PaintTools.Shapes.DrawingStrategy
{
    class DrawerLine : IDrawerShape
    {
        public void Draw(ref PictureBox pictureBox, Point startPoint, Point temporaryPoint, Pen pen)
        {
            using (Graphics g = Graphics.FromImage(pictureBox.Image))
            {
                g.DrawLine(pen, startPoint, temporaryPoint);
            }
        }
    }
}
