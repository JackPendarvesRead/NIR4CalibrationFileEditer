using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFCalibrationFileEditor.Logic;

namespace WPFCalibrationFileEditor.UnitTests
{
    public class FilePathManipulationTests
    {
        [TestFixture]
        public class TheGetWriteFilePathMethod
        {
            [Test]
            public void CorrectWriteFilePath()
            {
                var date = DateTime.Now.ToString("yyMMdd_hhmmss");
                var initialFilePath = @"\\madeuppath\test\file.plsx";
                var finalFilePath = $@"\\madeuppath\test\file_updated_{date}.plsx";
                var output = initialFilePath.GetWriteFilePath();
                Assert.AreEqual(finalFilePath, output);
            }
        }
    }
}
