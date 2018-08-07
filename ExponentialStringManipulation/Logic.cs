using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ExponentialStringManipulation
{
    public class Logic
    {
        //Method uses regex groups and string manipulation
        //Regex groups are as follows: 1=negative sign, 2=digits in front of decimal point, 3=digits between decimal point and E, 4=exponentialvalue including +/- sign
        public string ConvertExponential(string input)
        {   
            var regex = new Regex("^(-?)([0-9])\\.([0-9]+)E([+-][0-9]{1,2}$)");
            if (string.IsNullOrWhiteSpace(input)||!regex.IsMatch(input))
            {
                throw new Exception("Regex not matched. Input in wrong format.");
            }
            var match = regex.Match(input);
            int power = Int32.Parse(match.Groups[4].Value);
            var sb = new StringBuilder();
            
            if (power < 0)
            {
                var negativeLogic = new NegativeLogic();
                return negativeLogic.NegativeExponentialConvert(match, power);
            }
            if (power > 0)
            {
                var positiveLogic = new PositiveLogic();
                return positiveLogic.PositiveExponentialConvert(match, power);
            }
            if (power == 0)
            {
                var zeroLogic = new ZeroLogic();
                zeroLogic.PositiveExponentialConvert(match, power);
            }

            throw new Exception("Error occurred in ConvertExponential. Power logic failed.");
        }
    }
}
