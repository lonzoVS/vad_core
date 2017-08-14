using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.SignalR.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vad_core.ClientsRepo;
using vad_core.Models;

namespace vad_core.Hubs
{
    [HubName("visualizationHub")]
    public class VisualizationHub : Hub
    {
        public override Task OnConnected()
        {
            //var ip = Context.Request.HttpContext.Connection.RemoteIpAddress.ToString();
            //var clients = new ClientsRepoHelper(RepositoryIsolator.Of.Clients);
            //clients.Add(Tuple.Create(ip, "visualization"), new Client(Context.ConnectionId, Context.User.Identity.Name));
            return base.OnConnected();
        }

        public override Task OnDisconnected(bool stopCalled)
        {
            //var clients = new ClientsRepoHelper(RepositoryIsolator.Of.Clients);
            //clients.Delete(Context.ConnectionId);
            return base.OnDisconnected(stopCalled);
        }

    }
}
