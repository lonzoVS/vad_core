﻿using System;
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
        private ConcurrentDictionary<string, Client> Clients { get; set; } = new ConcurrentDictionary<string, Client>();
        public IEnumerator<KeyValuePair<string, Client>> GetEnumerator()
        {
            return Clients.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public void AddClient(string info, Client client)
        {
            if (client != null) Clients.TryAdd(info, client);
        }

        public void DeleteClient(Client client)
        {
            //implement delete
        }
        //or I can just acces name or id with enumarator.movenext cycle
        public string GetId(string ip)
        {
            return Clients[ip].Id;
        }
        public string GetName(string ip)
        {
            return Clients[ip].UserName;
        }
    }
}
