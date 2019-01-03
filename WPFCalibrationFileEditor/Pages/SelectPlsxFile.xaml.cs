﻿using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.IO;
using WPFCalibrationFileEditor.ViewModel;
using WPFCalibrationFileEditor.Pages;

namespace WPFCalibrationFileEditor
{
    /// <summary>
    /// Interaction logic for SelectCalibrationFile.xaml
    /// </summary>
    public partial class SelectPlsxFile : Page
    {
        PageViewModel viewModel;

        public SelectPlsxFile()
        {
            viewModel = new PageViewModel();
            base.DataContext = viewModel;            
            InitializeComponent();
        }

        private void SelectFileButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog
            {
                Filter = "NIR4 calibration file|*.plsx",
                CheckFileExists = true
            };
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                viewModel.CalibrationFilePath = ofd.FileName;
                viewModel.CalibrationFileName = System.IO.Path.GetFileName(ofd.FileName);
            }
        }
        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            if(!string.IsNullOrEmpty(viewModel.CalibrationFilePath))
            {
                var loadingPage = new Loading();
                this.NavigationService.Navigate(loadingPage);

                using (var stream = new FileStream(viewModel.CalibrationFilePath, FileMode.Open, FileAccess.Read, FileShare.Delete))
                {
                    viewModel.DataProvider = new NIR4CalibrationEditorMethods.DataProvider(stream);
                }
                new ConvertPlsxProcess().Run(viewModel);
                var parametersPage = new ShowParameters(viewModel);
                this.NavigationService.Navigate(parametersPage);
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("First select a calibration file.");
            }
        }
    }
}