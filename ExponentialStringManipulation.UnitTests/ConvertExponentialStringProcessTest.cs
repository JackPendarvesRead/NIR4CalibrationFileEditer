using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExponentialStringManipulation;
using NUnit.Framework;

namespace ExponentialStringManipulation.UnitTests
{
    public class ConvertExponentialStringProcessTest
    {
        [TestFixture]
        public class TheConvertMethod
        {
            [Test]
            public void NegativePowerCorrectResult()
            {
                var input = "1.0001456789E-09";
                var logic = new ConvertExponentialStringProcess();
                var converted = logic.Convert(input);
                Assert.AreEqual("0.0000000010001456789", converted);
            }
            [Test]
            public void PositivePowerCorrectResult()
            {
                var input = "1.0001456789E+09";
                var logic = new ConvertExponentialStringProcess();
                var converted = logic.Convert(input);
                Assert.AreEqual("1000145678.9", converted);
            }
            [Test]
            public void PowerEqualToDigitsCorrectResult()
            {
                var input = "5.4321E+04";
                var logic = new ConvertExponentialStringProcess();
                var converted = logic.Convert(input);
                Assert.AreEqual("54321", converted);
            }
            [Test]
            public void HandlesIncorrectStringFormat()
            {
                var input = "1544625465136";
                Assert.Throws<Exception>(new TestDelegate(() => new ConvertExponentialStringProcess().Convert(input)));
            }

            [Test]
            public void HandlesEmptyString()
            {
                var input = "";
                Assert.Throws<Exception>(new TestDelegate(() => new ConvertExponentialStringProcess().Convert(input)));
            }            
        }        
    }
}
