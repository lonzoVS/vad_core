using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using vad_core.MathStuff;
namespace vad_core.Vad.MfccMasks
{
    public class NoiseMask : IMask
    {
        public double[] Mask(double[] mfccList, string envPath)
        {
            List<double> vadNoiseMask = new List<double>();
            int maskCounter = 0;
            double[] maskNoise = File.ReadAllLines(envPath + "\\masks\\noiseMask.txt").Select(s => double.Parse(s)).ToArray();

            foreach (double[] slice in mfccList.Split(32))
            {

                for (int i = 0; i < slice.Length; i++)
                {
                    if (Math.Abs(slice[i] - maskNoise[i]) <= 0.1)
                    {
                        maskCounter++;

                    }
                }
                if (maskCounter >= 20)
                {
                    vadNoiseMask.AddRange(Enumerable.Repeat(0.0, 32));
                    maskCounter = 0;
                }
                else
                {
                    vadNoiseMask.AddRange(slice);
                    maskCounter = 0;
                }

            }
            return vadNoiseMask.ToArray();
        }
    }
}
