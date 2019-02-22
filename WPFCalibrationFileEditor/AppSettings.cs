using System;
using System.Configuration;

namespace WPFCalibrationFileEditor
{
    public static class AppSettings
    {
        public static string FarmParameterConfigurationFilePath = ConfigurationManager.AppSettings["FarmParameterConfigurationFilePath"];
        public static string FeedParameterConfigurationFilePath = ConfigurationManager.AppSettings["FeedParameterConfigurationFilePath"];
        public static int MinimumWavelength = Int32.Parse(ConfigurationManager.AppSettings["MinimumWavelength"]);
        public static int MaximumWavelength = Int32.Parse(ConfigurationManager.AppSettings["MaximumWavelength"]);
    }
}
