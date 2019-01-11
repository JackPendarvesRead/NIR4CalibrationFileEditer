using NIR4CalibrationEditorMethods.Domain;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace WPFCalibrationFileEditor.Domain
{
    public class NIR4Parameter
    {
        public string Code { get; set; }
        public string Label { get; set; }
        public string Unit { get; set; }
        public string Order { get; set; }
        public string Tolerance { get; set; }

        public IEnumerable<NIR4Parameter> GetParameters(DataProvider data)
        {
            var file = data.GetData();
            var parameterList = new List<NIR4Parameter>();
            var parameters = RegularExpressions.findParameterGroups.Matches(file);

            foreach(Match parameterMatch in parameters)
            {
                var parameter = new NIR4Parameter()
                {
                    Code = parameterMatch.Groups["code"].Value,
                    Label = parameterMatch.Groups["label"].Value,
                    Unit = parameterMatch.Groups["unit"].Value,
                    Order = parameterMatch.Groups["order"].Value,
                    Tolerance = parameterMatch.Groups["tolerance"].Value
                };
                parameterList.Add(parameter);
            }   
            return parameterList;            
        }
    }
}
