using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using WPFCalibrationFileEditor.ViewModel;

namespace WPFCalibrationFileEditor.Command
{
    internal class DataGridChangeCommand : ICommand
    {
        private readonly MainWindowViewModel viewModel;

        public DataGridChangeCommand(MainWindowViewModel viewModel)
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
            DataGridCellInfo cell = parameter;
            var columnHeader = cell.Column.Header.ToString();
            var content = cell.Item.ToString();
            
            viewModel.DataGridChange(content, columnHeader);
        }
    }
}
