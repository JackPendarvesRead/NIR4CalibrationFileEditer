using NIR4CalibrationEditorMethods.Domain;
using NIR4CalibrationEditorMethods.Methods;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using WPFCalibrationFileEditor.Domain;
using WPFCalibrationFileEditor.ViewModel;

namespace WPFCalibrationFileEditor.Logic
{
    public class ConvertPlsxProcess
    {   
        public void Run(PageViewModel viewModel, IEnumerable<IMethod> methods)
        {
            var data = viewModel.DataProvider;
            foreach(var method in methods)
            {
                method.Run(data);
            }
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

