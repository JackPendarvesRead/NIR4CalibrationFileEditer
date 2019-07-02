using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text.RegularExpressions;
using WPFCalibrationFileEditor.Logic.PlsxConverter.PlsxConverterMethods;
using WPFCalibrationFileEditor.Model;

namespace WPFCalibrationFileEditor.Logic.PlsxConverter
{
    public class PlsxConverterProcess
    {
        private readonly PlsxFileInformation fileInformation;
        private readonly string config;
        public DataProvider Data { get; set; }

        public PlsxConverterProcess(PlsxFileInformation fileInformation, string config)
        {
            this.fileInformation = fileInformation;
            this.config = config;
            this.Data = GetDataProvider();
        }

        public void Run()
        {
            var methodsToRun = new List<IMethod>
            {
                new CheckWavelengthRange(),
                new RemoveExponentials(),
                new ReplaceEmptyParameters(config)
            };
            foreach (var method in methodsToRun)
            {
                method.Run(Data);
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

        public ObservableCollection<NIR4Parameter> GetParameters()
        {
            var file = Data.GetData();
            var parameterList = new List<NIR4Parameter>();
            var parameters = RegularExpressions.findParameterGroups.Matches(file);
            foreach (Match parameterMatch in parameters)
            {
                var parameter = new NIR4Parameter(this.Data)
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
            foreach (NIR4Parameter parameter in parameterList)
            {
                parameterObserverableCollection.Add(parameter);
            }
            return parameterObserverableCollection;
        }

        private string GetProductName()
        {            
            return RegularExpressions.findProductName.Match(Data.GetData()).Groups[1].Value;
        }
    }   
}

