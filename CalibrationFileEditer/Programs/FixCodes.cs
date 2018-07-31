using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace CalibrationFileEditer
{
    class FixCodes : IPrograms
    {
        public string GetName()
        {
            var name = "Change ODM/TDM codes to DM.";
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
                if (matches[i].Groups[5].Value == "TDM" || matches[i].Groups[5].Value == "ODM")
                {
                    Console.WriteLine($"Changing {matches[i].Groups[5].Value} to DM");
                    var replaced = matches[i].ToString().Replace(matches[i].Groups[5].Value, "DM");                   

                    file = file.Replace(matches[i].ToString(), replaced);                    
                    provider.SetData(file);
                }
            }
            Console.WriteLine("Done.");
        }
    }
}
