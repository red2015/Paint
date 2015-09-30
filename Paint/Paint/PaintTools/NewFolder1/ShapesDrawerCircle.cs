using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApplication1.PaintTools.NewFolder1
{
    class ShapesDrawerCircle : IShapesDrawer
    {
        private Point _startPoint;
        private Rectangle _rectangle;

        public ShapesDrawerCircle(Point startPoint)
        {
            _startPoint = startPoint;
            _rectangle = new Rectangle();
        }


        public void Draw(PictureBox pictureBox, Pen pen)
        {
            using (Graphics g = Graphics.FromImage(pictureBox.Image))
            {
                g.DrawEllipse(pen, _rectangle);
            }
            pictureBox.Invalidate();
        }

        public void MoveForward(Point temporaryPoint)
        {
            _rectangle.Location = new Point(Math.Min(_startPoint.X, temporaryPoint.X), Math.Min(_startPoint.Y, temporaryPoint.Y));
            _rectangle.Size = new Size(Math.Abs(_startPoint.X - temporaryPoint.X), Math.Abs(_startPoint.Y - temporaryPoint.Y));
        }

        public void Refresh(PaintEventArgs e, Pen pen)
        {
            if (_rectangle.Width > 0 && _rectangle.Height > 0)
            {
                e.Graphics.DrawEllipse(pen, _rectangle);
            }
        }
    }
}
