using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CalibrationFileEditer
{
    class RegexSearches
    {        
        //example parameter line = <parameter tolerance="2.5" label="Dry Matter" unit=" % " order="0">DM</parameter> 
        //groups: 1=tolerance, 2=label, 3=unit, 4=order, 5=code
        public string findParameterGroups = "<parameter tol[^\"]+\"([^\"]+)\"[^\"]+\"([^\"]+)\"[^\"]+\"([^\"]*)\"[^\"]+\"([^\"]+)\">([^<]+)<[^>]+>";
        public string findExponential = @"-?[0-9]\.[0-9]+E-[0-9]+";
    }
}
