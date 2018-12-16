using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace GraphicsFilters
{
    class embossFilter : LinearFilter
    {
        //public float[,] kernel = null;
        public embossFilter()
        {

            kernel = new float[,] { { -1.0f, -1.0f, 0.0f },
                                { -1.0f, 0.0f, 1.0f },
                                { 0.0f, 1.0f, 1.0f } };
        }

        
        
    }
}
