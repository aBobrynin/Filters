using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace GraphicsFilters
{
    class sepiaFilter : Filter
    {

        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color sourceColor = sourceImage.GetPixel(x, y);
            int Tone = (int)((sourceColor.R * 0.3) + (sourceColor.G * 0.59) + (sourceColor.B * 0.11));
            int R = ((Tone > 206) ? 255 : Tone + 49);
            int G = ((Tone < 14) ? 0 : Tone - 14);
            int B = ((Tone < 56) ? 0 : Tone - 56);

            return Color.FromArgb(R, G, B);
        }
    }
}
