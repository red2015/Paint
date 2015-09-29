using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Trestan;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        private bool painting = true;
        private bool filling = false;
        private bool draw = false;
        private Graphics g;
        private Point start;
        private Point end;
        private Pen p = new Pen(Color.Black);
        private Caretaker history =  new Caretaker();
        private Originator orgi;
        private Bitmap actualBitmap;
        private Stack<Bitmap> unDoBitmap = new Stack<Bitmap>();
        
        
        public Form1()
        {
            InitializeComponent();
            panel1.BackgroundImage = new Bitmap(panel1.Height, panel1.Width);
            TCResize tcResize = new TCResize(pictureBox_cavans);
            textBox_HorizontalPositon.Text = pictureBox_cavans.Width.ToString();
            textBox_VerticalPosiotion.Text = pictureBox_cavans.Height.ToString();
            if (pictureBox_cavans.Image == null)
            {
                Bitmap bmp = new Bitmap(pictureBox_cavans.Width, pictureBox_cavans.Height, PixelFormat.Format32bppRgb);
                pictureBox_cavans.Image = bmp;
                using (Graphics g = Graphics.FromImage(pictureBox_cavans.Image))
                {
                    g.FillRectangle(Brushes.White, 0, 0, pictureBox_cavans.Width, pictureBox_cavans.Height);
                }
                unDoBitmap.Push((Bitmap)bmp.Clone());
            }
            
            orgi = new Originator((Bitmap)pictureBox_cavans.Image, pictureBox_cavans.Height, pictureBox_cavans.Width);
            history.SaveState(orgi);
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            painting = false;
            filling = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            painting = true;
            filling = false;
        }
        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            CopyBitMap();
            if (filling)
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
            draw = false;
            
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (painting)
            {
                if (draw)
                {
                    if (e.Button == MouseButtons.Left)
                    {
                        end = e.Location;
                        using (Graphics g = Graphics.FromImage(pictureBox_cavans.Image))
                        {
                            g.DrawLine(p, start, end);
                        }
                        pictureBox_cavans.Invalidate();
                        start = end;
                    }

                }
            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {

            CopyBitMap();
            Bitmap bit = new Bitmap(pictureBox_cavans.Image);
            orgi = new Originator(bit, pictureBox_cavans.Height, pictureBox_cavans.Width);
            history.SaveState(orgi);
            //unDoBitmap.Push((Bitmap)bit.Clone());
            if (painting)
                if (e.Button == MouseButtons.Left)
                {
                    draw = true;
                    start = e.Location;
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
            Rectangle rec = new Rectangle(0,0, oldBitmap.Width, oldBitmap.Height);
            Bitmap newBitmap = Copy(oldBitmap, rec);
            pictureBox_cavans.Image.Dispose();
            pictureBox_cavans.Image = new Bitmap(newBitmap);
        }

        private Bitmap Copy(Bitmap srcBitmap, Rectangle section)
        {
            // Create the new bitmap and associated graphics object
            Bitmap bmp = new Bitmap(pictureBox_cavans.Width, pictureBox_cavans.Height);
            Graphics g = Graphics.FromImage(bmp);

            g.FillRectangle(Brushes.White, 0, 0, pictureBox_cavans.Width, pictureBox_cavans.Height);

            // Draw the specified section of the source bitmap to the new one
            g.DrawImage(srcBitmap, 0, 0, section, GraphicsUnit.Pixel);

            // Clean up
            g.Dispose();

            // Return the bitmap
            return bmp;
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Bitmap bmp = new Bitmap(pictureBox_cavans.Width, pictureBox_cavans.Height, PixelFormat.Format32bppRgb);
            //pictureBox_cavans.Image = bmp;
            //using (Graphics g = Graphics.FromImage(pictureBox_cavans.Image))
            //{
            //    g.FillRectangle(Brushes.White, 0, 0, pictureBox_cavans.Width, pictureBox_cavans.Height);
            //}
            //pictureBox_cavans.Image = bmp;

            //pictureBox_cavans.Image = 
            //    (Bitmap) unDoBitmap.Pop().Clone();
            //pictureBox_cavans.Refresh();

            history.RestoreState(orgi);
            SetCavanBitmapAndSize(orgi.GetBitmap(), orgi.GetHeight(), orgi.GetWidth());

        }

        private void button3_Click(object sender, EventArgs e)
        {
            pictureBox_cavans.Size = new Size(int.Parse(textBox_HorizontalPositon.Text), int.Parse(textBox_VerticalPosiotion.Text));

        }

        private void SetCavanBitmapAndSize(Bitmap bitmap, int height, int width)
        {
            pictureBox_cavans.Size = new Size(width,height);
            pictureBox_cavans.Image = (Bitmap) bitmap.Clone();
        }
          

    }
}
