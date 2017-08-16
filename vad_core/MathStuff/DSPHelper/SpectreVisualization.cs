using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace vad_core.MathStuff.DSPHelper
{
    public class SpectreVisualization : Visualization
    {

        public SpectreVisualization(double[] dspSet)
        {
            this.dspSet = dspSet;
        }


        override public double[] Compute(bool doFFT, int fftLength = 256)
        {
            List<double> spec = new List<double>();
            if (doFFT)
            {
                    spec = RawFFT(fftLength).ToList();
            }
            else
            {
                foreach (double[] chunk in dspSet.Split(fftLength))
                {
                    spec.AddRange(ProcessFFT(dspSet, new DSP(), fftLength));
                }
            }
            return spec.ToArray();
                
        }

        override public double[] ProcessFFT(double[] samples, DSP dsp, int fftLenght)
        {
            samples = dsp.Spec(samples, Enumerable.Repeat(0.0, fftLenght).ToArray(), fftLenght);
            return samples;
        }

    }
}
