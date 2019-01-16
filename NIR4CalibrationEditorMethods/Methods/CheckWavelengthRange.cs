using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using NIR4CalibrationEditorMethods.Domain;

namespace NIR4CalibrationEditorMethods.Methods
{
    public class CheckWavelengthRange : IMethod
    {
        private readonly int minimumWavelength;
        private readonly int maximumWavelength;

        public CheckWavelengthRange(int minimumWavelength, int maximumWavelength)
        {
            this.minimumWavelength = minimumWavelength;
            this.maximumWavelength = maximumWavelength;
        }

        public void Run(DataProvider dataProvider)
        {
            var data = dataProvider.GetData();
            var matches = RegularExpressions.findMinMaxWavelengths.Matches(data);
            foreach(Match match in matches)
            {
                var minmax = match.Groups["minmax"].Value;
                var wavelength = Int32.Parse(match.Groups["wavelength"].Value);

                if(minmax == "min")
                {
                    if (wavelength != minimumWavelength)
                    {
                        throw new Exception("Minimum wavelength is incorrect in plsx file.");
                    };
                }
                if(minmax == "max")
                {
                    if (wavelength != maximumWavelength)
                    {
                        throw new Exception("Maximum wavelength is incorrect in plsx file.");
                    };
                }
            }   
        }
    }
}
