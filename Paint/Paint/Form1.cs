using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using WindowsFormsApplication1.PaintTools;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        private PaintManager paintManager;
        private TCResize tcResize;

        public Form1()
        {
            InitializeComponent();
            paintManager = new PaintManager();
            tcResize = new TCResize(pictureBox_canvas);
            tcResize.SizeIsChanging += SetInformationsSizeAboutCanvas;
            tcResize.SizeIsStarChanging += TakeCanvasSnapshot;
            InitializeBitmap();
            SetInformationsSizeAboutCanvas();
        }

    #region SaveAndLoadMethods
            private void saveToolStripMenuItem_Click(object sender, EventArgs e)
            {
                paintManager.SavePictureToFile(pictureBox_canvas);
            }
            private void openToolStripMenuItem_Click(object sender, EventArgs e)
            {
                paintManager.LoadBmpFileToPicture(pictureBox_canvas);
            }

    #endregion

    #region UndoEvent
        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            paintManager.UndoOperation(pictureBox_canvas);
            SetInformationsSizeAboutCanvas();
        }
    #endregion

    #region FlipAndRotateEvents

            private void degreesInRightToolStripMenuItem_Click(object sender, EventArgs e)
            {
                paintManager.RotatePicture90DegreesRight(pictureBox_canvas);
            }

            private void degreesInLeftToolStripMenuItem_Click(object sender, EventArgs e)
            {
                paintManager.RotatePicture90DegreesLeft(pictureBox_canvas);
            }

            private void horizontalToolStripMenuItem_Click(object sender, EventArgs e)
            {
                paintManager.FlipPictureHorizontal(pictureBox_canvas);
            }

            private void verticalToolStripMenuItem_Click(object sender, EventArgs e)
            {
                paintManager.FlipPictureVertical(pictureBox_canvas);
            }

            private void degreesToolStripMenuItem_Click(object sender, EventArgs e)
            {
                paintManager.RotatePicture180Degrees(pictureBox_canvas);
            }

    #endregion

    #region ButtonsEvents

            private void button_pencil_Click(object sender, EventArgs e)
            {
                paintManager.Operation = PaintOperation.BasicDraw;
            }

            private void button_flood_Click(object sender, EventArgs e)
            {
                paintManager.Operation = PaintOperation.FloodFill;
            }

            private void button_setSize_Click(object sender, EventArgs e)
            {
                uint height;
                uint width;
                if (uint.TryParse(textBox_HorizontalPositon.Text, out width) && uint.TryParse(textBox_VerticalPosiotion.Text, out height))
                    pictureBox_canvas.Size = new Size((int)width, (int)height);
                else
                    SetInformationsSizeAboutCanvas();
            }

            private void button_line_Click(object sender, EventArgs e)
            {
                paintManager.Operation = PaintOperation.DrawLine;
            }

            private void button_circle_Click(object sender, EventArgs e)
            {
                paintManager.Operation = PaintOperation.DrawCircle;
            }

            private void button_rectangle_Click(object sender, EventArgs e)
            {
                paintManager.Operation = PaintOperation.DrawRectangle;
            }

            private void button_rubber_Click(object sender, EventArgs e)
            {
                paintManager.Operation = PaintOperation.Rubber;
            }

    #endregion

    #region CanvasMouseEvents

            private void pictureBox_canvas_MouseUp(object sender, MouseEventArgs e)
            {
                if (e.Button == MouseButtons.Left)
                {
                   paintManager.DrawShapes(pictureBox_canvas);
                }
            }

            private void pictureBox_canvas_Paint(object sender, PaintEventArgs e)
            {
                paintManager.RefreshDrawingShapes(e);
            }
            private void pictureBox_canvas_MouseClick(object sender, MouseEventArgs e)
            {
                if (e.Button == MouseButtons.Left)
                    paintManager.FloodFill(pictureBox_canvas, e.Location);
            }


            private void pictureBox_canvas_MouseMove(object sender, MouseEventArgs e)
            {
                if (e.Button == MouseButtons.Left)
                {
                    paintManager.MoveForwad(pictureBox_canvas, e.Location);
                    pictureBox_canvas.Invalidate();
                }

            }

            private void pictureBox_canvas_MouseDown(object sender, MouseEventArgs e)
            {
                if (e.Button == MouseButtons.Left)
                {
                    TakeCanvasSnapshot();
                    paintManager.CreateDrawer(e.Location);
                    Invalidate();
                }
            }

            private void panel3_MouseClick(object sender, MouseEventArgs e)
            {
                if (colorDialog1.ShowDialog() == DialogResult.OK)
                {
                    paintManager.Pen = new Pen(colorDialog1.Color);
                    panel3.BackColor = colorDialog1.Color;
                }
            }

    #endregion

    #region BitmapOperations
        private void InitializeBitmap()
        {
            if (pictureBox_canvas.Image == null)
            {
                Bitmap bmp = new Bitmap(pictureBox_canvas.Width, pictureBox_canvas.Height, PixelFormat.Format64bppPArgb);
                pictureBox_canvas.Image = bmp;
                using (Graphics graphics = Graphics.FromImage(pictureBox_canvas.Image))
                {
                    graphics.FillRectangle(Brushes.White, 0, 0, pictureBox_canvas.Width, pictureBox_canvas.Height);
                }
            }
        }
        private void CopyBitMap()
        {
            paintManager.CopyPictureBitmap(pictureBox_canvas);
        }
    #endregion

    #region OtherMethod
        private void SetInformationsSizeAboutCanvas()
        {
            textBox_HorizontalPositon.Text = pictureBox_canvas.Width.ToString();
            textBox_VerticalPosiotion.Text = pictureBox_canvas.Height.ToString();
            CopyBitMap();
        }

        private void TakeCanvasSnapshot()
        {
            paintManager.TakeSnapshot(pictureBox_canvas);
        }
    #endregion

    }
}
