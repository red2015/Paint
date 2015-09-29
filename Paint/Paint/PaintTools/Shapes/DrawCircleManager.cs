using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PaintApplication.PaintTools
{
    class DrawCircleManager
    {

        private Point _startPoint;
        private Image _actualImage;


        public Point GetStartPoint
        {
            get { return _startPoint; }
            set { _startPoint = value; }
        }

        public Image GetActualImage
        {
            get { return _actualImage; }
            set { _actualImage = value; }
        }

        public void DrawCircle(PictureBox pictureBox, Point temporaryPoint, Pen pen)
        {
            pictureBox.Image = (Image)_actualImage.Clone();
            using (Graphics g = Graphics.FromImage(pictureBox.Image))
            {
                Size size = new Size(temporaryPoint.X - _startPoint.X,temporaryPoint.Y-_startPoint.Y);
                Rectangle rectangle = new Rectangle(_startPoint, size);
                g.DrawEllipse(pen, rectangle);
            }
        }
    }
}
