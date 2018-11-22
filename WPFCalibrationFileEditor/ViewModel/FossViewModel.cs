using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFCalibrationFileEditor.Domain;

namespace WPFCalibrationFileEditor.ViewModel
{
    public class FossViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string ghFilePath;
        public string GhFilePath
        {
            get { return ghFilePath; }
            set
            {
                if (ghFilePath != value)
                {
                    ghFilePath = value;
                    NotifyChange("GhFilePath");
                }
            }
        }

        private string eqaFilePath;
        public string EqaFilePath
        {
            get { return eqaFilePath; }
            set
            {
                if (eqaFilePath != value)
                {
                    eqaFilePath = value;
                    NotifyChange("EqaFilePath");
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
                    NotifyChange("ProductName");
                }
            }
        }

        private Product product;
        public Product Product
        {
            get { return product; }
            set
            {
                if (product != value)
                {
                    product = value;
                    NotifyChange("Product");
                }
            }
        }

        private void NotifyChange(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}
