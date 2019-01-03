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
        public void Run(PageViewModel viewModel)
        {
            var data = viewModel.DataProvider;
            var config = JacksUsefulLibrary.JsonMethods.JsonReaderWriter<ReplaceEmptyParametersConfig>.LoadFromFile(AppSettings.ParameterConfigurationFilePath);
            new ReplaceEmptyParameters(config).Run(data);
            new RemoveExponentials().Run(data);
            viewModel.Parameters = GetParameters(data);
            viewModel.DataProvider = data;
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

