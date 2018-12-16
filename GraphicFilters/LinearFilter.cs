using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.ComponentModel;
using System.IO;

namespace GraphicsFilters
{
    class LinearFilter : Filter 
    {
        public float[,] kernel = null;

        protected LinearFilter()
        {
        }

        public LinearFilter(float[,] ker)
        {
            this.kernel = ker;

        }

        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
          
            int kernelWidth = kernel.GetLength(0);
            int kernelHeight = kernel.GetLength(1);
            
            double rSum = 0, gSum = 0, bSum = 0, kSum = 0;

            //Bitmap tmp = new Bitmap();

            int lim;
            if (kernelHeight < 7) lim = 1;
            else lim = (kernelWidth-1)/2;
            if ((x > lim) && (x < sourceImage.Width - lim) && (y > lim) && (y < sourceImage.Height - lim))
            {

                for (int k = 0; k < kernelWidth; k++)
                {
                    for (int l = 0; l < kernelHeight; l++)
                    {
                        //int xe,ye;
                        int xe = x + k - lim;
                        int ye = y + k - lim;
                        if (x < lim) xe = 0; //x < 2
                        if (y < lim) ye = 0;
                        if (x + lim > sourceImage.Width) xe = sourceImage.Width;
                        if (y + lim > sourceImage.Height) ye = sourceImage.Height;

                        Color srcclr = sourceImage.GetPixel(xe, ye); //(x + k - lim, y + l - lim);
                        float kernelVal = kernel[k, l];
                        rSum += srcclr.R * kernelVal;
                        gSum += srcclr.G * kernelVal;
                        bSum += srcclr.B * kernelVal;

                        kSum += kernelVal;
                    }
                }


                if (kSum <= 0) kSum = 1;

                //Variables overflow control
                rSum /= kSum;
                if (rSum < 0) rSum = 0;
                if (rSum > 255) rSum = 255;

                gSum /= kSum;
                if (gSum < 0) gSum = 0;
                if (gSum > 255) gSum = 255;

                bSum /= kSum;
                if (bSum < 0) bSum = 0;
                if (bSum > 255) bSum = 255;

                return Color.FromArgb((int)rSum, (int)gSum, (int)bSum);
            }
            else
            {
                Color src = sourceImage.GetPixel(x, y);
                return Color.FromArgb((int)src.R, (int)src.G, (int)src.B);
            }
        }
    }
}
