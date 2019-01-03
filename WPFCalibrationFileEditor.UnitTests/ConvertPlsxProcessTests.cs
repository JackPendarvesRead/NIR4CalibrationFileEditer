﻿using NIR4CalibrationEditorMethods;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFCalibrationFileEditor.Domain;
using WPFCalibrationFileEditor.ViewModel;

namespace WPFCalibrationFileEditor.UnitTests
{
    public class ConvertPlsxProcessTests
    {
        [TestFixture]
        public class TheRunMethod
        {
            SelectPlsxFileViewModel viewModel;
            string data;
            string expectedOutput;

            [SetUp]
            public void Setup()
            {
                var mockData = new ConvertPlsxProcessTestsData();
                data = mockData.Data;
                expectedOutput = mockData.ExpectedData;

                viewModel = new SelectPlsxFileViewModel()
                {
                    CalibrationFileName = @"test.plsx",
                    CalibrationFilePath = @"\\madeup\filepath\test.plsx",
                    DataProvider = new DataProvider(data),
                    Parameters = null
                };
                new ConvertPlsxProcess().Run(viewModel);
            }
            [Test]
            public void CorrectParametersInViewModel()
            {                

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