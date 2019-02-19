using System.Collections.Generic;

namespace WPFCalibrationFileEditor.Model.PlsxConverter
{
    public class ReplaceEmptyParametersConfig
    {
        public string Label { get; set; }
        public string Order { get; set; }
        public string Unit { get; set; }
        public string Tolerance { get; set; }
        public string Code { get; set; }
        public List<string> MatchingParameter { get; set; }

        public IEnumerable<ReplaceEmptyParametersConfig> GetConfig()
        {
            return JacksUsefulLibrary.JsonMethods.JsonReaderWriter<ReplaceEmptyParametersConfig>.LoadFromFile(AppSettings.ParameterConfigurationFilePath);
        }
    }
}
