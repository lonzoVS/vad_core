using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using vad_core.WaveProcessor;
using vad_core.Vad;
using Microsoft.AspNetCore.Hosting;
using vad_core.HubFunctions;
using Microsoft.AspNetCore.SignalR.Infrastructure;
using Microsoft.AspNetCore.Http.Features;
using vad_core.Hubs;
using vad_core.ClientsRepo;

namespace vad_core.Controllers
{
    public class AudioProcessController : Controller
    {
        private IHostingEnvironment hostingEnvironment;
        private readonly IConnectionManager connectionManager;
        public AudioProcessController(IHostingEnvironment hostingEnvironment, IConnectionManager connMangr)
        {
            this.hostingEnvironment = hostingEnvironment;
            connectionManager = connMangr;
        }

        [HttpPost]
        public IActionResult Process([FromBody]string filePath)
        {

            Signal signal = new Signal();
            signal.ReadWAVE(filePath);
            VAD vad = new VadMfcc(new MfccVadAlgorithm(32, this.hostingEnvironment.WebRootPath, (int)signal.WavModel.freq));
            vad.PerformVad(signal.WavModel.samples);
            System.Diagnostics.Debug.WriteLine(vad.performVad.VadList.Length);
            var hubContext = connectionManager.GetHubContext<VisualizationHub>();
            VisualizationFunction sendProgress = new VisualizationFunction(hubContext);
            var ip = HttpContext.Features.Get<IHttpConnectionFeature>()?.RemoteIpAddress?.ToString();
            var connectionId = RepositoryIsolator.Of.Clients.GetId(ip);
            int percentage = 0;
            sendProgress.SendToHub(percentage, connectionId);
            GC.Collect();
            return Json("success");
        }
    }
}