using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using WPFCalibrationFileEditor.Model;

namespace WPFCalibrationFileEditor.ViewModel
{
    public class ShowParametersViewModel
    {
        public ICommand SaveCommand { get; private set; }
        public ICommand DataGridChangeCommand { get; private set; }

        private PlsxFileInformation fileInformation;
        public PlsxFileInformation FileInformation
        {
            get { return fileInformation; }
        }
    }
}
