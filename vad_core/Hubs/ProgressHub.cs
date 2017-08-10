
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
        //public static ConcurrentDictionary<string, string> MyUsers = new ConcurrentDictionary<string, string>();

        public override Task OnConnected()
        {
            
            var ip = Context.Request.HttpContext.Connection.RemoteIpAddress.ToString();
            //MyUsers.TryAdd(ip, Context.ConnectionId);
            var clients = new ClientsRepoHelper(RepositoryIsolator.Of.Clients);
            clients.Add(ip, new Client(Context.ConnectionId, Context.User.Identity.Name));
            //string name = Context.User.Identity.Name;
            
            // Groups.Add(Context.ConnectionId, "lul" + j);

            return base.OnConnected();
        }
        public class MyUserType
        {
            public string ConnectionId { get; set; }
            public string UserName { get; set; }

        }
        //public void SendToHub<T>(T arg)
        //{
        //    //  var hubContext = connectionManager.GetHubContext<ProgressHub>();
        //    // hubContext.Clients.Client(hubContext.Clients.).AddProgress(arg);
        //    Clients.Client(Context.ConnectionId).AddProgress(arg);
        //}
    }
}
