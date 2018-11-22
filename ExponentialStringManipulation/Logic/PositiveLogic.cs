using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ExponentialStringManipulation.Logic
{
    class PositiveLogic
    {
        internal string PositiveExponentialConvert(Match match, int power)
        {
            var sb = new StringBuilder();
            if (power < match.Groups["afterDecimal"].Length)
            {
                var newBeforeDecimal = match.Groups["afterDecimal"].Value.Substring(0, power);
                var newAfterDecimal = match.Groups["afterDecimal"].Value.Substring(power);

                sb.Append(match.Groups["negative"].Value);
                sb.Append(match.Groups["beforeDecimal"].Value);
                sb.Append(newBeforeDecimal);
                sb.Append(".");
                sb.Append(newAfterDecimal);
                return sb.ToString();
            }
            else
            {
                var numberOfZeroes = power - match.Groups["afterDecimal"].Length;
                sb.Append(match.Groups["negative"].Value);
                sb.Append(match.Groups["beforeDecimal"].Value);
                sb.Append(match.Groups["afterDecimal"].Value);
                for (var i = 0; i < numberOfZeroes; i++)
                {
                    sb.Append("0");
                }
                return sb.ToString();
            }
        }
    }
}
