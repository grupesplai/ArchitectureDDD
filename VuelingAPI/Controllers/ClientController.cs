using System.Collections.Generic;
using System.Web.Http;
using Vueling.Aplication.Interfaces;
using Vueling.Aplication.Services;
using Vueling.Common.Entity;
using Vueling.Common.Layer;

namespace VuelingAPI.Controllers
{
    public class ClientController : ApiController
    {
        public readonly IService<Clients> iService = new ClientServices();
        public ClientController() : this(new ClientServices()) { }
        public ClientController(ClientServices service)
        {
            iService = service;
        }

        // GET: api/Client
        public IEnumerable<Clients> Get()
        {
            Loggin.LogTrace(Resource0.INFO);
            return iService.GetAll();
        }

        // POST: api/Client
        public IHttpActionResult Post(Clients client)
        {
            if (!ModelState.IsValid)
            {
                Loggin.LogError(Resource0.BADREQ);
                return BadRequest(ModelState);
            }
            try
            {
                Loggin.LogTrace(Resource0.ADDCLI);
                iService.Add(client);
            }
            catch (VuelingException ex)
            {
                Loggin.LogError(ex.Message);

                throw;
            }
            return CreatedAtRoute("DefaultApi", new { client.id }, client);
        }
    }
}
