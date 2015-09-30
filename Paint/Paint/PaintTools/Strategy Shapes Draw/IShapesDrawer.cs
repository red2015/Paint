using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApplication1.PaintTools.Strategy_Shapes_Draw
{
    interface IShapesDrawer
    {
        void Draw(PictureBox pictureBox, Pen pen);
        void MoveForward(Point temporaryPoint);
        void Refresh(PaintEventArgs e, Pen pen);
    }
}
