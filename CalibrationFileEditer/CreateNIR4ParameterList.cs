using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CalibrationFileEditer.Programs
{
    public class CreateNIR4ParameterList
    {
        public List<NIR4Parameter> GetParameters(DataProvider provider)
        {
            var file = provider.GetData();
            var regex = new RegexSearches();
            var findParameterGroups = new Regex(regex.findParameterGroups);
            var matches = findParameterGroups.Matches(file);

            var parameterList = new List<NIR4Parameter>();
            for(var i = 0; i < matches.Count; i++)
            {
                //groups: 1=tolerance, 2=label, 3=unit, 4=order, 5=code
                var parameter = new NIR4Parameter();
                parameter.tolerence = matches[i].Groups[1].Value;
                parameter.label = matches[i].Groups[2].Value;
                parameter.unit = matches[i].Groups[3].Value;
                parameter.order = matches[i].Groups[4].Value;
                parameter.code = matches[i].Groups[5].Value;

                parameterList.Add(parameter);
            }

            return (parameterList);
        }
    }
}
