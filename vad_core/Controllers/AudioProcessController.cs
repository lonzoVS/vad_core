using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using vad_core.WaveProcessor;

namespace vad_core.Controllers
{
    public class AudioProcessController : Controller
    {
  
        [HttpPost]
        public IActionResult Process([FromBody]string filePath)
        {

            Signal signal = new Signal();
            signal.ReadWAVE(filePath);
            System.Diagnostics.Debug.WriteLine(signal.WavModel.samples.Count());
            return Json("success");
        }
    }
}