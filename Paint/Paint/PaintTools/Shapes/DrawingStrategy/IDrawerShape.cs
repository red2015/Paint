using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApplication1.PaintTools.Shapes.DrawingStrategy
{
    interface IDrawerShape
    {
        void Draw(ref PictureBox pictureBox, Point startPoint, Point temporaryPoint, Pen pen);
    }
}
