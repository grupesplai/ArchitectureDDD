using System;
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

        // GET: api/Clients/5
        public IHttpActionResult Get(string id)
        {
            try
            {
                Clients client = iService.GetByID(id);
                return Ok(client);
            }
            catch (VuelingException)
            {
                return NotFound();
            }
        }


        // DELETE: api/Clients/5
        public IHttpActionResult Delete(string id)
        {
            Clients client;
            try
            {
                client = iService.GetByID(id);
                iService.Remove(client.id);
                return Ok(client);
            }
            catch (InvalidOperationException)
            {
                return NotFound();
            }
            catch (VuelingException)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
        }
    }
}
