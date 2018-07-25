using Vueling.Common.Entity;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Vueling.Aplication.Interfaces;
using System.Net.Http.Headers;
using System.Data;
using System.Configuration;
using Vueling.Common.Layer;
using Vueling.Aplication.Services.Manager;
using Vueling.Infrastructure.Interfaces;
using Vueling.Infrastructure.Repository;
using System;
using System.Linq;

namespace Vueling.Aplication.Services
{
    public class ClientServices : IService<Clients>
    {
        private readonly IRepository<Clients> iRepository;

        public ClientServices() : this(new ClientRepository())
        { }

        public ClientServices(ClientRepository clientRepository)
        {
            this.iRepository = clientRepository;
        }

        public Clients Add(Clients client)
        {
            return iRepository.Add(client);
        }

        public List<Clients> GetAll()
       {
            return iRepository.GetAll();
        }
    }
}