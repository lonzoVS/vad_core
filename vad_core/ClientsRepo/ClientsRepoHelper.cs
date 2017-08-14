using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vad_core.Models;

namespace vad_core.ClientsRepo
{
    //this class exists only for a DI
    public class ClientsRepoHelper
    {
        private readonly IClientRepository clients;

        public ClientsRepoHelper(IClientRepository clients)
        {
            this.clients = clients;
        }

        public void Add(Tuple<string, string> info, Client client)
        {
            clients.AddClient(info, client);
        }

        public void Delete(string clientInfo)
        {
            clients.DeleteClient(clientInfo);
        }

        public int Count()
        {
            return clients.Count();
          
        }
   
    }
}
