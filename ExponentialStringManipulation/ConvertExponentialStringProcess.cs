using ExponentialStringManipulation.Logic;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ExponentialStringManipulation
{
    public class ConvertExponentialStringProcess
    {
        private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public string Convert(string input)
        {               
            try
            {
                var match = RegularExpressions.CaptureExponential.Match(input);
                var power = Int32.Parse(match.Groups["power"].Value);
                if (power < 0)
                {
                    return new NegativeLogic().NegativeExponentialConvert(match, power);
                }
                if (power > 0)
                {
                    return new PositiveLogic().PositiveExponentialConvert(match, power);
                }
                if (power == 0)
                {
                    return new ZeroLogic().PositiveExponentialConvert(match, power);
                }
                throw new Exception("");
            }
            catch (Exception)
            {
                throw new Exception("Error occurred in ConvertExponential. Power logic failed.");
            }
            
        }
    }
}
