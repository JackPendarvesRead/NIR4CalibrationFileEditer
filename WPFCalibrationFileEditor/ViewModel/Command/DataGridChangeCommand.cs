//using System;
//using System.Windows.Controls;
//using System.Windows.Input;
//using WPFCalibrationFileEditor.Model;

//namespace WPFCalibrationFileEditor.ViewModel.Command
//{
//    internal class DataGridChangeCommand : ICommand
//    {
//        private readonly MainWindowViewModel viewModel;

//        public DataGridChangeCommand(MainWindowViewModel viewModel)
//        {
//            this.viewModel = viewModel;
//        }

//        public event EventHandler CanExecuteChanged
//        {
//            add { CommandManager.RequerySuggested += value; }
//            remove { CommandManager.RequerySuggested -= value; }
//        }
//        public bool CanExecute(object parameter)
//        {
//            return true;
//        }

//        public void Execute(object parameter)
//        {
//            DataGridCellInfo cell = (DataGridCellInfo)parameter;            
//            var columnHeader = cell.Column.Header.ToString();
//            NIR4Parameter nirParameter = (NIR4Parameter)cell.Item;
            
//            viewModel.DataGridChange(nirParameter, columnHeader);
//        }
//    }
//}
