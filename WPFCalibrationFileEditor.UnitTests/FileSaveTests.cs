using NIR4CalibrationEditorMethods;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFCalibrationFileEditor.UnitTests
{
    public class FileSaveTests
    {
        [TestFixture]
        public class TheSaveMethod
        {
            //[Test]
            //public void CorrectData()
            //{
            //    using(var stream = new MemoryStream())
            //    {
            //        var provider = new DataProvider(stream);

            //        var save = new FileSave();
            //        save.Save(stream, provider);
            //    }

            //}
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
                Assert.AreEqual(finalFilePath, new FileSave().GetWriteFilePath(initialFilePath));
            }
        }
    }
}
