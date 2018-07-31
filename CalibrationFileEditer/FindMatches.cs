using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CalibrationFileEditer
{
    class FindMatches
    {
        public MatchCollection GetParameterList(DataProvider provider)
        {
            var file = provider.GetData();
            var regex = new RegexSearches();
            var findParameterGroups = new Regex(regex.findParameterGroups);
            var matches = findParameterGroups.Matches(file);
            return (matches);
        }
    }
}
