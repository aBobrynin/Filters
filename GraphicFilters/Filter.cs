using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.ComponentModel;
using System.Collections;


namespace GraphicsFilters
{
    abstract class Filter
    {
        int i, j;
 
        protected abstract Color calculateNewPixelColor(Bitmap sourceImage, int x, int y);

        public Bitmap processImage(Bitmap sourceImage, BackgroundWorker worker)
        {   
            Bitmap resultImage = new Bitmap(sourceImage.Width, sourceImage.Height);

            for ( i = 0; i < sourceImage.Width; i++)
            {
                for ( j = 0; j < sourceImage.Height; j++)
                {
                    resultImage.SetPixel(i, j, calculateNewPixelColor(sourceImage, i, j));

                }

                worker.ReportProgress((int)((float)i / resultImage.Width * 100));
            }

            return resultImage;
        }

    } 
}
