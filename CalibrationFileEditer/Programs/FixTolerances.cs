using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CalibrationFileEditer
{
    class FixTolerances : IPrograms
    {
        public string GetName()
        {
            var name = "Fix tolerances";
            return (name);
        }

        public void RunProgram(DataProvider provider)
        {
            var file = provider.GetData();
            var regex = new RegexSearches();
            var findParameterGroups = new Regex(regex.findParameterGroups);
            var matches = findParameterGroups.Matches(file);

            var replaceMatches = new List<string>();
            for (var i = 0; i < matches.Count; i++)
            {
                //groups: 1=tolerance, 2=label, 3=unit, 4=order, 5=code
                if (matches[i].Groups[3].Value == "g/kg" && double.Parse(matches[i].Groups[1].Value)<10)
                {
                    Console.WriteLine($"Changing tolerance for {matches[i].Groups[5].Value}");
                    double multiply = double.Parse(matches[i].Groups[1].Value)*10;
                    var replaced = matches[i].ToString().Replace(matches[i].Groups[1].ToString(), multiply.ToString());
                    replaceMatches.Add(replaced);
                }
                else
                {
                    replaceMatches.Add(matches[i].ToString());
                }
            }

            for(var i = 0; i < replaceMatches.Count; i++)
            {
                file = file.Replace(matches[i].ToString(), replaceMatches[i]);
            }
            provider.SetData(file);
            Console.WriteLine("Done.");
        }
    }
}
