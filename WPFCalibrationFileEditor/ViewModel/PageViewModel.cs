using NIR4CalibrationEditorMethods.Domain;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
                    NotifyChange(nameof(Parameters));
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
                    NotifyChange(nameof(DataProvider));
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
                    NotifyChange(nameof(CalibrationFilePath));
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
                    NotifyChange(nameof(CalibrationFileName));
                }
            }
        }

        private string productName;
        public string ProductName
        {
            get { return productName; }
            set
            {
                if (productName != value)
                {
                    productName = value;
                    NotifyChange(nameof(ProductName));
                }
            }
        }

        private void NotifyChange(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}
