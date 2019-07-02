using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WPFCalibrationFileEditor.Logic.PlsxConverter.PlsxConverterMethods
{
    public class CheckResolution : IMethod
    {
        private readonly int expectedResolution;

        public CheckResolution(int expectedResolution)
        {
            this.expectedResolution = expectedResolution;
        }

        public CheckResolution()
        {
            this.expectedResolution = AppSettings.Resolution;
        }

        public void Run(DataProvider dataProvider)
        {
            var resolutions = RegularExpressions.findResolution.Matches(dataProvider.GetData());
            foreach(Match resolution in resolutions)
            {
                var value = Int32.Parse(resolution.Groups[1].Value);

                if(value != expectedResolution)
                {
                    throw new Exception("Unexpected resolution!");
                }
            }
        }
    }
}
