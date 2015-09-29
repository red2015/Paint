using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using PaintApplication.PaintTools;
using PaintApplication.PaintTools.Shapes;
using Trestan;

namespace PaintApplication
{
    public partial class Form1 : Form
    {
        private PaintOperation _actualPaintOperation = PaintOperation.BasicDraw;
        private Graphics g;
        private Point start;
        private Point end;
        private Pen p = new Pen(Color.Black);
        private Caretaker _history =  new Caretaker();
        private Originator _orginator;
        private DrawLineManager _drawLineManager;
        private DrawCircleManager _drawCircleManager;
        private ShapesManager _shapesManager;
        
        
        public Form1()
        {
            InitializeComponent();
            panel1.BackgroundImage = new Bitmap(panel1.Height, panel1.Width);
            TCResize tcResize = new TCResize(pictureBox_cavans);
            tcResize.SizeIsChanging += SetInformationsSize;
            tcResize.SizeIsStarChanging += TakeCanvanSnapshot;

            textBox_HorizontalPositon.Text = pictureBox_cavans.Width.ToString();
            textBox_VerticalPosiotion.Text = pictureBox_cavans.Height.ToString();
            if (pictureBox_cavans.Image == null)
            {
                Bitmap bmp = new Bitmap(pictureBox_cavans.Width, pictureBox_cavans.Height, PixelFormat.Format32bppRgb);
                pictureBox_cavans.Image = bmp;
                using (Graphics graphics = Graphics.FromImage(pictureBox_cavans.Image))
                {
                    graphics.FillRectangle(Brushes.White, 0, 0, pictureBox_cavans.Width, pictureBox_cavans.Height);
                }
            }
            
            _orginator = new Originator((Bitmap)pictureBox_cavans.Image, pictureBox_cavans.Height, pictureBox_cavans.Width);
            _history.SaveState(_orginator);
            _drawLineManager = new DrawLineManager();
            _drawCircleManager = new DrawCircleManager();
            _shapesManager = new ShapesManager();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _actualPaintOperation = PaintOperation.FloodFill;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _actualPaintOperation = PaintOperation.BasicDraw;
        }
        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            CopyBitMap();
            if (_actualPaintOperation == PaintOperation.FloodFill)
            {
                if (e.Button == MouseButtons.Left)
                {
                    FloodFiller floodFiller = new FloodFiller();
                    pictureBox_cavans.Image = floodFiller.Fill((Bitmap) pictureBox_cavans.Image, e.Location, panel3.BackColor);
                }
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
         
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _shapesManager.Draw(pictureBox_cavans, e.Location,p,_actualPaintOperation);
            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                TakeCanvanSnapshot();
                _shapesManager.GetActualImage = pictureBox_cavans.Image;
                _shapesManager.GetStartPoint = e.Location;
            }
        }

        private void panel3_MouseClick(object sender, MouseEventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                p.Color = colorDialog1.Color;
                panel3.BackColor = colorDialog1.Color;
            }
        }

        private void CopyBitMap()
        {
            Bitmap oldBitmap = (Bitmap) pictureBox_cavans.Image;
            Rectangle rec = new Rectangle(0, 0, oldBitmap.Width, oldBitmap.Height);
            Bitmap newBitmap = Copy(oldBitmap, rec);
            pictureBox_cavans.Image.Dispose();
            pictureBox_cavans.Image = new Bitmap(newBitmap);
        }

        private Bitmap Copy(Bitmap srcBitmap, Rectangle section)
        {
            // Create the new bitmap and associated graphics object
            Bitmap bmp = new Bitmap(pictureBox_cavans.Width, pictureBox_cavans.Height);
            Graphics graphics = Graphics.FromImage(bmp);

            graphics.FillRectangle(Brushes.White, 0, 0, pictureBox_cavans.Width, pictureBox_cavans.Height);

            // Draw the specified section of the source bitmap to the new one
            graphics.DrawImage(srcBitmap, 0, 0, section, GraphicsUnit.Pixel);

            // Clean up
            graphics.Dispose();

            // Return the bitmap
            return bmp;
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveManager saveManager = new SaveManager();
            saveManager.SavePictureToBmpFile(pictureBox_cavans);
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadManager loadManager = new LoadManager();
            Bitmap bitmap = loadManager.LoadBmpPictureFile();
            pictureBox_cavans.Size = new Size(bitmap.Width, bitmap.Height);
            pictureBox_cavans.Image = bitmap;
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _history.RestoreState(_orginator);
            SetCavanBitmapAndSize(_orginator.GetBitmap(), _orginator.GetHeight(), _orginator.GetWidth());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            pictureBox_cavans.Size = new Size(int.Parse(textBox_HorizontalPositon.Text), int.Parse(textBox_VerticalPosiotion.Text));
        }

        private void SetCavanBitmapAndSize(Bitmap bitmap, int height, int width)
        {
            pictureBox_cavans.Size = new Size(width, height);
            pictureBox_cavans.Image = (Bitmap) bitmap.Clone();
        }

        private void SetInformationsSize()
        {
            textBox_HorizontalPositon.Text = pictureBox_cavans.Width.ToString();
            textBox_VerticalPosiotion.Text = pictureBox_cavans.Height.ToString();
            CopyBitMap();
        }

        private void TakeCanvanSnapshot()
        {
            Bitmap bit = new Bitmap(pictureBox_cavans.Image);
            _orginator = new Originator(bit, pictureBox_cavans.Height, pictureBox_cavans.Width);
            _history.SaveState(_orginator);
        }

        private void degreesInRightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TakeCanvanSnapshot();
            RotateManager manager = new RotateManager();
            Image oldImage = pictureBox_cavans.Image;
            pictureBox_cavans.Size = new Size(pictureBox_cavans.Height, pictureBox_cavans.Width);
            pictureBox_cavans.Image = manager.Rotate90DegreesRight(oldImage);
        }

        private void degreesInLeftToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TakeCanvanSnapshot();
            RotateManager manager = new RotateManager();
            Image oldImage = pictureBox_cavans.Image;
            pictureBox_cavans.Size = new Size(pictureBox_cavans.Height, pictureBox_cavans.Width);
            pictureBox_cavans.Image = manager.Rotate90DegreesLeft(oldImage);
        }

        private void horizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TakeCanvanSnapshot();
            RotateManager manager = new RotateManager();
            Image oldImage = pictureBox_cavans.Image;
            pictureBox_cavans.Image = manager.FlipHorizontal(oldImage);
        }

        private void verticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TakeCanvanSnapshot();
            RotateManager manager = new RotateManager();
            Image oldImage = pictureBox_cavans.Image;
            pictureBox_cavans.Image = manager.FlipVertical(oldImage);
        }

        private void degreesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TakeCanvanSnapshot();
            RotateManager manager = new RotateManager();
            Image oldImage = pictureBox_cavans.Image;
            pictureBox_cavans.Image = manager.Rotate180Degrees(oldImage);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            _actualPaintOperation = PaintOperation.DrawLine;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            _actualPaintOperation = PaintOperation.DrawCircle;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            _actualPaintOperation = PaintOperation.DrawRectangle;
        }
    }
}
