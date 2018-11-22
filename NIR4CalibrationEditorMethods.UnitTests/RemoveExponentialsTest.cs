using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NIR4CalibrationEditorMethods;
using NUnit.Framework;

namespace NIR4CalibrationEditorMethods.UnitTests
{
    public class RemoveExponentialsTest
    {
        [TestFixture]
        public class TheRunMethod
        {
            DataProvider provider;
            string expectedOutput;

            [SetUp]
            public void Setup()
            {
                var data =
                    @"Here is a line of just some text
                    1.0585738132987437
                    2.1234567E-06
                    6.5555555E+11
                    Here is some more text
                    One more
                    123456789
                    1.1111E-11";

                provider = new DataProvider(data);

                expectedOutput = 
                    @"Here is a line of just some text
                    1.0585738132987437
                    0.0000021234567
                    655555550000
                    Here is some more text
                    One more
                    123456789
                    0.000000000011111";
            }

            [Test]
            public void CorrectOutput()
            {
                new RemoveExponentials().Run(provider);
                Assert.AreEqual(expectedOutput, provider.GetData());
            }
        }
    }
}
