using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1.PaintTools.NewFolder1
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
