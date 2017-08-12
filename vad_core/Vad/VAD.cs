using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace vad_core.Vad
{
    abstract public class VAD
    {
        public IVadAlgorithm performVad { get; set; }

        virtual public void PerformVad(double[] samples)
        {
            performVad.PerformVad(samples);
        }

    }
}
