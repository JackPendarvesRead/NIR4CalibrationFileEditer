using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPFCalibrationFileEditor.ViewModel;

namespace WPFCalibrationFileEditor.Command
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
