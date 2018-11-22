using NIR4CalibrationEditorMethods;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFCalibrationFileEditor.Domain;

namespace WPFCalibrationFileEditor.ViewModel
{
    public class PageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<NIR4Parameter> parameters;
        public ObservableCollection<NIR4Parameter> Parameters
        {
            get { return parameters; }
            set
            {
                if (parameters != value)
                {
                    parameters = value;
                    NotifyChange("Parameters");
                }
            }
        }

        private DataProvider dataProvider;
        public DataProvider DataProvider
        {
            get { return dataProvider; }
            set
            {
                if (dataProvider != value)
                {
                    dataProvider = value;
                    NotifyChange("DataProvider");
                }
            }
        }

        private string calibrationFilePath;
        public string CalibrationFilePath
        {
            get { return calibrationFilePath; }
            set
            {
                if (calibrationFilePath != value)
                {
                    calibrationFilePath = value;
                    NotifyChange("CalibrationFilePath");
                }
            }
        }

        private string calibrationFileName;
        public string CalibrationFileName
        {
            get { return calibrationFileName; }
            set
            {
                if (calibrationFileName != value)
                {
                    calibrationFileName = value;
                    NotifyChange("CalibrationFileName");
                }
            }
        }

        private void NotifyChange(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}
