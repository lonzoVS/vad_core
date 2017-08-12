using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace vad_core.Vad
{
    public interface IVadAlgorithm
    {
        double[] VadList { get; set; } 
        void PerformVad(double[] samples);
    }
}
