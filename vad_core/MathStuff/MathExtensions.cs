using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace vad_core.MathStuff
{
    public static class MathExtensions
    {
        public static IEnumerable<double[]> Split(this double[] value, int bufferLength)
        {
            int countOfArray = 0;
            countOfArray = value.Length / bufferLength;
            for (int i = 0; i < countOfArray; i++)
            {
                yield return value.Skip(i * bufferLength).Take(bufferLength).ToArray();
            }

        }

        public static double[] Multiply(this double[] x, double[] y)
        {
            double[] z = new double[x.Length];
            for (int i = 0; i < x.Length; i++)
            {
                z[i] = x[i] * y[i];
            }
            return z;
        }

        public static T[,] CreateRectangularArray<T>(IList<T[]> arrays)
        {
            int minorLength = arrays[0].Length;
            T[,] ret = new T[arrays.Count, minorLength];
            for (int i = 0; i < arrays.Count; i++)
            {
                var array = arrays[i];
                if (array.Length != minorLength)
                {
                    throw new ArgumentException
                        ("All arrays must be the same length");
                }
                for (int j = 0; j < minorLength; j++)
                {
                    ret[i, j] = array[j];
                }
            }
            return ret;
        }
        public static double[] GetCol(double[,] matrix, int col)
        {
            var colLength = matrix.GetLength(0);
            var colVector = new double[colLength];

            for (var i = 0; i < colLength; i++)
            {
                colVector[i] = matrix[i, col];
            }

            return colVector;
        }

        public static double ComputeCoeff(double[] values1, double[] values2)
        {
            if (values1.Length != values2.Length)
                throw new ArgumentException("values must be the same length");

            var avg1 = values1.Average();
            var avg2 = values2.Average();

            var sum1 = values1.Zip(values2, (x1, y1) => (x1 - avg1) * (y1 - avg2)).Sum();

            var sumSqr1 = values1.Sum(x => Math.Pow((x - avg1), 2.0));
            var sumSqr2 = values2.Sum(y => Math.Pow((y - avg2), 2.0));

            var result = sum1 / Math.Sqrt(sumSqr1 * sumSqr2);

            return result;
        }
    }
}
