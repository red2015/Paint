using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApplication1.PaintTools.Shapes;
using WindowsFormsApplication1.PaintTools.Shapes.DrawingStrategy;

namespace PaintApplication.PaintTools.Shapes
{
    class ShapesManager
    {
        private Point _startPoint ;
        private Image _actualImage;
        private IDrawerShape _drawerShape;

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

        public void Draw(PictureBox pictureBox, Point temporaryPoint, Pen pen, PaintOperation paintOperation)
        {
            _drawerShape = DrawerFactory.CreateDrawer(paintOperation);
            pictureBox.Image = (Image) _actualImage.Clone();
           _drawerShape.Draw(ref pictureBox, _startPoint, temporaryPoint, pen);
        }
    }
}
