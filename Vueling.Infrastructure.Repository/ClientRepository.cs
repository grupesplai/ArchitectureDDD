using System;
using Vueling.Infrastructure.Interfaces;
using Vueling.Common.Layer;
using System.Collections.Generic;
using Vueling.Common.Entity;
using Newtonsoft.Json;
using System.IO;

namespace Vueling.Infrastructure.Repository
{
    public class ClientRepository : IRepository<Clients>
    {
        private FileManager fileManager;
        public ClientRepository()
        {

            fileManager = new FileManager("Clients.json");
            fileManager.CreateFile();
        }


        public Clients Add(Clients model)
        {
            List<Clients> jsonList;

                var jsondata = fileManager.RetrieveData();
                jsonList = JsonConvert.DeserializeObject<List<Clients>>(jsondata);
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
            var jsondata = fileManager.RetrieveData();
            return JsonConvert.DeserializeObject<List<Clients>>(jsondata);
        }

        public Clients GetByID(string id)
        {
            try
            {
                var jsondata = fileManager.RetrieveData();
                List<Clients> clientList = JsonConvert.DeserializeObject<List<Clients>>(jsondata);
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
                var jsondata = fileManager.RetrieveData();
                jsonList = JsonConvert.DeserializeObject<List<Clients>>(jsondata);
                if (jsonList == null)
                {
                    jsonList = new List<Clients>();
                }
                Clients client = jsonList.Find(x => x.id == id);
                jsonList.Remove(client);

                var resultJSONList = JsonConvert.SerializeObject(jsonList, Formatting.Indented);
                fileManager.WriteToFile(resultJSONList);
                return true;
            }
            catch (VuelingException ex)
            {
                throw new VuelingException("error en la capa repository", ex);
            }
        }





        public static void GetJson(List<Clients> lista)
        {
            string path = AppSet.AppTxts(Resource2.PATHC);
            List<Clients> listaAlumno = FileExists(lista, path);
            string alumJson = JsonConvert.SerializeObject(listaAlumno, Formatting.Indented);

            using (StreamWriter sw = File.CreateText(path))
                sw.WriteLine(alumJson);

            string json = File.ReadAllText(path);
            var files = JsonConvert.DeserializeObject<List<Clients>>(json);
        }
        public static List<Clients> FileExists(List<Clients> alumnos, string path)
        {
            StreamReader sr = null;
            try
            {
                if (File.Exists(path))
                {
                    using (sr = new StreamReader(path))
                    {
                        string read = sr.ReadToEnd();
                        alumnos = JsonConvert.DeserializeObject<List<Clients>>(read);
                    }
                }
            }
            catch (Exception e) { throw e; }
            return alumnos;
        }
    }
}
