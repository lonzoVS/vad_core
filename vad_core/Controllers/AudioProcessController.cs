using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using vad_core.WaveProcessor;
using vad_core.Vad;
using Microsoft.AspNetCore.Hosting;

namespace vad_core.Controllers
{
    public class AudioProcessController : Controller
    {
        private IHostingEnvironment hostingEnvironment;

        public AudioProcessController(IHostingEnvironment hostingEnvironment)
        {
            this.hostingEnvironment = hostingEnvironment;
        }

        [HttpPost]
        public IActionResult Process([FromBody]string filePath)
        {

            Signal signal = new Signal();
            signal.ReadWAVE(filePath);
            VAD vad = new VadMfcc(new MfccVadAlgorithm(32, this.hostingEnvironment.WebRootPath, (int)signal.WavModel.freq));
            vad.PerformVad(signal.WavModel.samples);
            System.Diagnostics.Debug.WriteLine(vad.performVad.VadList.Length);
            return Json("success");
        }
    }
}