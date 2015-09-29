using System;
using WindowsFormsApplication1.PaintTools.Shapes.DrawingStrategy;
using PaintApplication.PaintTools;

namespace WindowsFormsApplication1.PaintTools.Shapes
{
    internal class DrawerFactory
    {
        public static IDrawerShape CreateDrawer(PaintOperation paintOperation)
        {
            switch (paintOperation)
            {
                case PaintOperation.BasicDraw:
                    return new BasicDrawer();
                case PaintOperation.DrawLine:
                    return new DrawerLine();
                case PaintOperation.DrawRectangle:
                    return new DrawerRectangle();
                case PaintOperation.DrawCircle:
                    return new DrawerElips();
                default:
                    throw new ArgumentOutOfRangeException("paintOperation", paintOperation, null);
            }
            return null;
        }
    }
}