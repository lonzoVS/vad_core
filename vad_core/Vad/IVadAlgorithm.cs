using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace vad_core.Vad
{
    public abstract class IVadAlgorithm
    {
        public double[] VadList { get; set; } 
        abstract public void PerformVad(double[] samples);
    }
}
