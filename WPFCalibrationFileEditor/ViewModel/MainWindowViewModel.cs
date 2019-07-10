using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Windows.Input;
using WPFCalibrationFileEditor.ViewModel.Command;
using WPFCalibrationFileEditor.Model;
using WPFCalibrationFileEditor.Logic.PlsxConverter;
using WPFCalibrationFileEditor.Logic;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace WPFCalibrationFileEditor.ViewModel
{
    public class MainWindowViewModel
    {
        #region Commands
        public ICommand SaveCommand { get; private set; }
        public ICommand RunProcessCommand { get; private set; }
        public ICommand SelectFileCommand { get; private set; }
        #endregion

        public MainWindowViewModel()
        {
            FileInformation = new PlsxFileInformation();
            SelectFileCommand = new SelectFileCommand(this);
            RunProcessCommand = new RunProcessCommand(this);
            SaveCommand = new SaveCommand(this);
        }

        public List<string> aaa = new List<string>() {"1", "2", "3"};

        #region Fields

        public ObservableCollection<MyParamterConfig> ParameterConfig
        {
            get
            {
                var configImporter = new ParameterConfigFinder();
                var configs = configImporter.Import();
                return new ObservableCollection<MyParamterConfig>(configs);
            }
        }
        

        public PlsxFileInformation FileInformation { get; set; }
        #endregion

        #region Methods

        public void SelectFile()
        {
            OpenFileDialog ofd = new OpenFileDialog
            {
                Filter = "NIR4 calibration file|*.plsx",
                CheckFileExists = true
            };
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                FileInformation.CalibrationFilePath = ofd.FileName;
            }
        }

        public bool CanRunProcess
        {
            get
            {
                if (string.IsNullOrWhiteSpace(FileInformation.CalibrationFilePath)) { return false; }
                else { return true; }
            }
        }
        public void RunProcess(string config)
        {
            try
            {
                var process = new PlsxConverterProcess(FileInformation, config);
                process.Run();
                FileInformation.Parameters = process.GetParameters();
                FileInformation.DataProvider = process.Data;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
        }



        public void Save()
        {
            var filePath = FileInformation.CalibrationFilePath.GetWriteFilePath();
            using (var stream = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.Delete))
            {
                var save = new FileSave(stream);
                save.Save(FileInformation.DataProvider);
            }
            MessageBox.Show("Save successful.");
        }
        public bool CanSave
        {
            get
            {
                if (FileInformation.Parameters != null && FileInformation.DataProvider != null) { return true; }
                else { return false; }
            }
        }       

        #endregion
    }
}
