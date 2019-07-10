using System;
using System.Windows.Input;
using WPFCalibrationFileEditor.Logic;

namespace WPFCalibrationFileEditor.ViewModel.Command
{
    internal class RunProcessCommand : ICommand
    {
        private readonly MainWindowViewModel viewModel;

        public RunProcessCommand(MainWindowViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {            
            return viewModel.CanRunProcess;
        }

        public void Execute(object parameter)
        {
            if(parameter != null)
            {
                MyParamterConfig x = parameter as MyParamterConfig;
                var config = x.FilePath;
                viewModel.RunProcess(config);
            }          
        }
    }
}
