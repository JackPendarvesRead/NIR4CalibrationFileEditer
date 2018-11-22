using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aunir.SpectrumAnalysis.Interfaces;

namespace WPFCalibrationFileEditor.Domain
{
    public class Product : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public string Name { get; set; }
        public InstrumentType ApplicableInstrument { get; set; }

        private ObservableCollection<Calibration> calibrations = new ObservableCollection<Calibration>();
        public ObservableCollection<Calibration> Calibrations
        {
            get { return calibrations; }
            set
            {
                calibrations = value;
                this.OnPropertyChanged("Calibrations");
            }
        }

        private bool includeGh = false;
        public bool IncludeGh
        {
            get { return includeGh; }
            set
            {
                if (value != includeGh)
                {
                    includeGh = value;
                    this.OnPropertyChanged("IncludeGh");
                }
            }
        }

        public double GhLimit { get; set; }

        private string ghVersion;

        public string GhVersion
        {
            get
            {
                return ghVersion;
            }
            set
            {
                ghVersion = value;
                this.OnPropertyChanged("GhVersion");
            }
        }

        private string ghFileName = "[Select File]";
        public string GhFileName
        {
            get { return ghFileName; }
            set
            {
                if (ghFileName != value)
                {
                    ghFileName = value;
                    this.OnPropertyChanged("GhFileName");
                }
            }
        }

        private bool isSelected = false;
        public bool IsSelected
        {
            get { return isSelected; }
            set
            {
                if (value != isSelected)
                {
                    isSelected = value;
                    this.OnPropertyChanged("IsSelected");
                }
            }
        }


        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
