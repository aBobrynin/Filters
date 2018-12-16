using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GraphicFilters 
{
    abstract class Filter
    {
        protected abstract Color calculateNewPixelColor(Bitmap sourceImage, int x, int y);


        public Bitmap processImage(Bitmap sourceImage, BackgroundWorker worker)
        {
            Bitmap resultImage = new Bitmap(sourceImage.Width, sourceImage.Height);

            for (int i = 0; i < sourceImage.Width; i++)
            {
                for (int j = 0; j < sourceImage.Height; j++)
                {
                    resultImage.SetPixel(i, j, calculateNewPixelColor(sourceImage, i, j));
                }
                worker.ReportProgress((int)((float)i / resultImage.Width * 100 + 1));
            }
            return resultImage;

        }

    }

     class InvertFilter : Filter
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color sourceColor = sourceImage.GetPixel(x, y);
            return Color.FromArgb(255 - sourceColor.R, 255 - sourceColor.G, 255 - sourceColor.B);
        }
         
    }


     class SepiaFilter : Filter
     {
         protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
         {
             Color sourceColor = sourceImage.GetPixel(x, y);
             return Color.FromArgb(255 - sourceColor.R, 255 - sourceColor.G, 255 - sourceColor.B);
                          
         }
     }

     class GrayFilterPAL : Filter
     {
         protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
         {
             Color sourceColor = sourceImage.GetPixel(x, y);
             double YY = (0.299 * sourceColor.R + 0.587 * sourceColor.G + 0.114 * sourceColor.B);
             int Y = (int)YY;
             if (Y > 255) Y = 255;
             return Color.FromArgb(Y, Y, Y);


         }


     }

     class GrayFilterHDTV : Filter
     {
         protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
         {
             Color sourceColor = sourceImage.GetPixel(x, y);
             double YY = (0.2126 * sourceColor.R + 0.7152 * sourceColor.G + 0.0722 * sourceColor.B);
             int Y = (int)YY;
             if (Y > 255) Y = 255;
             return Color.FromArgb(Y, Y, Y);

         }
         
     }


   class LinearFilter : Filter
    {
       public LinearFilter(float[,] ker, int div)
       {
           kernel=ker;
           divfactor = div;
       }
       
        float[,] kernel = new float[3,3];
        int divfactor;
       

       ////////////////// process image

      /*  new public Bitmap processImage(Bitmap sourceImage, BackgroundWorker worker)
        {
            Bitmap resultImage = new Bitmap(sourceImage.Width, sourceImage.Height);
            
            for (int i = 1; i < sourceImage.Width-1; i++)
            {
                for (int j = 1; j < sourceImage.Height-1; j++)
                {
                    resultImage.SetPixel(i, j, calculateNewPixelColor(sourceImage, i, j));
                }
                worker.ReportProgress((int)((float)i / resultImage.Width * 100 + 1));
            }


            return resultImage;
        }
       */



       /*
        public Bitmap processImage(Bitmap sourceImage, BackgroundWorker worker)
        {
            Bitmap resultImage = new Bitmap(sourceImage.Width, sourceImage.Height);

            for (int i = 0; i < sourceImage.Width; i++)
            {
                for (int j = 0; j < sourceImage.Height; j++)
                {
                    resultImage.SetPixel(i, j, calculateNewPixelColor(sourceImage, i, j));
                }
                worker.ReportProgress((int)((float)i / resultImage.Width * 100 + 1));
            }
            return resultImage;

        }
       */
       




        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {    
                 
            double sumR=0,sumG=0,sumB =0;

            Color sourceColor = sourceImage.GetPixel(x,y);

            if (x > 0 && x <sourceImage.Width-1  && y > 0 && y < sourceImage.Height-1)
            {
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        sourceColor = sourceImage.GetPixel(x + j - 1, y + i - 1);
                        sumR += kernel[i, j] * sourceColor.R;
                        sumG += kernel[i, j] * sourceColor.G;
                        sumB += kernel[i, j] * sourceColor.B;

                    }

                }
                int sumRi = 0, sumGi = 0, sumBi = 0;

                sumR /= divfactor;
                sumG /= divfactor;
                sumB /= divfactor;


                sumRi = Math.Abs((int)sumR);
                if (sumRi > 255) sumRi = 255;

                sumGi = Math.Abs((int)sumG);
                if (sumGi > 255) sumGi = 255;

                sumBi = Math.Abs((int)sumB);
                if (sumBi > 255) sumBi = 255;


                return Color.FromArgb(sumRi, sumGi, sumBi);
            }
            else { return sourceColor; }

 

        }

    }
}


