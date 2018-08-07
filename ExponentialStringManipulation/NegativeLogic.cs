using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ExponentialStringManipulation
{
    class NegativeLogic
    {
        internal string NegativeExponentialConvert(Match match, int power)
        {
            var sb = new StringBuilder();
            int numberOfZeroes = power*-1;
            sb.Append(match.Groups[1].Value);
            sb.Append("0.");
            for (var i = 0; i < numberOfZeroes - 1; i++)
            {
                sb.Append("0");
            }
            sb.Append(match.Groups[2].Value);
            sb.Append(match.Groups[3].Value);
            return sb.ToString();
        }
    }
}
