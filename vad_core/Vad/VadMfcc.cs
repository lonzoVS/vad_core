﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace vad_core.Vad
{
    public class VadMfcc : VAD
    {
        public VadMfcc(IVadAlgorithm performVad)
        {
            this.performVad = performVad;
        }



    }
}
