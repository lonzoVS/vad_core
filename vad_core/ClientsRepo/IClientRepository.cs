using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vad_core.Models;

namespace vad_core.ClientsRepo
{
    public interface IClientRepository : IEnumerable<KeyValuePair<Tuple<string, string>, Client>>
    {
        void AddClient(Tuple<string, string> info, Client client);
        void DeleteClient(string client);
        string GetId(string ip, string hub);
        string GetName(string ip, string hub);
        
    }
}
