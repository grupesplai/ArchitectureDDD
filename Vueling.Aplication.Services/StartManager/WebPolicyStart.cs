﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vueling.Aplication.Services.Services;
using Vueling.Common.Entity;
using Vueling.Common.Layer;

namespace Vueling.Aplication.Services.StartManager
{
    public class WebPolicyStart
    {
        public static bool StartMethod()
        {
            var listPolicies = HttpPolicyServices.GetCall();
            var service = new PoliciesService();
            foreach (Policies p in listPolicies)
            {
                service.Add(p);
            }
            return true;
        }

        public static bool Refresh()
        {
            try
            {
                var clients = HttpClientServices.GetCall();
                var service = new ClientServices();
                var stored = service.GetAll();
                bool hasChanged = !clients.SequenceEqual(stored);
                if (hasChanged)
                {
                    //service.Clear();
                    foreach (Clients client in clients)
                    {
                        service.Add(client);
                    }
                }
                return true;
            }
            catch (VuelingException ex)
            {
                throw new VuelingException("Error al obtener datos de la Web API remota.", ex.InnerException);
            }
        }
    }
}
