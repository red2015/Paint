﻿using System.Drawing;
using System.Windows.Forms;
using WindowsFormsApplication1.Memento;
using WindowsFormsApplication1.PaintTools.SaveAndLoad;
using WindowsFormsApplication1.PaintTools.Strategy_Draw;
using WindowsFormsApplication1.PaintTools.Strategy_Shapes_Draw;
using PaintApplication;

namespace WindowsFormsApplication1.PaintTools
{
    internal class PaintManager
    {
        private PaintOperation _paintOperation;
        private Pen _pen;
        private Caretaker _history;
        private Originator _orginator;
        private IShapesDrawer _shapesDrawer;
        private IDrawer _drawer;

        #region Constructors

        public PaintManager()
        {
            _paintOperation = PaintOperation.BasicDraw;
            _pen = new Pen(Color.Black);
            _history = new Caretaker();
        }

        #endregion

        #region Properties

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

        #region RotationsMethods

        public void RotatePicture90DegreesRight(PictureBox pictureBox)
        {
            TakeSnapshot(pictureBox);
            RotateManager manager = new RotateManager();
            Image oldImage = pictureBox.Image;
            pictureBox.Size = new Size(pictureBox.Height, pictureBox.Width);
            pictureBox.Image = manager.Rotate90DegreesRight(oldImage);
        }

        public void RotatePicture90DegreesLeft(PictureBox pictureBox)
        {
            TakeSnapshot(pictureBox);
            RotateManager manager = new RotateManager();
            Image oldImage = pictureBox.Image;
            pictureBox.Size = new Size(pictureBox.Height, pictureBox.Width);
            pictureBox.Image = manager.Rotate90DegreesLeft(oldImage);
        }

        public void RotatePicture180Degrees(PictureBox pictureBox)
        {
            TakeSnapshot(pictureBox);
            RotateManager manager = new RotateManager();
            Image oldImage = pictureBox.Image;
            pictureBox.Image = manager.Rotate180Degrees(oldImage);
        }

        public void FlipPictureVertical(PictureBox pictureBox)
        {
            TakeSnapshot(pictureBox);
            RotateManager manager = new RotateManager();
            Image oldImage = pictureBox.Image;
            pictureBox.Image = manager.FlipVertical(oldImage);
        }

        public void FlipPictureHorizontal(PictureBox pictureBox)
        {
            TakeSnapshot(pictureBox);
            RotateManager manager = new RotateManager();
            Image oldImage = pictureBox.Image;
            pictureBox.Image = manager.FlipHorizontal(oldImage);
        }

        #endregion

        #region SaveAndLoadMethods

        public void SavePictureToFile(PictureBox pictureBox)
        {
            SaveManager saveManager = new SaveManager();
            saveManager.SavePictureToBmpFile(pictureBox);
        }

        public void LoadBmpFileToPicture(PictureBox pictureBox)
        {
            LoadManager loadManager = new LoadManager();
            Bitmap bitmap = loadManager.LoadBmpPictureFile();
            pictureBox.Size = new Size(bitmap.Width, bitmap.Height);
            pictureBox.Image = bitmap;
        }

        #endregion

        #region DrawingMethod

        public void CreateDrawer(Point startPoint)
        {
            switch (_paintOperation)
            {
                case PaintOperation.BasicDraw:
                    _drawer = new BasicDrawer(startPoint);
                    break;
                case PaintOperation.DrawLine:
                    _shapesDrawer = new ShapesDrawerLine(startPoint);
                    break;
                case PaintOperation.DrawRectangle:
                    _shapesDrawer = new ShapesDrawerRectangle(startPoint);
                    break;
                case PaintOperation.DrawCircle:
                    _shapesDrawer = new ShapesDrawerCircle(startPoint);
                    break;
                case PaintOperation.Rubber:
                    _drawer = new Rubber(startPoint);
                    break;
                default:
                    _shapesDrawer = new NullObject();
                    return;
            }
        }

        public void MoveForwad(PictureBox pictureBox, Point temporaryPoint)
        {
            if (_paintOperation == PaintOperation.BasicDraw || _paintOperation == PaintOperation.Rubber)
                _drawer.Draw(pictureBox, temporaryPoint, _pen);
            else
            {
                _shapesDrawer.MoveForward(temporaryPoint);
            }
        }

        public void RefreshDrawingShapes(PaintEventArgs e)
        {
            if (_paintOperation != PaintOperation.BasicDraw && _paintOperation != PaintOperation.Rubber)
                _shapesDrawer.Refresh(e, _pen);
        }

        public void DrawShapes(PictureBox pictureBox)
        {
            if (_paintOperation != PaintOperation.BasicDraw && _paintOperation != PaintOperation.Rubber)
                _shapesDrawer.Draw(pictureBox, _pen);
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

        #endregion

        #region OtherMethods

        public void CopyPictureBitmap(PictureBox pictureBox)
        {
            CopyBitmapManager copyBitmapManager = new CopyBitmapManager();
            copyBitmapManager.CopyPictureBitmap(pictureBox);
        }

        public void UndoOperation(PictureBox pictureBox)
        {
            _history.RestoreState(_orginator);
            pictureBox.Size = new Size(_orginator.GetWidth(), _orginator.GetHeight());
            pictureBox.Image = (Bitmap) _orginator.GetBitmap().Clone();
        }

        public void TakeSnapshot(PictureBox pictureBox)
        {
            Bitmap bit = new Bitmap(pictureBox.Image);
            _orginator = new Originator(bit, pictureBox.Height, pictureBox.Width);
            _history.SaveState(_orginator);
        }

        #endregion

    }
}
