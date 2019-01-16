using NIR4CalibrationEditorMethods.Domain;
using NIR4CalibrationEditorMethods.Methods;
using System.Collections.Generic;

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
