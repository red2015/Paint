using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    class MyPictureBox : Panel
    {
        private PictureBox _picture;
        
        private Point _startDraw;
        private Point _endDraw;

        public MyPictureBox()
        {
            
            InitializeComponent();
            Bitmap bmp = new Bitmap(_picture.Height, _picture.Width);
            _picture.Image = bmp;
            Controls.Add(_picture);
        }
        private void InitializeComponent()
        {
            this._picture = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this._picture)).BeginInit();
            this.SuspendLayout();
            // 
            // _picture
            // 
            this._picture.BackColor = System.Drawing.Color.White;
            this._picture.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._picture.Cursor = System.Windows.Forms.Cursors.Cross;
            this._picture.Dock = System.Windows.Forms.DockStyle.Fill;
            this._picture.Location = new System.Drawing.Point(0, 0);
            this._picture.Name = "_picture";
            this._picture.Size = new System.Drawing.Size(556, 452);
            this._picture.TabIndex = 0;
            this._picture.TabStop = false;
            this._picture.MouseDown += new System.Windows.Forms.MouseEventHandler(this._picture_MouseDown);
            this._picture.MouseMove += new System.Windows.Forms.MouseEventHandler(this._picture_MouseMove);
            this._picture.MouseUp += new System.Windows.Forms.MouseEventHandler(this._picture_MouseUp);
            // 
            // MyPictureBox
            // 
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            ((System.ComponentModel.ISupportInitialize)(this._picture)).EndInit();
            this.ResumeLayout(false);

        }

        public void Draw(Color color)
        {
            using (Graphics g = Graphics.FromImage(_picture.Image))
            {
                g.DrawLine(new Pen(color), _startDraw, _endDraw);
            }
            _picture.Invalidate();
            _startDraw = _endDraw;
        }

        public Point StartDraw
        {
            set { _startDraw = value; }
        }

        public Point EndDraw
        {
            set { _endDraw = value; }
        }

        public void FloodFill(Point pt, Color replacementColor)
        {
            FloodFiller floodFiller = new FloodFiller();
            var targetColor = GetPixelColor(pt);
            _picture.Image= floodFiller.Fill((Bitmap) _picture.Image, pt, targetColor, replacementColor);
        }

        private Color GetPixelColor(Point location)
        {
            Bitmap bitmap = (Bitmap)_picture.Image;
            return bitmap.GetPixel(location.X, location.Y);
        }

        private void _picture_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                StartDraw = e.Location;
            }
          
        }

        private void _picture_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                EndDraw = e.Location;
                Draw(Color.Black);
            }
        }

        private void _picture_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {

            }
        }

        public void LoadFromFile(string txt)
        {
            try
            {
                _picture.Load(txt);
            }
            catch
            {
                MessageBox.Show("Nie można odczytać pliku", "Błąd",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _picture.Size = _picture.Image.Size;
            _picture.SizeMode = PictureBoxSizeMode.CenterImage;
        }
    }
}
