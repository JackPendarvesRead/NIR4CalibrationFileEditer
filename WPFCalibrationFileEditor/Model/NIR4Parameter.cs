using System.ComponentModel;

namespace WPFCalibrationFileEditor.Model
{
    public class NIR4Parameter : INotifyPropertyChanged
    {
        public override string ToString()
        {
            return $@"<parameter tolerance=""{this.Tolerance}"" label=""{this.Label}"" unit=""{this.Unit}"" order=""{this.Order}"">{this.Code}</parameter>";
        }

        private string code;
        public string Code
        {
            get { return code; }
            set
            {
                if (code != value)
                {
                    code = value;
                    NotifyChange(nameof(Code));
                }
            }
        }

        private string label;
        public string Label
        {
            get { return label; }
            set
            {
                if (label != value)
                {
                    label = value;
                    NotifyChange(nameof(Label));
                }
            }
        }

        private string unit;
        public string Unit
        {
            get { return unit; }
            set
            {
                if (unit != value)
                {
                    unit = value;
                    NotifyChange(nameof(Unit));
                }
            }
        }

        private string order;
        public string Order
        {
            get { return order; }
            set
            {
                if (order != value)
                {
                    order = value;
                    NotifyChange(nameof(Order));
                }
            }
        }

        private string tolerance;
        public string Tolerance
        {
            get { return tolerance; }
            set
            {
                if (tolerance != value)
                {
                    tolerance = value;
                    NotifyChange(nameof(Tolerance));
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
