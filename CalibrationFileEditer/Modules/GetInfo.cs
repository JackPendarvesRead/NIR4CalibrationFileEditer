using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CalibrationFileEditer
{
    public class GetInfo : IModule
    {
        public string GetName()
        {
            var name = "Get parameter information (order, unit, label...)";
            return (name);
        }

        public void RunProgram(DataProvider provider)
        {
            var file = provider.GetData();
            var regex = new RegexSearches();
            var findParameterGroups = new Regex(regex.findParameterGroups);
            var matches = findParameterGroups.Matches(file);
            
            //groups: 1=tolerance, 2=label, 3=unit, 4=order, 5=code
            Console.WriteLine($"{"Label",-15}{"Unit",-10}{"Order",-10}{"Code",-15}{"Tolerance",-10}");
            for (var i = 0; i < matches.Count; i++)
            {
                Console.WriteLine("{0,-15}{1,-10}{2,-10}{3,-15}{4,-10}", matches[i].Groups[2], matches[i].Groups[3], matches[i].Groups[4], matches[i].Groups[5], matches[i].Groups[1]);              
            }
        }
    }
}
