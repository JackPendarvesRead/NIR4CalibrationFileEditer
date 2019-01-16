using NIR4CalibrationEditorMethods.Domain;
using NIR4CalibrationEditorMethods.Methods;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NIR4CalibrationEditorMethods.UnitTests
{
    public class CheckWavelengthRangeTest
    {
        [TestFixture]
        public class TheRunMethod
        {
            private int maxWavelength => 1646;
            private int minWavelength => 930;
            

            [Test]
            public void CorrectWavelengths()
            {
                var data = 
                    @"firstline
<parameter name=""minWavelength"">930</parameter>
<parameter name=""maxWavelength"">1646</parameter>
StuffStuff
<parameter name=""minWavelength"">930</parameter>
<parameter name=""maxWavelength"">1646</parameter>
SomeWavelengthnumber1236589Stuff
<parameter name=""minWavelength"">930</parameter>
<parameter name=""maxWavelength"">1646</parameter>";
                var provider = new DataProvider(data);
                Assert.DoesNotThrow(() => new CheckWavelengthRange(minWavelength, maxWavelength).Run(provider));
            }
            [Test]
            public void IncorrectMinWavelengths()
            {
                var data = 
                    @"firstline
<parameter name=""minWavelength"">930</parameter>
<parameter name=""maxWavelength"">1646</parameter>
StuffStuff
<parameter name=""minWavelength"">1646</parameter>
<parameter name=""maxWavelength"">1646</parameter>
SomeWavelengthnumber1236589Stuff
<parameter name=""minWavelength"">762762</parameter>
<parameter name=""maxWavelength"">1646</parameter>";
                var provider = new DataProvider(data);
                Assert.Throws<Exception>(() => new CheckWavelengthRange(minWavelength, maxWavelength).Run(provider));
            }
            [Test]
            public void IncorrectMaxWavelengths()
            {
                var data = 
                   @"firstline
<parameter name=""minWavelength"">930</parameter>
<parameter name=""maxWavelength"">88</parameter>
StuffStuff
<parameter name=""minWavelength"">930</parameter>
<parameter name=""maxWavelength"">0845646</parameter>
SomeWavelengthnumber1236589Stuff
<parameter name=""minWavelength"">930</parameter>
<parameter name=""maxWavelength"">1646</parameter>";
                var provider = new DataProvider(data);
                Assert.Throws<Exception>(() => new CheckWavelengthRange(minWavelength, maxWavelength).Run(provider));
            }
        }
    }
}
