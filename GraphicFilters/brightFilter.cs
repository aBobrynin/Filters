using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace GraphicsFilters
{
    class brightFilter : Filter
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            
            Color sourceColor = sourceImage.GetPixel(x, y);
            int grayScale = (int)((sourceColor.R * 0.2) + (sourceColor.G * 0.7) + (sourceColor.B * 0.007));
            int brightness = 100;
            int cR = sourceColor.R + brightness;
            int cG = sourceColor.G + brightness;
            int cB = sourceColor.B + brightness;

            if (cR > 255) cR = 255;
            if (cG > 255) cG = 255;
            if (cB > 255) cB = 255;

            return Color.FromArgb(cR, cG, cB);

        }
    }
}
