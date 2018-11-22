using System;
using System.ComponentModel;
using Aunir.SpectrumAnalysis.Interfaces.Equations;

namespace WPFCalibrationFileEditor.Domain
{
    public class Calibration : INotifyPropertyChanged
    {
        public string FileName { get; set; }
        public string Name { get; set; }
        public string Version { get; set; }
        public IEquation Equation;
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

        public Calibration(IEquation equation, string fileName)
        {
            if (equation != null)
            {
                this.Equation = equation;
                this.Name = equation.CommonEquationInformation.Parameter;
                this.Version = equation.CommonEquationInformation.Version;
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
