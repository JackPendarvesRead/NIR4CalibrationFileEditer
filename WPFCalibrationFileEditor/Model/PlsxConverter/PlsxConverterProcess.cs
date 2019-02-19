using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text.RegularExpressions;
using WPFCalibrationFileEditor.PlsxConverter.PlsxConverterMethods;
using WPFCalibrationFileEditor.View;
using WPFCalibrationFileEditor.ViewModel;

namespace WPFCalibrationFileEditor.Model.PlsxConverter
{
    public class PlsxConverterProcess
    {
        private readonly PlsxFileInformation fileInformation;
        DataProvider data;

        public PlsxConverterProcess(PlsxFileInformation fileInformation)
        {
            this.fileInformation = fileInformation;
            this.data = GetDataProvider();
        }

        public void Run()
        {            
            RunConverterMethods();
            var viewModel = GetNewViewModel();
            var page = new ShowParameters(viewModel);
            page.NavigationService.Navigate(page);
        }
        
        private ShowParametersViewModel GetNewViewModel()
        {
            var viewModel = new ShowParametersViewModel
            {

            };
            return viewModel;
        }

        private void RunConverterMethods()
        {
            var methodsToRun = new List<IMethod>
            {
                new CheckWavelengthRange(),
                new RemoveExponentials(),
                new ReplaceEmptyParameters()
            };
            foreach(var method in methodsToRun)
            {
                method.Run(data);
            }
        }

        private DataProvider GetDataProvider()
        {
            using (var stream = new FileStream(fileInformation.CalibrationFilePath, FileMode.Open, FileAccess.Read, FileShare.Delete))
            {
                var data = new DataProvider(stream);
                return data;
            }
        }

        private ObservableCollection<NIR4Parameter> GetParameters()
        {
            var file = data.GetData();
            var parameterList = new List<NIR4Parameter>();
            var parameters = RegularExpressions.findParameterGroups.Matches(file);
            foreach (Match parameterMatch in parameters)
            {
                var parameter = new NIR4Parameter()
                {
                    Code = parameterMatch.Groups["code"].Value,
                    Label = parameterMatch.Groups["label"].Value,
                    Unit = parameterMatch.Groups["unit"].Value,
                    Order = parameterMatch.Groups["order"].Value,
                    Tolerance = parameterMatch.Groups["tolerance"].Value
                };
                parameterList.Add(parameter);
            }
            var parameterObserverableCollection = new ObservableCollection<NIR4Parameter>();
            foreach (NIR4Parameter parameter in parameters)
            {
                parameterObserverableCollection.Add(parameter);
            }
            return parameterObserverableCollection;
        }

        private string GetProductName()
        {            
            return RegularExpressions.findProductName.Match(data.GetData()).Groups[1].Value;
        }
    }   
}

