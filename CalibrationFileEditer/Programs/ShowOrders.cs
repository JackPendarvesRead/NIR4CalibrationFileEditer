using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace CalibrationFileEditer
{
    class ShowOrders : IPrograms
    {
        public string GetName()
        {
            return ("Show order of parameters");
        }

        public void RunProgram(DataProvider provider)
        {
            var file = provider.GetData();
            var regex = new RegexSearches();
            var findParameters = new Regex(regex.findParameterGroups);
            var parameters = findParameters.Matches(file);

            var order = parameters.Cast<Match>().OrderBy(x => int.Parse(x.Groups[4].Value));

            parameters.Cast<string>();
            
            foreach(var o in order)
            {
                //Console.WriteLine($"{o.Groups[4]} : {o.Groups[2]}");
                Console.WriteLine("{0,-5}{1,-10}", o.Groups[4], o.Groups[2]);
            }
        }
        private class ParameterDetails
        {
            public int Order { get; set; }
            public string Label { get; set; }
        }
    }
}
