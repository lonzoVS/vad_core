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

        public void Add(string ip, Client client)
        {
            clients.AddClient(ip, client);
        }

        public void Delete(Client client)
        {
            clients.DeleteClient(client);
        }
    }
}
