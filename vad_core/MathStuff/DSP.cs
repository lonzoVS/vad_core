using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

namespace vad_core.MathStuff
{
    public class DSP
    {
        public double[] Spec(double[] re, double[] im, int N)
        {
            double[] sp = new double[256];
            sp[0] = Math.Abs(re[0]);
            int i;
            for (i = 1; i < (N >> 1); i++)
            {
                sp[i] = Math.Sqrt(re[i] * re[i] + im[i] * im[i]);

            }
            return sp;

        }
        public double[] LogSpec(double[] spec)
        {
            double[] p = new double[spec.Length];
            try
            {
                for (int i = 0; i < p.Length; i++)
                {
                    p[i] = Math.Log10(spec[i]);
                    if (double.IsInfinity(p[i]))
                        p[i] = 0;

                }
            }
            catch (Exception ex)
            {
                throw new FormatException(ex.Message);
            }
            return p;
        }

        public double[] Windwoing()
        {
            double[] weights = new double[512];
            for (int i = 0; i < weights.Length; i++)
            {
                weights[i] = 0.54 - 0.46 * Math.Cos(2 * Math.PI * i / 512);
            }
            return weights;
        }
        //rotation module e^(-i*2*PI*k/N)
        private Complex W(int k, int N)
        {
            if (k % N == 0) return 1;
            double arg = -2 * Math.PI * k / N;
            return new Complex(Math.Cos(arg), Math.Sin(arg));
        }
        //fft lenght = ^2
        public Complex[] Fft(Complex[] x)
        {
            Complex[] X;
            int N = x.Length;
            if (N == 2)
            {
                X = new Complex[2];
                X[0] = x[0] + x[1];
                X[1] = x[0] - x[1];
            }
            else
            {
                Complex[] x_even = new Complex[N / 2];
                Complex[] x_odd = new Complex[N / 2];
                for (int i = 0; i < N / 2; i++)
                {
                    x_even[i] = x[2 * i];
                    x_odd[i] = x[2 * i + 1];
                }
                Complex[] X_even = Fft(x_even);
                Complex[] X_odd = Fft(x_odd);
                X = new Complex[N];
                for (int i = 0; i < N / 2; i++)
                {
                    X[i] = X_even[i] + W(i, N) * X_odd[i];
                    X[i + N / 2] = X_even[i] - W(i, N) * X_odd[i];
                }
            }
            return X;
        }

    }
}
