using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace vad_core.Models
{
    public class Client
    {
        public Client(string id, string userName)
        {
            this.Id = id;
            this.UserName = userName;
        }

        public string Id { get; private set; }
        public string UserName { get; private set; }

        public override string ToString()
        {
            return $"{Id} -> {UserName}";
        }
    }
}
