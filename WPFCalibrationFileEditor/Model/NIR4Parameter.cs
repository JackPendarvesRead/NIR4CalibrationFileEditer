using System;
using System.ComponentModel;
using WPFCalibrationFileEditor.Logic.PlsxConverter;

namespace WPFCalibrationFileEditor.Model
{
    public class NIR4Parameter : INotifyPropertyChanged
    {

        private readonly DataProvider dataProvider;

        public NIR4Parameter(DataProvider dataProvider)
        {
            this.dataProvider = dataProvider;
        }


        public override string ToString()
        {
            return $@"<parameter tolerance=""{this.Tolerance}"" label=""{this.Label}"" unit=""{this.Unit}"" order=""{this.Order}"">{this.Code}</parameter>";
        } 

        private void UpdateDataProvider()
        {
            if(this.Code != null                 
                && this.Label != null 
                && this.Unit != null
                && this.Order != null
                && this.Tolerance != null)
            {
                this.dataProvider.UpdateDataProviderParameters(this);
            }
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
                    UpdateDataProvider();
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
                    UpdateDataProvider();
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
                    UpdateDataProvider();
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
                    UpdateDataProvider();
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
                    UpdateDataProvider();
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
