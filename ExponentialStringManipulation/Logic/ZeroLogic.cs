using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ExponentialStringManipulation.Logic
{
    class ZeroLogic
    {
        internal string PositiveExponentialConvert(Match match, int power)
        {
            var sb = new StringBuilder();
            sb.Append(match.Groups["negative"]);
            sb.Append(match.Groups["beforeDecimal"]);
            sb.Append(".");
            sb.Append(match.Groups["afterDecimal"]);
            return sb.ToString();
        }
    }
}
