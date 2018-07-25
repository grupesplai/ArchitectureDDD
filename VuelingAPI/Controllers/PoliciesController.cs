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
        public PoliciesController(PoliciesService policyService)
        {
            iService = policyService;
        }

        // GET: api/policies
        public IEnumerable<Policies> Get()
        {
            try
            {
                Loggin.LogTrace(Resource0.INFO);
                return iService.GetAll();
            }
            catch (VuelingException)
            {
                throw new HttpResponseException(HttpStatusCode.NoContent);
            }
        }

        // POST: api/policies
        public IHttpActionResult Post(Policies policy)
        {
            if (!ModelState.IsValid)
            {
                Loggin.LogError(Resource0.BADREQ);
                return BadRequest(ModelState);
            }
            Policies policyRetruned = null;
            try
            {
                Loggin.LogTrace(Resource0.ADDCLI);
                policyRetruned = iService.Add(policy);
            }
            catch (VuelingException)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            return CreatedAtRoute("DefaultApi", new { policy.id }, policyRetruned);
        }
    }
}
