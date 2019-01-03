using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace WPFCalibrationFileEditor
{
    public static class AppSettings
    {
        public static string ParameterConfigurationFilePath = ConfigurationManager.AppSettings["ParameterConfigurationFilePath"];
    }
}
