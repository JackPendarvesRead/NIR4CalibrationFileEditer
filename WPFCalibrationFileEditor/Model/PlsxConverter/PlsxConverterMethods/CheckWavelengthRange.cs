using System;
using System.Text.RegularExpressions;
using WPFCalibrationFileEditor.Model;
using WPFCalibrationFileEditor.Model.PlsxConverter;

namespace WPFCalibrationFileEditor.PlsxConverter.PlsxConverterMethods
{
    public class CheckWavelengthRange : IMethod
    {
        private readonly int minimumWavelength;
        private readonly int maximumWavelength;

        /// <summary>
        /// Instantiate class to check wavelength range in plsx file is correct.
        /// </summary>
        /// <param name="minimumWavelength"></param>
        /// <param name="maximumWavelength"></param>
        public CheckWavelengthRange(int minimumWavelength, int maximumWavelength)
        {
            this.minimumWavelength = minimumWavelength;
            this.maximumWavelength = maximumWavelength;
        }

        /// <summary>
        /// Instantiate class to check wavelength range in plsx file is correct with default values.
        /// </summary>
        public CheckWavelengthRange()
        {
            this.minimumWavelength = AppSettings.MinimumWavelength;
            this.maximumWavelength = AppSettings.MaximumWavelength;
        }

        /// <summary>
        /// Checks wavelength ranges in plsx file is consistent with set maximum/minimum values.
        /// </summary>
        /// <param name="dataProvider"></param>
        public void Run(DataProvider dataProvider)
        {
            var data = dataProvider.GetData();
            var matches = RegularExpressions.findMinMaxWavelengths.Matches(data);
            foreach(Match match in matches)
            {
                CheckRange(match);
            }
        }

        private void CheckRange(Match match)
        {
            var minmax = match.Groups["minmax"].Value;
            var wavelength = Int32.Parse(match.Groups["wavelength"].Value);
            if (minmax == "min")
            {
                if (wavelength != minimumWavelength)
                {
                    throw new Exception("Minimum wavelength is incorrect in plsx file.");
                };
            }
            if (minmax == "max")
            {
                if (wavelength != maximumWavelength)
                {
                    throw new Exception("Maximum wavelength is incorrect in plsx file.");
                };
            }
        }
    }
}
