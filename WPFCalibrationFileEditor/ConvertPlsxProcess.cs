using NIR4CalibrationEditorMethods;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFCalibrationFileEditor.Domain;
using WPFCalibrationFileEditor.ViewModel;

namespace WPFCalibrationFileEditor
{
    public class ConvertPlsxProcess
    {
        public void Run(Stream stream, PageViewModel viewModel)
        {            
            var data = new DataProvider(stream);
            RunMethods(data);                
            viewModel.Parameters = GetParameters(data);
            viewModel.DataProvider = data;
        }

        private void RunMethods(DataProvider data)
        {
            var filePath = @"C:\Users\jread\source\testdata\CalibrationFileEditer\default\defaultParameters.json";
            var config = JacksUsefulLibrary.JsonReaderWriter<ReplaceEmptyParametersConfig>.LoadFromFile(filePath);
            new ReplaceEmptyParameters(config).Run(data);
            new RemoveExponentials().Run(data);
        }

        private ObservableCollection<NIR4Parameter> GetParameters(DataProvider data)
        {
            var parameters = new NIR4Parameter().GetParameters(data);
            var parameterObserverableCollection = new ObservableCollection<NIR4Parameter>();
            foreach (var parameter in parameters)
            {
                parameterObserverableCollection.Add(parameter);
            }
            return parameterObserverableCollection;
        }
    }   
}

