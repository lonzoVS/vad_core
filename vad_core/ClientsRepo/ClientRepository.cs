using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vad_core.Models;

namespace vad_core.ClientsRepo
{
    public class ClientRepository : IClientRepository
    {
        private ConcurrentDictionary<Tuple<string, string>, Client> Clients { get; set; } = new ConcurrentDictionary<Tuple<string, string>, Client>();
        public IEnumerator<KeyValuePair<Tuple<string, string>, Client>> GetEnumerator()
        {
            return Clients.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public void AddClient(Tuple<string, string> info, Client client)
        {
            if (client != null)
                Clients.TryAdd(info, client);
        }

        public void DeleteClient(string clientId)
        {
            //add if 
            var item = Clients.First(kvp => kvp.Value.Id == clientId);
            ((IDictionary)Clients).Remove(item.Key);
        }
        //or I can just acces name or id through getenumarator.movenext cycle
        public string GetId(string ip, string hub)
        {
            return Clients[Tuple.Create(ip,hub)].Id;
            //return Clients[ip].Id;
        }
        public string GetName(string ip, string hub)
        {
            return Clients[Tuple.Create(ip, hub)].UserName;
        }

    }
}
