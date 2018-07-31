using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using Vueling.Aplication.Interfaces;
using Vueling.Aplication.Services;
using Vueling.Common.Entity;
using Vueling.Common.Layer;
using Vueling.Common.Layer.Log4net;

namespace VuelingAPI.Controllers
{
    public class ClientController : ApiController
    {
        private readonly ILogger Log;
        public readonly IService<Clients> iService;

        public ClientController() :
            this(new ClientServices())
        { }
        public ClientController(/*ILogger Log,*/ ClientServices clientService)

        {
            //this.Log = Log;
            iService = clientService;
        }



        // GET: api/Client
        public IEnumerable<Clients> Get()
        {
            try
            {
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
                Log.Debug(Resource0.BADREQ);
                return BadRequest(ModelState);
            }
            Clients clientReturned = null; 
            try
            {
                Log.Error(Resource0.ADDCLI);
                clientReturned = iService.Add(client);
            }
            catch (VuelingException)
            {
                //Loggin.LogError(ex.Message);/
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
