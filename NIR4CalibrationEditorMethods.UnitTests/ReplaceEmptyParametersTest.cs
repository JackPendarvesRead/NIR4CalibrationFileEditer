using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NIR4CalibrationEditorMethods;
using NIR4CalibrationEditorMethods.Domain;
using NIR4CalibrationEditorMethods.Methods;
using NUnit.Framework;

namespace NIR4CalibrationEditorMethods.UnitTests
{
    public class ReplaceEmptyParametersTest
    {
        [TestFixture]
        public class TheRunMethod
        {
            DataProvider provider;
            string expectedOutput;
            IEnumerable<ReplaceEmptyParametersConfig> config;

            [SetUp]
            public void Setup()
            {
                var data = new ReplaceEmptyParametersTestData();
                provider = new DataProvider(data.Data);
                expectedOutput = data.ExpectedOutput;
                config = data.GetConfig();
            }


            [Test]
            public void CorrectOutput()
            {
                new ReplaceEmptyParameters(config).Run(provider);
                Assert.AreEqual(expectedOutput, provider.GetData());
            }          
        }
    }
}
