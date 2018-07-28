using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vueling.Common.Layer
{
    public class PathManager
    {
        public string FilePath { get; set; }

        public string FileExtension { get; set; }

        public PathManager(string fileExtension)
        {
            FileExtension = fileExtension;
            FilePath = "C:/Users/G1/source/repos/Vueling.Exam/" + FileExtension;
        }
        public void CreateFile()
        {
            if (!FileExist())
                using (StreamWriter file = new StreamWriter(FilePath, true)) { }
        }
        public bool FileExist()
        {
            return File.Exists(FilePath);
        }
        public string GetJsonData()
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
