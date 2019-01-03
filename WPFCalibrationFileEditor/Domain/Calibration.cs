using System;
using System.ComponentModel;
using Aunir.SpectrumAnalysis.Interfaces.Equations;
using Aunir.SpectrumAnalysis2.Interfaces.Pls;

namespace WPFCalibrationFileEditor.Domain
{
    public class Calibration : INotifyPropertyChanged
    {
        public string FileName { get; set; }
        public string Name { get; set; }
        public string Version { get; set; }
        public IPlsEquationInformation Equation;
        private bool includeCalibration = true;
        public bool IncludeCalibration
        {
            get { return includeCalibration; }
            set
            {
                if (value != includeCalibration)
                {
                    includeCalibration = value;
                    this.OnPropertyChanged("IncludeCalibration");
                }
            }
        }

        public Calibration(IPlsEquationInformation equation, string fileName)
        {
            if (equation != null)
            {
                this.Equation = equation;
                this.Name = equation.Parameter;
                this.Version = "1.0.0.0";
                this.FileName = fileName;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
