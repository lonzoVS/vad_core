
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.SignalR.Hubs;
using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Http;
using vad_core.ClientsRepo;
using vad_core.Models;

namespace vad_core.Hubs
{
    [HubName("progressHub")]
    public class ProgressHub : Hub
    {
       

        public override Task OnConnected()
        {
            var ip = Context.Request.HttpContext.Connection.RemoteIpAddress.ToString();
            var clients = new ClientsRepoHelper(RepositoryIsolator.Of.Clients);
            clients.Add(Tuple.Create(ip,"progress"), new Client(Context.ConnectionId, Context.User.Identity.Name));
            System.Diagnostics.Debug.WriteLine(clients.Count());
            return base.OnConnected();
        }
        //I'm not sure this is going to work in the same browser with two tabs in deploy, need to test it.
        public override Task OnDisconnected(bool stopCalled)
        {
            var clients = new ClientsRepoHelper(RepositoryIsolator.Of.Clients);
            clients.Delete(Context.ConnectionId);
            System.Diagnostics.Debug.WriteLine(clients.Count());
            return base.OnDisconnected(stopCalled);
        }
  
        public override Task OnReconnected()
        {
            return base.OnReconnected();
        }

    }
}
