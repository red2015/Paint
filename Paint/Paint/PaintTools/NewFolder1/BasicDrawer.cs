using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1.PaintTools.NewFolder1
{
    class BasicDrawer
    {
        public void Draw(PictureBox pictureBox, Point startPoint, Point temporaryPoint, Pen pen)
        {
            using (Graphics g = Graphics.FromImage(pictureBox.Image))
            {
                g.DrawLine(pen, startPoint, temporaryPoint);
            }
            pictureBox.Invalidate();
        }
    }
}
