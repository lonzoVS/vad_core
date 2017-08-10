using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace vad_core.ClientsRepo
{
    public class RepositoryIsolator
    {
        public static RepositoryIsolator Of { get; } =
              new RepositoryIsolator() { Clients = new ClientRepository() };

        public IClientRepository Clients { get; private set; }
    }
}
