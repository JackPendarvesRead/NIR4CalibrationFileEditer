using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ExponentialStringManipulation
{
    class PositiveLogic
    {
        internal string PositiveExponentialConvert(Match match, int power)
        {
            //match.Groups[3] is the digits captured between decimal point and E
            var sb = new StringBuilder();
            if (power < match.Groups[3].Length)
            {
                string betweenDecimalAndE = match.Groups[3].Value;
                string beforeDecimal = betweenDecimalAndE.Substring(0, power);
                string afterDecimal = betweenDecimalAndE.Substring(power);

                sb.Append(match.Groups[1].Value);
                sb.Append(match.Groups[2].Value);
                sb.Append(beforeDecimal);
                sb.Append(".");
                sb.Append(afterDecimal);
                return sb.ToString();
            }
            else
            {
                int numberOfZeroes = power - match.Groups[3].Length;
                sb.Append(match.Groups[1].Value);
                sb.Append(match.Groups[2].Value);
                sb.Append(match.Groups[3].Value);
                for (var i = 0; i < numberOfZeroes; i++)
                {
                    sb.Append("0");
                }
                return sb.ToString();
            }
        }
    }
}
