//using System.Collections.Generic;

//namespace WPFCalibrationFileEditor.UnitTests
//{
//    class TestConfig
//    {
//        internal IEnumerable<ReplaceEmptyParametersConfig> GetConfig()
//        {
//            var config = new List<ReplaceEmptyParametersConfig>();
//            config.Add(CreateParameter("ME", "ME", "MJ / kg", "2.5", "1"));
//            config.Add(CreateParameter("Protein", "Protein", "%", "2.5", "2"));
//            config.Add(CreateParameter("Moisture", "Moisture", "%", "2.5", "3"));
//            config.Add(CreateParameter("DM", "Dry Matter", "%", "2.5", "4"));
//            return config;
//        }

//        private ReplaceEmptyParametersConfig CreateParameter(string code, string label, string unit, string tolerance, string order)
//        {
//            return new ReplaceEmptyParametersConfig()
//            {
//                Code = code,
//                Label = label,
//                Unit = unit,
//                Tolerance = tolerance,
//                Order = order,
//                MatchingParameter = new List<string>() { code }
//            };
//        }
//    }
//}
