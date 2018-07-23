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
        public Clients Add(Clients model)
        {
            throw new NotImplementedException();
        }

        public void GetAll(List<Clients> list)
        {
            throw new NotImplementedException();
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
