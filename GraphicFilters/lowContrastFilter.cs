using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GraphicsFilters
{
    class lowContrastFilter : LinearFilter
    {

        public lowContrastFilter()
        {
            kernel = new float[,]{ { 0.0f, -1.0f,  0.0f}, 
			                    {-1.0f,  5.0f, -1.0f},
			                    { 0.0f, -1.0f,  0.0f} };
        }

        
    }
}
