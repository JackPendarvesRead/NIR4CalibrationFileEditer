using log4net;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using WPFCalibrationFileEditor.Model;
using WPFCalibrationFileEditor.Logic.PlsxConverter;

namespace WPFCalibrationFileEditor.Logic.PlsxConverter.PlsxConverterMethods
{
    public class ReplaceEmptyParameters : IMethod
    {
        private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private readonly IEnumerable<ReplaceEmptyParametersConfig> config;

        public ReplaceEmptyParameters(IEnumerable<ReplaceEmptyParametersConfig> config)
        {
            this.config = config;
        }
        public ReplaceEmptyParameters(string configKey)
        {
            this.config = JacksUsefulLibrary.JsonMethods.JsonReaderWriter<ReplaceEmptyParametersConfig>.LoadFromFile(GetConfigString(configKey));
        }

        private string GetConfigString(string configKey)
        {
            switch (configKey.ToLower())
            {
                case "feed":
                    return AppSettings.FeedParameterConfigurationFilePath;

                case "farm":
                    return AppSettings.FarmParameterConfigurationFilePath;

                default:
                    throw new Exception("Could not get config from configKey.");
            }
        }

        /// <summary>
        /// If any parameters are empty then this method fills it with default information.
        /// </summary>
        /// <param name="provider"></param>
        public void Run(DataProvider provider)
        {
            var file = provider.GetData();
            var emptyParameters = RegularExpressions.findEmptyParameter.Matches(file);
            if (emptyParameters.Count > 0)
            {
                Log.Debug($"{emptyParameters.Count} empty parameters found in file:");
                var replacementList = new List<string>();
                foreach(Match match in emptyParameters)
                {
                    Log.Debug(match.Value.ToString());
                    var parameterCode = match.Groups[1].Value;
                    var selection = SelectConfig(config, parameterCode);
                    var parameterReplace = $@"<parameter tolerance=""{selection.Tolerance}"" label=""{selection.Label}"" unit=""{selection.Unit}"" order=""{selection.Order}"">{selection.Code}</parameter>";
                    file = file.Replace(match.ToString(), parameterReplace);
                }
                if (file.Contains(@"<limit>5</limit>"))
                {
                    file = file.Replace(@"<limit>5</limit>", @"<ghLimit>5</ghLimit>");
                    Log.Debug(@"Replaced <limit>5</limit> with <ghLimit>5</ghLimit>");
                }
            }
            else
            {
                Log.Debug("No empty parameters found in file.");
            }
            provider.SetData(file);
        }

        private ReplaceEmptyParametersConfig SelectConfig(IEnumerable<ReplaceEmptyParametersConfig> configList, string code)
        {
            foreach(var config in configList)
            {
                if (config.MatchingParameter.Contains(code))
                {
                    return config;
                }
            }
            var defaultConfig = new ReplaceEmptyParametersConfig()
            {
                Code = code,
                Label = code,
                MatchingParameter = null,
                Order = "0",
                Tolerance = "2.5",
                Unit = "%"
            };
            return defaultConfig;
        }
    }
}
