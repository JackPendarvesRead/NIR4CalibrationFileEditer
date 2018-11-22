using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ExponentialStringManipulation
{
    static class RegularExpressions
    {
        //regular expression finds numbers written in scientific format e.g. 1.06E+05
         public static Regex CaptureExponential => new Regex(@"^
                                                            (?<negative>-?)
                                                            (?<beforeDecimal>[0-9])
                                                            \.
                                                            (?<afterDecimal>[0-9]+)
                                                            [eE]
                                                            (?<power>[+-][0-9]{1,2})
                                                            $", RegexOptions.IgnorePatternWhitespace);
    }
}
