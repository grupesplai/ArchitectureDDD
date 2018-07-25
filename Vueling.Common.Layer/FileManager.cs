using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vueling.Common.Layer
{
    public class FileManager
    {
        public string FilePath { get; set; }
     
        public string FileName { get; set; }
        
        public FileManager(string filename)
        {
            FileName = filename;
            FilePath = "C:/Users/G1/source/repos/Vueling.Exam/" + FileName;
        }
        
        public void CreateFile()
        {
            if (!FileExists())
            {
                    using (StreamWriter file = new StreamWriter(FilePath, true)) { }
            }
        }
        
        public bool FileExists()
        {
            return File.Exists(FilePath);
        }
        
        public string RetrieveData()
        {
                var jsonData = File.ReadAllText(FilePath);
                return jsonData;
           
        }
        public void WriteToFile(string fileData)
        {
                File.WriteAllText(FilePath, fileData);
        }
    }
}
