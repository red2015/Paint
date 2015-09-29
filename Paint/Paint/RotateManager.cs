﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class RotateManager
    {
        public Bitmap Rotate180Degrees(Image image)
        {
            Bitmap rotatedBmp = new Bitmap(image, image.Width, image.Height);
            rotatedBmp.RotateFlip(RotateFlipType.Rotate180FlipNone);
            return rotatedBmp;
        }

        public Bitmap Rotate90DegreesLeft(Image image)
        {
            Bitmap rotatedBmp = new Bitmap(image, image.Width, image.Height);
            rotatedBmp.RotateFlip(RotateFlipType.Rotate270FlipNone);
            return rotatedBmp;
        }

        public Bitmap Rotate90DegreesRight(Image image)
        {
            Bitmap rotatedBmp = new Bitmap(image, image.Width, image.Height);
            rotatedBmp.RotateFlip(RotateFlipType.Rotate90FlipNone);
            return rotatedBmp;
        }

        public Bitmap FlipHorizontal(Image image)
        {
            Bitmap rotatedBmp = new Bitmap(image, image.Width, image.Height);
            rotatedBmp.RotateFlip(RotateFlipType.Rotate180FlipX);
            return rotatedBmp;
        }


        public Bitmap FlipVertical(Image image)
        {
            Bitmap rotatedBmp = new Bitmap(image, image.Width, image.Height);
            rotatedBmp.RotateFlip(RotateFlipType.Rotate180FlipY);
            return rotatedBmp;
        }
    }
}
