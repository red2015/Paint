using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PaintApplication.PaintTools
{
    class DrawLineManager
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

        public void DrawLine(PictureBox pictureBox, Point temporaryPoint, Pen pen)
        {
            pictureBox.Image = (Image)_actualImage.Clone();
            using (Graphics g = Graphics.FromImage(pictureBox.Image))
            {
                g.DrawLine(pen, _startPoint, temporaryPoint);
            }
        }

    }
}
