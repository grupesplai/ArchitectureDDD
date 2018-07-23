using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using Vueling.Common.Entity;
using Vueling.Common.Layer;
using Vueling.Infrastructure.Interfaces;

namespace Vueling.Infrastructure.Repository
{
    public class PoliciesRepository : IRepository<Policies>
    {
        public Policies Add(Policies model)
        {
            throw new NotImplementedException();
        }

        public void GetAll(List<Policies> list)
        {
            GetJson(list);
        }

        public static void GetJson(List<Policies> list)
        {

            string path = AppSet.AppTxts(Resource2.PATHP);
            List<Policies> listaAlumno = FileExists(list, path);
            string alumJson = JsonConvert.SerializeObject(listaAlumno, Formatting.Indented);
            
            using (StreamWriter sw = File.CreateText(path))
                sw.WriteLine(alumJson);


            //desearializa el json creado
            string json = File.ReadAllText(path);
            var files = JsonConvert.DeserializeObject<List<Policies>>(json);
        }
        public static List<Policies> FileExists(List<Policies> alumnos, string path)
        {
            StreamReader sr = null;
            try
            {
                if (File.Exists(path))
                {
                    using (sr = new StreamReader(path))
                    {
                        string read = sr.ReadToEnd();
                        alumnos = JsonConvert.DeserializeObject<List<Policies>>(read);
                    }
                }
            }
            catch (Exception e) { throw e; }
            return alumnos;
        }
    }
}
