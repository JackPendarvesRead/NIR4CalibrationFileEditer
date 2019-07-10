using System;
using System.Configuration;

namespace WPFCalibrationFileEditor
{
    public static class AppSettings
    {
        public static string ConfigurationDirectory = ConfigurationManager.AppSettings["ConfigurationDirectory"];
        public static int MinimumWavelength = Int32.Parse(ConfigurationManager.AppSettings["MinimumWavelength"]);
        public static int MaximumWavelength = Int32.Parse(ConfigurationManager.AppSettings["MaximumWavelength"]);
        public static int Resolution = Int32.Parse(ConfigurationManager.AppSettings["Resolution"]);
    }
}
