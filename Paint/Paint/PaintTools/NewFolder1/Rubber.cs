using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1.PaintTools.NewFolder1
{
    class Rubber
    {
        public void Draw(PictureBox pictureBox, Point startPoint, Point temporaryPoint)
        {
            using (Graphics g = Graphics.FromImage(pictureBox.Image))
            {
                Pen pen = new Pen(Color.White, 10);
                g.DrawLine(pen, startPoint, temporaryPoint);
                Rectangle rectangle = new Rectangle(temporaryPoint.X,temporaryPoint.Y, 10, 10);
                g.DrawRectangle(pen,rectangle );
            }
            pictureBox.Invalidate();
        }
    }
}
