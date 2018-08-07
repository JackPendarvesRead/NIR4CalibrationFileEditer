using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ExponentialStringManipulation
{
    class ZeroLogic
    {
        internal string PositiveExponentialConvert(Match match, int power)
        {
            var sb = new StringBuilder();
            sb.Append(match.Groups[1]);
            sb.Append(match.Groups[2]);
            sb.Append(".");
            sb.Append(match.Groups[3]);
            return sb.ToString();
        }
    }
}
