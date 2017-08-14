using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vad_core.Hubs;
using Microsoft.AspNetCore.SignalR.Infrastructure;
using Microsoft.AspNetCore.SignalR.Hubs;
using Microsoft.AspNetCore.SignalR;

namespace vad_core.HubFunctions
{
    public class ProgressBarFunction : IHubFunction
    {
        private IHubContext hubContext;

        public ProgressBarFunction(IHubContext hubContext)
        {
            this.hubContext = hubContext;
        }

        public void SendToHub<T>(T arg, string user)
        {
            hubContext.Clients.Client(user).AddProgress(arg);
        }

    }
}
