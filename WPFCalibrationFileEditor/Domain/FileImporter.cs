using NIR4CalibrationEditorMethods;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WPFCalibrationFileEditor.Domain
{
    public class FileImporter
    {
        public string[] GetFileStringArray(Stream stream)
        {
            using (var sr = new StreamReader(stream, Encoding.Default, true, 1024, true))
            {
                var linesList = new List<string>();
                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine();
                    linesList.Add(line);
                }
                stream.Seek(0, SeekOrigin.Begin);
                return linesList.ToArray<string>();
            }
        }

        public string GetFileString(Stream stream)
        {
            using (var sr = new StreamReader(stream, Encoding.Default, true, 1024, true))
            {
                var fileString = sr.ReadToEnd();
                stream.Seek(0, SeekOrigin.Begin);
                return fileString;
            }
        }

        public IEnumerable<NIR4Parameter> GetParameterList(Stream stream)
        {
            using (var sr = new StreamReader(stream, Encoding.Default, true, 1024, true))
            {
                List<NIR4Parameter> parameters = new List<NIR4Parameter>();
                Regex regex = RegularExpressions.findParameterGroups;
                while (!sr.EndOfStream)
                {
                    long streamStartReadPosition = stream.Position;
                    string line = sr.ReadLine();
                    if (regex.IsMatch(line))
                    {
                        var parameterGroups = regex.Match(line);
                        var nir4Parameter = new NIR4Parameter()
                        {
                            Tolerance = parameterGroups.Groups["tolerance"].Value,
                            Label = parameterGroups.Groups["label"].Value,
                            Order = parameterGroups.Groups["order"].Value,
                            Unit = parameterGroups.Groups["unit"].Value,
                            Code = parameterGroups.Groups["code"].Value
                        };
                        parameters.Add(nir4Parameter);
                    }
                }
                stream.Seek(0, SeekOrigin.Begin);
                return parameters;
            }           
        }
    }
}
