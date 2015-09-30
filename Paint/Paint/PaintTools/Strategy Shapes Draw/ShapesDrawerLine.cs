using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApplication1.PaintTools.Strategy_Shapes_Draw
{
    class ShapesDrawerLine : IShapesDrawer
    {
        private Point _startPoint;
        private Point _endPoint;

        public ShapesDrawerLine(Point startPoint)
        {
            _startPoint = startPoint;
        }

        public void Draw(PictureBox pictureBox, Pen pen)
        {
            using (Graphics g = Graphics.FromImage(pictureBox.Image))
            {
                g.DrawLine(pen,_startPoint, _endPoint);
            }
            pictureBox.Invalidate();
        }

        public void MoveForward(Point temporaryPoint)
        {
            _endPoint = temporaryPoint;
        }

        public void Refresh(PaintEventArgs e, Pen pen)
        {
            e.Graphics.DrawLine(pen, _startPoint, _endPoint);
        }
    }
}
