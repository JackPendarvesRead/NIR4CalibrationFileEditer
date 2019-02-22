using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using WPFCalibrationFileEditor.Command;
using WPFCalibrationFileEditor.Model;
using WPFCalibrationFileEditor.Model.PlsxConverter;

namespace WPFCalibrationFileEditor.ViewModel
{
    public class MainWindowViewModel
    {
        public MainWindowViewModel()
        {
            FileInformation = new PlsxFileInformation();
            SelectFileCommand = new SelectFileCommand(this);
            RunProcessCommand = new RunProcessCommand(this);
            SaveCommand = new SaveCommand(this);
        }
        
        public PlsxFileInformation FileInformation { get; set; }
        public string ConfigurationFileToUse { get; set; }

        public ICommand SelectFileCommand { get; private set; }
        public bool CanSelectFile { get => true; }
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

        public ICommand RunProcessCommand { get; private set; }
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
                MessageBox.Show("Process run successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
        }
        


        public ICommand SaveCommand { get; private set; }
        public void Save()
        {
            var filePath = FileInformation.CalibrationFilePath.GetWriteFilePath();
            using (var stream = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.Delete))
            {
                var save = new FileSave(stream);
                save.Save(FileInformation.DataProvider);
            }
            MessageBox.Show($"File save succesfully to {filePath}!");            
        }
        public bool CanSave
        {
            get
            {
                if (FileInformation.Parameters != null && FileInformation.DataProvider != null) { return true; }
                else { return false; }
            }
        }
        public ICommand DataGridChangeCommand { get; private set; }
    }
}
