using NIR4CalibrationEditorMethods;
using NIR4CalibrationEditorMethods.Domain;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFCalibrationFileEditor.Logic;

namespace WPFCalibrationFileEditor.UnitTests
{
    public class FileSaveTests
    {
        [TestFixture]
        public class TheSaveMethod
        {
            [Test]            
            public void CorrectData()
            {
                Assert.AreEqual(1, 0);
            }
        }

        [TestFixture]
        public class TheGetWriteFilePathMethod
        {
            string initialFilePath;
            string finalFilePath;
            string date;

            [SetUp]
            public void Setup()
            {
                initialFilePath = @"\\madeuppath\test\file.plsx";
                date = DateTime.Now.ToString("yyMMdd_hhmmss");
                finalFilePath = $@"\\madeuppath\test\file_updated_{date}.plsx";
            }
            [Test]
            public void CorrectWriteFilePath()
            {
                Assert.AreEqual(1, 0);
                //Assert.AreEqual(finalFilePath, new FileSave().GetWriteFilePath(initialFilePath));
            }
        }
    }
}
