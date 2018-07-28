using System;
using Vueling.Infrastructure.Interfaces;
using Vueling.Common.Layer;
using System.Collections.Generic;
using Vueling.Common.Entity;

using System.IO;

namespace Vueling.Infrastructure.Repository
{
    public class ClientRepository : IRepository<Clients>
    {
        private PathManager pathManager;
        public ClientRepository()
        {

            pathManager = new PathManager("Clients.json");
            pathManager.CreateFile();
        }
        public static void MakeJsonFile(List<Clients> list)
        {
            string path = AppSet.AppTxts("pathC");
            if (!File.Exists(path))
            {
                string alumJson = JsonUtilities<Clients>.ToSerializeObject(list);
                using (StreamWriter sw = File.CreateText(path))
                    sw.WriteLine(alumJson);
              }
        }

        public Clients Add(Clients model)
        {
            List<Clients> jsonList;

                var jsonData = pathManager.GetJsonData();
                jsonList = JsonUtilities<Clients>.ToDeserialize(jsonData);
                if (jsonList == null)
                {
                    jsonList = new List<Clients>();
                }
                jsonList.Add(model);
                Clients objectFound = jsonList.Find(x => x.Equals(model));
                
                return objectFound;
        }
        
        public List<Clients> GetAll()
        {
            var jsonData = pathManager.GetJsonData();
            return JsonUtilities<Clients>.ToDeserialize(jsonData);
        }
        
        public Clients GetByID(string id)
        {
            try
            {
                var jsonData = pathManager.GetJsonData();
                List<Clients> clientList = JsonUtilities<Clients>.ToDeserialize(jsonData);
                Clients clientObj = clientList.Find(x => x.id == id);
                return clientObj;
            }
            catch (VuelingException ex)
            {
                throw new VuelingException("Error al desarilizar", ex);
            }
        }

        public bool Remove(string id)
        {
            List<Clients> jsonList;
            try
            {
                string jsonData = pathManager.GetJsonData();
                jsonList = JsonUtilities<Clients>.ToDeserialize(jsonData);
                if (jsonList == null)
                {
                    jsonList = new List<Clients>();
                }
                Clients client = jsonList.Find(x => x.id == id);
                jsonList.Remove(client);

                var resultJSONList = JsonUtilities<Clients>.ToSerializeObject(jsonList);
                pathManager.WriteToFile(resultJSONList);
                return true;
            }
            catch (VuelingException ex)
            {
                throw new VuelingException("error en la capa repository", ex);
            }
        }





        
    }
}
