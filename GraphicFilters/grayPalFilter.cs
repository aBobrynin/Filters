using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace GraphicsFilters
{
    class grayPalFilter : Filter
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color sourceColor = sourceImage.GetPixel(x, y);
            int grayScale = (int)((sourceColor.R * 0.3) + (sourceColor.G * 0.59) + (sourceColor.B * 0.11));
            return Color.FromArgb(grayScale, grayScale, grayScale);
            
        }
    }
}
