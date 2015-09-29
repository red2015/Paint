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
        public Form1()
        {
            InitializeComponent();
            panel1.BackgroundImage = new Bitmap(panel1.Height, panel1.Width);
            TCResize tcResize = new TCResize(pictureBox1);
            if (pictureBox1.Image == null)
            {
                Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height, PixelFormat.Format32bppRgb);
                pictureBox1.Image = bmp;
                using (Graphics g = Graphics.FromImage(pictureBox1.Image))
                {
                    g.FillRectangle(Brushes.White, 0, 0, pictureBox1.Width, pictureBox1.Height);
                }
            }
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


        private Color GetPixelColor(Point location)
        {
            Bitmap bitmap = (Bitmap)pictureBox1.Image;
            return bitmap.GetPixel(location.X, location.Y);
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            CopyBitMap();
            if (filling)
            {
                if (e.Button == MouseButtons.Left)
                {
                    
                    FloodFiller floodFiller = new FloodFiller();
                    pictureBox1.Image = floodFiller.Fill((Bitmap) pictureBox1.Image, e.Location, GetPixelColor(e.Location), panel3.BackColor);
                }
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            draw = false;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if(painting)
                if (draw)
                {
                    if (e.Button == MouseButtons.Left)
                    {
                        end = e.Location;
                        using (Graphics g = Graphics.FromImage(pictureBox1.Image))
                        {
                            g.DrawLine(p, start, end);
                        }
                        pictureBox1.Invalidate();
                        start = end;
                    }
                }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {

            CopyBitMap();
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
            Bitmap oldBitmap = (Bitmap) pictureBox1.Image;
            Rectangle rec = new Rectangle(0,0, oldBitmap.Width, oldBitmap.Height);
            Bitmap newBitmap = Copy(oldBitmap, rec);
            pictureBox1.Image.Dispose();
            pictureBox1.Image = new Bitmap(newBitmap);
        }

        private Bitmap Copy(Bitmap srcBitmap, Rectangle section)
        {
            // Create the new bitmap and associated graphics object
            Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Graphics g = Graphics.FromImage(bmp);

            g.FillRectangle(Brushes.White, 0, 0, pictureBox1.Width, pictureBox1.Height);

            // Draw the specified section of the source bitmap to the new one
            g.DrawImage(srcBitmap, 0, 0, section, GraphicsUnit.Pixel);

            // Clean up
            g.Dispose();

            // Return the bitmap
            return bmp;
        }
          

    }
}
