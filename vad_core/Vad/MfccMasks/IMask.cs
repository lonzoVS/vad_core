using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace vad_core.Vad.MfccMasks
{
    public interface IMask
    {
        double[] Mask(double[] mfccList, string envPath);
    }
}
