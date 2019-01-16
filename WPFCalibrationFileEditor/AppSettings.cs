using System;
using System.Configuration;

namespace WPFCalibrationFileEditor
{
    public static class AppSettings
    {
        public static string ParameterConfigurationFilePath = ConfigurationManager.AppSettings["ParameterConfigurationFilePath"];
        public static int MinimumWavelength = Int32.Parse(ConfigurationManager.AppSettings["MinimumWavelength"]);
        public static int MaximumWavelength = Int32.Parse(ConfigurationManager.AppSettings["MaximumWavelength"]);
    }
}
