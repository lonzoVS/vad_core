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
    public class ProgressBarFunction
    {
        private IHubContext hubContext;

        public ProgressBarFunction(IHubContext hubContext)
        {
            this.hubContext = hubContext;
        }

        public void SendToHubClient<T>(T arg, string user)
        {
              //var conId = con.Select(s => s.Key).Where(s => s == "lul1");
           // var hubContext = connectionManager.GetHubContext<ProgressHub>();
            //need to add map for clients wiht id and somethings else(ip maybe) to send to a caller not to all(singleton ???) retarded.
            hubContext.Clients.Client(user).AddProgress(arg);
        }

    }
}
