using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace GraphicsFilters
{
    class grayWFilter : Filter
    {
        int avR = 0;
        int avG = 0;
        int avB = 0;
        double Avg = 0;

        public grayWFilter(Bitmap img)
        {
            int N = img.Height * img.Width;
            Color tmp = new Color();
            
            for (int i = 1; i < img.Width; i++)
            {
                for (int j = 1; j < img.Height; j++)
                {
                    tmp = img.GetPixel(i, j);
                    avR += tmp.R;
                    avG += tmp.G;
                    avB += tmp.B;

                }
            }
          
            avR /= N;
            avG /= N;
            avB /= N;
            Avg = (avR + avG + avB) / 3;
        }

        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color sourceColor = sourceImage.GetPixel(x, y);

            double R = sourceColor.R;
            double G = sourceColor.G;
            double B = sourceColor.B;

            R *= Avg / avR;
            G *= Avg / avG;
            B *= Avg / avB;

            if (R > 255) R = 255;
            if (G > 255) G = 255;
            if (B > 255) B = 255;


            return Color.FromArgb((int)R, (int)G, (int)B);
            
        }
    }
}
