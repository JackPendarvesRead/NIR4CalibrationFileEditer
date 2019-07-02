using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using WPFCalibrationFileEditor.Logic.PlsxConverter;

namespace WPFCalibrationFileEditor.Model
{
    public class PlsxFileInformation : INotifyPropertyChanged
    {
        public DataProvider DataProvider { get; set; }

        private string calibrationFilePath;
        public string CalibrationFilePath
        {
            get { return calibrationFilePath; }
            set
            {
                if (calibrationFilePath != value)
                {
                    calibrationFilePath = value;
                    NotifyChange(nameof(CalibrationFilePath));
                }
            }
        }

        private ObservableCollection<NIR4Parameter> parameters;
        public ObservableCollection<NIR4Parameter> Parameters
        {
            get { return parameters; }
            set
            {
                if (parameters != value)
                {
                    parameters = value;
                    NotifyChange(nameof(Parameters));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyChange(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}
