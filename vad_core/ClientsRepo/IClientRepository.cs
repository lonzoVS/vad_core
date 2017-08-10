using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vad_core.Models;

namespace vad_core.ClientsRepo
{
    public interface IClientRepository : IEnumerable<KeyValuePair<string, Client>>
    {
        void AddClient(string info, Client client);
        void DeleteClient(Client client);
        string GetId(string ip);
        string GetName(string ip);
        
    }
}
