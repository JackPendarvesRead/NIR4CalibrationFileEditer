using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NIR4CalibrationEditorMethods.UnitTests
{
    class ReplaceEmptyParametersTestData
    {
        internal string Data =>
                        @"Here is a line of just some text
                        Here is some more text
                        One more
                       <parameter tolerance=""2.5"" label=""Dry Matter"" unit=""%"" order=""0"">DM</parameter>
                       <parameter tolerance=""2.5"" label=""Parameter"" unit=""%"" order=""0"">Parameter</parameter>
                       <parameter>Empty</parameter>
                       <parameter tolerance=""2.5"" label=""Crude Protein"" unit=""%"" order=""13"">Protein</parameter>
                       <parameter>pH</parameter>";

        internal string ExpectedOutput =>
                        @"Here is a line of just some text
                        Here is some more text
                        One more
                       <parameter tolerance=""2.5"" label=""Dry Matter"" unit=""%"" order=""0"">DM</parameter>
                       <parameter tolerance=""2.5"" label=""Parameter"" unit=""%"" order=""0"">Parameter</parameter>
                       <parameter tolerance=""2.5"" label=""Empty"" unit=""%"" order=""0"">Empty</parameter>
                       <parameter tolerance=""2.5"" label=""Crude Protein"" unit=""%"" order=""13"">Protein</parameter>
                       <parameter tolerance=""2.5"" label=""pH"" unit="""" order=""2"">pH</parameter>";

        internal List<ReplaceEmptyParametersConfig> GetConfig()
        {
            var list = new List<ReplaceEmptyParametersConfig>()
            {
                new ReplaceEmptyParametersConfig()
                {
                    Code = "DM",
                    Label = "Dry Matter",
                    Order = "0",
                    Tolerance = "2.5",
                    Unit = "%",
                    MatchingParameter = new List<string>() {"DM", "ODM", "TDM"}
                },
                new ReplaceEmptyParametersConfig()
                {
                    Code = "Protein",
                    Label = "Protein",
                    Order = "1",
                    Tolerance = "2.5",
                    Unit = "%",
                    MatchingParameter = new List<string>() {"Protein"}
                },
                new ReplaceEmptyParametersConfig()
                {
                    Code = "pH",
                    Label = "pH",
                    Order = "2",
                    Tolerance = "2.5",
                    Unit = "",
                    MatchingParameter = new List<string>() {"pH"}
                }
            };
            return list;
        }
    }
}
