using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFCalibrationFileEditor.Logic
{
    public class MyParamterConfig
    {
        public string Name { get; set; }
        public string FilePath { get; set; }
    }


    internal class ParameterConfigFinder
    {
        public IEnumerable<MyParamterConfig> Import()
        {
            var files = Directory.GetFiles(AppSettings.ConfigurationDirectory);
            var jsonFiles = from f in files
                            where Path.GetExtension(f) == ".json"
                            select f;
            foreach(var jsonFile in jsonFiles)
            {
                var config = new MyParamterConfig
                {
                    FilePath = jsonFile,
                    Name = Path.GetFileNameWithoutExtension(jsonFile)
                };
                yield return config;
            }
        }

    }
}
