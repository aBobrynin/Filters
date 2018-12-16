using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace GraphicsFilters
{
    class gaussianFilter : LinearFilter
    {

        public gaussianFilter()
        {
            createGaussianKernel(3,2);
        }

        public void createGaussianKernel(int radius, float sigma)
        { 
            // kernel size
            int size = 2 * radius + 1;
            // kernel creation
            kernel = new float[size, size];
            // normalization coef
            float norm = 0;
            // Gauss kernel calculation
            for(int i = -radius; i <= radius; i++)
            {
                for(int j = -radius; j <= radius; j++)
                {
                    kernel[i + radius, j + radius] = (float)(Math.Exp(-(i * i + j * j) / (sigma * sigma)));
                    norm += kernel[i + radius, j + radius];
                } 
            } 
            // kernel normalization
            for(int i = 0; i < size; i++)
            { 
                for(int j = 0; j < size; j++)
                { 
                kernel[i, j] /= norm;
                } 
            } 
        }
    }
}
