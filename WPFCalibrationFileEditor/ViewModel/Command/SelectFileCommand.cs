using System;
using System.Windows.Input;

namespace WPFCalibrationFileEditor.ViewModel.Command
{
    internal class SelectFileCommand : ICommand
    {
        private readonly MainWindowViewModel viewModel;

        public SelectFileCommand(MainWindowViewModel viewModel)
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
            return true;
        }

        public void Execute(object parameter)
        {
            viewModel.SelectFile();
        }
    }
}
