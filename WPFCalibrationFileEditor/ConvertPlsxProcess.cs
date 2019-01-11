using NIR4CalibrationEditorMethods;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using WPFCalibrationFileEditor.Domain;
using WPFCalibrationFileEditor.ViewModel;

namespace WPFCalibrationFileEditor
{
    public class ConvertPlsxProcess
    {
        private readonly IEnumerable<ReplaceEmptyParametersConfig> config;

        public ConvertPlsxProcess(IEnumerable<ReplaceEmptyParametersConfig> config)
        {
            this.config = config;
        }

        public void Run(PageViewModel viewModel)
        {
            var data = viewModel.DataProvider;
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

