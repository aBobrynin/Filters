using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace GraphicsFilters
{
    class grayHdtvFilter : Filter
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color sourceColor = sourceImage.GetPixel(x, y);
            int grayScale = (int)((sourceColor.R * 0.2) + (sourceColor.G * 0.7) + (sourceColor.B * 0.007));
            return Color.FromArgb(grayScale, grayScale, grayScale);

        }
    }
}
