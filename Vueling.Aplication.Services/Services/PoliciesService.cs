using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Vueling.Aplication.Interfaces;
using Vueling.Common.Entity;
using Vueling.Common.Layer;
using Vueling.Infrastructure.Interfaces;
using Vueling.Infrastructure.Repository;

namespace Vueling.Aplication.Services
{
    public class PoliciesService : IService<Policies>
    {
        private readonly IRepository<Policies> iRepository;
        public PoliciesService() : this(new PoliciesRepository())
        { }

        public PoliciesService(PoliciesRepository policyRepository)
        {
            this.iRepository = policyRepository;
        }

        public Policies Add(Policies policy)
        {
            return iRepository.Add(policy);
        }
        
        public List<Policies> GetAll()
        {
            return iRepository.GetAll(); ;
        }

        
    }
}
