using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApplication1.PaintTools.Strategy_Draw
{
    interface IDrawer
    {
        void Draw(PictureBox pictureBox, Point temporaryPoint, Pen pen);
    }

}
