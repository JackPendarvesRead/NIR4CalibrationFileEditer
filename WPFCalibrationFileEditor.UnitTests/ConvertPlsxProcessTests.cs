using NIR4CalibrationEditorMethods;
using NIR4CalibrationEditorMethods.Domain;
using NIR4CalibrationEditorMethods.Methods;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFCalibrationFileEditor.Domain;
using WPFCalibrationFileEditor.Logic;
using WPFCalibrationFileEditor.ViewModel;

namespace WPFCalibrationFileEditor.UnitTests
{
    public class ConvertPlsxProcessTests
    {
        [TestFixture]
        public class TheRunMethod
        {
            PageViewModel viewModel;
            string data;
            string expectedOutput;

            [SetUp]
            public void Setup()
            {
                var mockData = new ConvertPlsxProcessTestsData();
                data = mockData.Data;
                expectedOutput = mockData.ExpectedData;

                viewModel = new PageViewModel()
                {
                    CalibrationFileName = @"test.plsx",
                    CalibrationFilePath = @"\\madeup\filepath\test.plsx",
                    DataProvider = new DataProvider(data),
                    Parameters = null
                };
                new ConvertPlsxProcess().Run(viewModel, new ConversionMethods(new ConvertPlsxProcessTestsConfig().GetConfig()).GetStandardMethods());
            }
            [Test]
            public void CorrectParametersInViewModel()
            {
                Assert.AreEqual(5, viewModel.Parameters.Count);
                Assert.AreEqual("ME", viewModel.Parameters[0].Code);
                Assert.AreEqual("Protein", viewModel.Parameters[1].Code);
                Assert.AreEqual("Empty", viewModel.Parameters[2].Code);
                Assert.AreEqual("Moisture", viewModel.Parameters[3].Code);
                Assert.AreEqual("DM", viewModel.Parameters[4].Code);
            }
            [Test]
            public void CorrectDataProviderInViewModel()
            {
                Assert.AreEqual(expectedOutput, viewModel.DataProvider.GetData());
            }
            [Test]
            public void CorrectCalibrationFileNameInViewModel()
            {
                Assert.AreEqual(@"test.plsx", viewModel.CalibrationFileName);
            }
            [Test]
            public void CorrectCalibrationFilePathInViewModel()
            {
                Assert.AreEqual(@"\\madeup\filepath\test.plsx", viewModel.CalibrationFilePath);
            }
        }
    }
}
