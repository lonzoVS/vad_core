using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace vad_core.HubFunctions
{
    public class VisualizationFunction : IHubFunction
    {
        private IHubContext hubContext;

        public VisualizationFunction(IHubContext hubContext)
        {
            this.hubContext = hubContext;
        }

        public void SendToHub<T>(T arg, string user)
        {
            System.Diagnostics.Debug.WriteLine("sending to hub...");
            //hubContext.Clients.Client(user).VisualizeVad(arg);
            hubContext.Clients.Client(user).VisualizeVad(arg);

        }
    }
}
