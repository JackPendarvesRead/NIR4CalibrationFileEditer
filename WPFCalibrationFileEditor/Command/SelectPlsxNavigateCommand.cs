using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPFCalibrationFileEditor.ViewModel;

namespace WPFCalibrationFileEditor.Command
{
    internal class SelectPlsxNavigateCommand : ICommand
    {
        private readonly SelectPlsxFileViewModel viewModel;

        public SelectPlsxNavigateCommand(SelectPlsxFileViewModel viewModel)
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
            viewModel.SaveChanges();
        }
    }
}
