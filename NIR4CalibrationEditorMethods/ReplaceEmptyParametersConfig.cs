using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NIR4CalibrationEditorMethods
{
    public class ReplaceEmptyParametersConfig
    {
        public string Label { get; set; }
        public string Order { get; set; }
        public string Unit { get; set; }
        public string Tolerance { get; set; }
        public string Code { get; set; }
        public List<string> MatchingParameter { get; set; }
    }
}
