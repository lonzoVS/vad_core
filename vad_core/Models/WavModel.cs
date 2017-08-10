using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace vad_core.Models
{
    public class WavModel
    {
        public WavModel()
        {

        }
        public WavModel(double[] samples, double[] samples2, short type, short channels, long freq, long bytes, short aling, short bits, long len_data)
        {
            this.samples = samples;
            this.samples2 = samples2;
            this.type = type;
            this.channels = channels;
            this.freq = freq;
            this.bytes = bytes;
            this.aling = aling;
            this.bits = bits;
            this.len_data = len_data;
              

        }
        public double[] samples { get; set; }
        public double[] samples2 { get; set; }

        public short type { get; set; }
        public short channels { get; set; }

        public long freq { get; set; }
        public long bytes { get; set; }
        public short aling { get; set; }
        public short bits { get; set; }
        public long len_data { get; set; }

       
    }
}
