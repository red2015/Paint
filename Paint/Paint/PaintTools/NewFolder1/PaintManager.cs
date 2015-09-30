using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using WindowsFormsApplication1.PaintTools.NewFolder1;
using PaintApplication;
using PaintApplication.PaintTools;

namespace WindowsFormsApplication1.PaintTools.Shapes.DrawingStrategy
{
    internal class PaintManager
    {
        private Point _startPoint;
        private Image _actualImage;
        private PaintOperation _paintOperation;
        private Pen _pen;
        private Caretaker _history;
        private Originator _orginator;

    #region Constructors

        public PaintManager()
        {
            _paintOperation = PaintOperation.BasicDraw;
            _pen = new Pen(Color.Black);
            _history = new Caretaker();
        }

    #endregion

    #region Properties
        public Point StartPoint
        {
            get { return _startPoint; }
            set { _startPoint = value; }
        }

        public Image ActualImage
        {
            get { return _actualImage; }
            set { _actualImage = value; }
        }

        public PaintOperation Operation
        {
            get { return _paintOperation; }
            set { _paintOperation = value; }
        }

        public Pen Pen
        {
            get { return _pen; }
            set { _pen = value; }
        }
    #endregion

        public void UndoOperation(PictureBox pictureBox)
        {
            _history.RestoreState(_orginator);
            pictureBox.Size = new Size(_orginator.GetWidth(), _orginator.GetHeight());
            pictureBox.Image = (Bitmap)_orginator.GetBitmap().Clone();
        }

        public void TakeSnapshot(PictureBox pictureBox)
        {
            Bitmap bit = new Bitmap(pictureBox.Image);
            _orginator = new Originator(bit, pictureBox.Height, pictureBox.Width);
            _history.SaveState(_orginator);
        }

        public void Draw(PictureBox pictureBox, Point temporartPoint)
        {
            switch (_paintOperation)
            {
                case PaintOperation.BasicDraw:
                    BasicDraw(pictureBox, temporartPoint);
                    break;
                case PaintOperation.DrawLine:
                    DrawLine(pictureBox, temporartPoint);
                    break;
                case PaintOperation.DrawRectangle:
                    DrawRectangle(pictureBox, temporartPoint);
                    break;
                case PaintOperation.DrawCircle:
                    DrawCircle(pictureBox, temporartPoint);
                    break;
                case PaintOperation.Rubber:
                    Rubberize(pictureBox, temporartPoint);
                    break;
            }
        }

        public void FloodFill(PictureBox pictureBox, Point temporaryPoint)
        {
            if (_paintOperation == PaintOperation.FloodFill)
            {
                Bitmap pictureBitmap = (Bitmap) pictureBox.Image.Clone();
                FloodFiller floodFiller = new FloodFiller();
                pictureBox.Image = floodFiller.Fill(pictureBitmap, temporaryPoint, _pen.Color);
            }
        }
        #region privateDrawingMethod

        private void DrawCircle(PictureBox pictureBox, Point temporartPoint)
        {
            pictureBox.Image = (Image) _actualImage.Clone();
            DrawerCircle drawerCircle = new DrawerCircle();
            drawerCircle.Draw(pictureBox, _startPoint, temporartPoint, _pen);

        }

        private void BasicDraw(PictureBox pictureBox, Point temporartPoint)
        {
            BasicDrawer basicDrawer = new BasicDrawer();
            basicDrawer.Draw(pictureBox, _startPoint, temporartPoint, _pen);
            _startPoint = temporartPoint;
        }

        private void DrawRectangle(PictureBox pictureBox, Point temporaryPoint)
        {
            pictureBox.Image = (Image) _actualImage.Clone();
            DrawerRectangle drawerRectangle = new DrawerRectangle();
            drawerRectangle.Draw(pictureBox, _startPoint, temporaryPoint, _pen);
        }

        private void DrawLine(PictureBox pictureBox, Point temporaryPoint)
        {
            pictureBox.Image = (Image) _actualImage.Clone();
            DrawerLine drawerLine = new DrawerLine();
            drawerLine.Draw(pictureBox, _startPoint, temporaryPoint, _pen);
        }

        private void Rubberize(PictureBox pictureBox, Point temporaryPoint)
        {
            Rubber rubber = new Rubber();
            rubber.Draw(pictureBox, _startPoint, temporaryPoint);
            _startPoint = temporaryPoint;

        }

        #endregion

    }
}
