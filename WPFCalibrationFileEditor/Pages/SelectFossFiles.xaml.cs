using Aunir.SpectrumAnalysis.Interfaces;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using WPFCalibrationFileEditor.Domain;
using WPFCalibrationFileEditor.ViewModel;

namespace WPFCalibrationFileEditor
{
    /// <summary>
    /// Interaction logic for SelectFossFiles.xaml
    /// </summary>
    public partial class SelectFossFiles : Page
    {
        FossViewModel viewModel;

        public SelectFossFiles()
        {
            this.viewModel = new FossViewModel();
            base.DataContext = viewModel;
            viewModel.Product = new Product()
            {
                GhFileName = null,
                Name = null,
                GhLimit = 5,
                GhVersion = "1.0.0.0",
                ApplicableInstrument = InstrumentType.JDSUMicroNir,
                IncludeGh = false,
                IsSelected = true,
            };
            InitializeComponent();
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(viewModel.EqaFilePath) && !string.IsNullOrEmpty(viewModel.GhFilePath))
            {
                viewModel.Product.Name = viewModel.ProductName;

                var page = new ShowParameters(viewModel);
                this.NavigationService.Navigate(page);
            }
            else
            {
                if (string.IsNullOrEmpty(viewModel.Product.Name))
                {
                    System.Windows.Forms.MessageBox.Show("Type product name.");
                }
                if (string.IsNullOrEmpty(viewModel.EqaFilePath))
                {
                    System.Windows.Forms.MessageBox.Show("Select an EQA file.");
                }
                if (string.IsNullOrEmpty(viewModel.GhFilePath))
                {
                    System.Windows.Forms.MessageBox.Show("Select a GH file.");
                }                
            }
        }
        private void AddGhFileButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog
            {
                Filter = "Foss GH Files|*.pca",
                CheckFileExists = true
            };
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                viewModel.GhFilePath = ofd.FileName;
            }
        }
        private void AddEqaFileButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Foss Equation Files|*.eqa";
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                UpdateViewModelProduct(ofd.FileName);                
                new SimonFileSaver().SetupProduct(viewModel.Product);
                var product = viewModel.Product;
            }
        }
        private void UpdateViewModelProduct(string filePath)
        {
            viewModel.Product.GhFileName = filePath;
            if (!string.IsNullOrWhiteSpace(viewModel.ProductName))
            {
                viewModel.Product.Name = viewModel.ProductName;
            }
            else
            {
                viewModel.Product.Name = filePath;
            }
            viewModel.EqaFilePath = filePath;
            foreach (Calibration c in new CalibrationLoader().LoadCalibrations(filePath))
            {
                viewModel.Product.Calibrations.Add(c);
            }
        }
    }
}
