using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApplication1.PaintTools.Strategy_Draw
{
    class Rubber : IDrawer
    {
        private Point _startPoint;

        public Rubber(Point startPoint)
        {
            _startPoint = startPoint;
        }

        public void Draw(PictureBox pictureBox, Point temporaryPoint, Pen pen)
        {
            using (Graphics g = Graphics.FromImage(pictureBox.Image))
            {
                Pen newPen = new Pen(Color.White, 10);
                g.DrawLine(newPen, _startPoint, temporaryPoint);
                Rectangle rectangle = new Rectangle(temporaryPoint.X,temporaryPoint.Y, 10, 10);
                g.DrawRectangle(newPen, rectangle);
            }
            _startPoint = temporaryPoint;
            pictureBox.Invalidate();
        }


    }
}
