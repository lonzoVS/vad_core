using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

namespace vad_core.MathStuff.DSPHelper
{
    public abstract class Visualization
    {
        protected double[] dspSet { get; set; }


        abstract public double[] Compute(bool doFFT, int fftLength = 256);

        public virtual double[] RawFFT(int fftLength)
        {
            DSP dsp = new DSP();
            MFCC mfcc = new MFCC();
            List<double> fullFFT = new List<double>();

            foreach (double[] chunk in dspSet.Split(fftLength))
            {

                double[] windowedFrame = chunk.Multiply(dsp.Windwoing());
                double[] image = Enumerable.Repeat(0.0, fftLength).ToArray();
                double[] spec = new double[fftLength];
                Complex[] fourierCmplxRaw = new Complex[fftLength];
                for (int i = 0; i < fftLength; i++)
                {
                    fourierCmplxRaw[i] = new Complex(windowedFrame[i], image[i]);
                }
                Complex[] fourierCmplxRaw1 = dsp.Fft(fourierCmplxRaw);
                for (int i = 0; i < fftLength; i++)
                {
                    spec[i] = fourierCmplxRaw1[i].Magnitude;
                    image[i] = fourierCmplxRaw1[i].Imaginary;
                }
                spec = ProcessFFT(spec, dsp, fftLength);
                fullFFT.AddRange(spec);

            }
            return fullFFT.ToArray();
        }

        public virtual double[] ProcessFFT(double[] samples, DSP dsp, int dspLength)
        {
            return samples;
        }
        
    }

}
