﻿using System.Collections.Generic;
using System.Drawing;

namespace WindowsFormsApplication1.PaintTools
{
    class FloodFiller
    {
        public Bitmap Fill(Bitmap bmp, Point pt, Color replacementColor)
        {
            Color targetColor = GetPixelColor(pt, bmp);
            if (ColorMatch(targetColor,replacementColor))
                return bmp;
            Queue<Point> q = new Queue<Point>();
            q.Enqueue(pt);
            while (q.Count > 0)
            {
                Point n = q.Dequeue();
                if (!ColorMatch(bmp.GetPixel(n.X, n.Y), targetColor))
                    continue;
                Point w = n, e = new Point(n.X + 1, n.Y);
                while ((w.X > 0) && ColorMatch(bmp.GetPixel(w.X, w.Y), targetColor))
                {
                    bmp.SetPixel(w.X, w.Y, replacementColor);
                    if ((w.Y > 0) && ColorMatch(bmp.GetPixel(w.X, w.Y - 1), targetColor))
                        q.Enqueue(new Point(w.X, w.Y - 1));
                    if ((w.Y < bmp.Height - 1) && ColorMatch(bmp.GetPixel(w.X, w.Y + 1), targetColor))
                        q.Enqueue(new Point(w.X, w.Y + 1));
                    w.X--;
                }
                while ((e.X < bmp.Width - 1) && ColorMatch(bmp.GetPixel(e.X, e.Y), targetColor))
                {
                    bmp.SetPixel(e.X, e.Y, replacementColor);
                    if ((e.Y > 0) && ColorMatch(bmp.GetPixel(e.X, e.Y - 1), targetColor))
                        q.Enqueue(new Point(e.X, e.Y - 1));
                    if ((e.Y < bmp.Height - 1) && ColorMatch(bmp.GetPixel(e.X, e.Y + 1), targetColor))
                        q.Enqueue(new Point(e.X, e.Y + 1));
                    e.X++;
                }
            }
            return bmp;
        }
        private static bool ColorMatch(Color a, Color b)
        {
            return (a.ToArgb() & 0xffffff) == (b.ToArgb() & 0xffffff);
        }

        private Color GetPixelColor(Point location, Bitmap bitmap)
        {
            return bitmap.GetPixel(location.X, location.Y);
        }
    }
}
