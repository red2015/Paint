using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApplication1.PaintTools.Strategy_Shapes_Draw
{
    class NullObject : IShapesDrawer
    {
        public void Draw(PictureBox pictureBox, Pen pen)
        {
            
        }

        public void MoveForward(Point temporaryPoint)
        {
            
        }

        public void Refresh(PaintEventArgs e, Pen pen)
        {
            
        }
    }
}
