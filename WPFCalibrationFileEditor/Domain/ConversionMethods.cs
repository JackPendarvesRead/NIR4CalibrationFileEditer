using NIR4CalibrationEditorMethods.Domain;
using NIR4CalibrationEditorMethods.Methods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFCalibrationFileEditor.Domain
{
    public class ConversionMethods
    {
        private readonly IEnumerable<ReplaceEmptyParametersConfig> config;

        public ConversionMethods(IEnumerable<ReplaceEmptyParametersConfig> config)
        {
            this.config = config;
        }

        public IEnumerable<IMethod> GetStandardMethods()
        {
            var methods = new List<IMethod>()
            {
                new ReplaceEmptyParameters(config),
                new RemoveExponentials(),
                new CheckWavelengthRange(AppSettings.MinimumWavelength, AppSettings.MaximumWavelength)
            };
            return methods;
        }
    }
}
