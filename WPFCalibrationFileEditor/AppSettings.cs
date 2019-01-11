using System.Configuration;

namespace WPFCalibrationFileEditor
{
    public static class AppSettings
    {
        public static string ParameterConfigurationFilePath = ConfigurationManager.AppSettings["ParameterConfigurationFilePath"];
    }
}
