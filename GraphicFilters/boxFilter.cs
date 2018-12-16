using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GraphicsFilters
{
    class boxFilter : LinearFilter
    {
        public boxFilter()
        {

            kernel = new float[,]{ { 1.0f, 1.0f,  1.0f}, 
			                    {1.0f,  1.0f, 1.0f},
			                    { 1.0f, 1.0f,  1.0f} };
        }
    }
}
