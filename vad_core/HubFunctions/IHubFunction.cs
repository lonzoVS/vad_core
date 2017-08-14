using Microsoft.AspNetCore.SignalR.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace vad_core.HubFunctions
{
    public interface IHubFunction
    {
        void SendToHub<T>(T arg, string clientInfo);
    }
}
