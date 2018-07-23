using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vueling.Aplication.Interfaces;
using Vueling.Aplication.Services;
using Vueling.Common.Entity;
using Vueling.Common.Layer;

namespace VuelingAPI.Controllers
{
    public class PoliciesController : ApiController
    {
        public readonly IService<Policies> iService = new PoliciesService();
        public PoliciesController() : this(new PoliciesService()) { }
        public PoliciesController(PoliciesService service)
        {
            iService = service;
        }

        // GET: api/policies
        public IEnumerable<Policies> Get()
        {
            Loggin.LogTrace(Resource0.INFO);
            return iService.GetAll();
        }

        // POST: api/policies
        public IHttpActionResult Post(Policies policy)
        {
            if (!ModelState.IsValid)
            {
                Loggin.LogError(Resource0.BADREQ);
                return BadRequest(ModelState);
            }
            try
            {
                //Loggin.LogTrace(Resource0.ADDCLI);
                iService.Add(policy);
            }
            catch (VuelingException ex)
            {
                Loggin.LogError(ex.Message);

                throw;
            }
            return CreatedAtRoute("DefaultApi", new { policy.id }, policy);
        }
    }
}
