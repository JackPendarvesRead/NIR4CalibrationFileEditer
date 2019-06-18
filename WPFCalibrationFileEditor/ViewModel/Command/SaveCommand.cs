using System;
using System.Windows.Input;

namespace WPFCalibrationFileEditor.ViewModel.Command
{
    internal class SaveCommand : ICommand
    {
        private readonly MainWindowViewModel viewModel;

        public SaveCommand(MainWindowViewModel viewModel)
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
            return viewModel.CanSave;
        }

        public void Execute(object parameter)
        {
            viewModel.Save();
        }
    }
}
