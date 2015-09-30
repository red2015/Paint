using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1.PaintTools.NewFolder1
{
    class BasicDrawer : IDrawer
    {
        private Point _startPoint;

        public BasicDrawer(Point startPoint)
        {
            _startPoint = startPoint;
        }

        public void Draw(PictureBox pictureBox, Point temporaryPoint, Pen pen)
        {
            using (Graphics g = Graphics.FromImage(pictureBox.Image))
            {
                g.DrawLine(pen, _startPoint, temporaryPoint);
            }
            _startPoint = temporaryPoint;
            pictureBox.Invalidate();
        }
    }
}
