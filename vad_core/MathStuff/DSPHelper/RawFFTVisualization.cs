using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace vad_core.MathStuff.DSPHelper
{
    public class RawFFTVisualization : Visualization
    {
        
        public RawFFTVisualization(double[] samples)
        {
            dspSet = samples;
        }


        override public double[] Compute(bool doFFT, int fftLength = 256)
        {
          return RawFFT(fftLength);
        }
    }
}
