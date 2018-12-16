using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GraphicsFilters
{
    class sobelFilter : LinearFilter
    {
        public sobelFilter()
        {
            kernel = new float[,] { { -1.0f, 0.0f, 1.0f },
                                { -2.0f, 0.0f, 2.0f },
                                { -1.0f, 0.0f, 1.0f } };
        }
    }
}
