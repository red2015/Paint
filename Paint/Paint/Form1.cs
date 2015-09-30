using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using WindowsFormsApplication1.PaintTools.Shapes.DrawingStrategy;
using PaintApplication.PaintTools;
using Trestan;

namespace PaintApplication
{
    public partial class Form1 : Form
    {
        private PaintManager paintManager;
        
        public Form1()
        {
            InitializeComponent();
            TCResize tcResize = new TCResize(pictureBox_cavans);
            tcResize.SizeIsChanging += SetInformationsSizeAboutCanvan;
            tcResize.SizeIsStarChanging += TakeCanvanSnapshot;
            if (pictureBox_cavans.Image == null)
            {
                Bitmap bmp = new Bitmap(pictureBox_cavans.Width, pictureBox_cavans.Height, PixelFormat.Format32bppRgb);
                pictureBox_cavans.Image = bmp;
                using (Graphics graphics = Graphics.FromImage(pictureBox_cavans.Image))
                {
                    graphics.FillRectangle(Brushes.White, 0, 0, pictureBox_cavans.Width, pictureBox_cavans.Height);
                }
            }
            SetInformationsSizeAboutCanvan();
            
            paintManager = new PaintManager();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            paintManager.Operation = PaintOperation.FloodFill;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            paintManager.Operation = PaintOperation.BasicDraw;
        }
        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
                paintManager.FloodFill(pictureBox_cavans,e.Location);
        }


        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                paintManager.Draw(pictureBox_cavans, e.Location);
                
            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                TakeCanvanSnapshot();
                paintManager.ActualImage = pictureBox_cavans.Image;
                paintManager.StartPoint = e.Location;
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
            paintManager.UndoOperation(pictureBox_cavans);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            pictureBox_cavans.Size = new Size(int.Parse(textBox_HorizontalPositon.Text), int.Parse(textBox_VerticalPosiotion.Text));
        }

        private void SetInformationsSizeAboutCanvan()
        {
            textBox_HorizontalPositon.Text = pictureBox_cavans.Width.ToString();
            textBox_VerticalPosiotion.Text = pictureBox_cavans.Height.ToString();
            CopyBitMap();
        }

        private void TakeCanvanSnapshot()
        {
            paintManager.TakeSnapshot(pictureBox_cavans);
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
            paintManager.Operation = PaintOperation.DrawLine;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            paintManager.Operation = PaintOperation.DrawCircle;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            paintManager.Operation = PaintOperation.DrawRectangle;
        }

        private void button_Rubber_Click(object sender, EventArgs e)
        {
            paintManager.Operation = PaintOperation.Rubber;
        }
    }
}
