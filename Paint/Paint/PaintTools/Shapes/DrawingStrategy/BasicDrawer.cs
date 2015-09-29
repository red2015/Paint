using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1.PaintTools.Shapes.DrawingStrategy
{
    class BasicDrawer:IDrawerShape
    {

        public void Draw(ref PictureBox pictureBox, Point startPoint, Point temporaryPoint, Pen pen)
        {
            //pictureBox.Image = (Image)pictureBox.Image;
            using (Graphics g = Graphics.FromImage(pictureBox.Image))
            {
                Brush brush = new SolidBrush(pen.Color);
                g.FillEllipse(brush, temporaryPoint.X, temporaryPoint.Y, 10, 10);
            }
        }
    }
}
