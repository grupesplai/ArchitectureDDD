using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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

        public Policies GetByID(string id)
        {
            try
            {
                return iRepository.GetByID(id);
            }
            catch (VuelingException ex)
            {
                throw new VuelingException("error en la capa servicio ", ex);
            }
        }

        public bool Remove(string id)
        {
            try
            {
                return iRepository.Remove(id);
            }
            catch (VuelingException ex)
            {
                throw new VuelingException("Eror en rove de la capa de servicios", ex);
            }
        }
    }
}
