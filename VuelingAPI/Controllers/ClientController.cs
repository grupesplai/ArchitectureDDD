using System.Collections.Generic;
using System.Net;
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
        public ClientController() : 
            this(new ClientServices()) { }
        public ClientController(ClientServices ClientService)
        {
            iService = ClientService;
        }

        // GET: api/Client
        public IEnumerable<Clients> Get()
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

        // POST: api/Client
        public IHttpActionResult Post(Clients client)
        {
            if (!ModelState.IsValid)
            {
                Loggin.LogError(Resource0.BADREQ);
                return BadRequest(ModelState);
            }
            Clients clientReturned = null; 
            try
            {
                Loggin.LogTrace(Resource0.ADDCLI);
                clientReturned = iService.Add(client);
            }
            catch (VuelingException ex)
            {
                Loggin.LogError(ex.Message);

                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            return CreatedAtRoute("DefaultApi", new { client.id }, clientReturned);
        }
    }
}
