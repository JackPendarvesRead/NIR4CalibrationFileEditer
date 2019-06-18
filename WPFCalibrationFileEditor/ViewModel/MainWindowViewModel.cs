using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Windows.Input;
using WPFCalibrationFileEditor.ViewModel.Command;
using WPFCalibrationFileEditor.Model;
using WPFCalibrationFileEditor.Logic.PlsxConverter;
using WPFCalibrationFileEditor.Logic;

namespace WPFCalibrationFileEditor.ViewModel
{
    public class MainWindowViewModel
    {
        public MainWindowViewModel()
        {
            FileInformation = new PlsxFileInformation();
            SelectFileCommand = new SelectFileCommand(this);
            RunProcessCommand = new RunProcessCommand(this);
            DataGridChangeCommand = new DataGridChangeCommand(this);
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

        public ICommand DataGridChangeCommand { get; private set; }
        public void DataGridChange(NIR4Parameter parameter, string columnHeader)
        {
            //var replaceString = GetReplaceString(parameter, columnHeader);
            //var originalParameter = GetOriginalParameter(parameter, columnHeader);
            //UpdateDataProvider(originalParameter, columnHeader, replaceString);
                
        }

        private NIR4Parameter GetOriginalParameter(NIR4Parameter parameter, string colummHeader)
        {   
            foreach(var originalParameter in FileInformation.Parameters)
            {
                if(colummHeader.ToLower() != "code")
                {
                    if(parameter.Code == originalParameter.Code)
                    {
                        return originalParameter;
                    }
                }
                else
                {
                    if(parameter.Label == originalParameter.Label)
                    {
                        return originalParameter;
                    }
                }
            }
            throw new Exception("Could not find original parameter.");
        }

        private string GetReplaceString(NIR4Parameter parameter, string columnHeader)
        {
            switch(columnHeader.ToLower())
            {
                case "order":
                    return parameter.Order;
                case "tolerance":
                    return parameter.Tolerance;
                case "label":
                    return parameter.Label;
                case "unit":
                    return parameter.Unit;
                case "code":
                    return parameter.Code;
                default:
                    throw new Exception("Column header not found.");
            }
        }
        private void UpdateDataProvider(NIR4Parameter changeParameter, string columnName, string replacement)
        {
            var file = FileInformation.DataProvider.GetData();
            var parameters = RegularExpressions.findParameterGroups.Matches(file);

            foreach (Match parameter in parameters)
            {
                if (parameter.Groups["code"].Value == changeParameter.Code)
                {
                    file = file.Replace(
                        parameter.ToString(),
                        JacksUsefulLibrary.RegularExpressionMethods.RegexExtensionMethods.ReplaceGroup(
                            RegularExpressions.findParameterGroups, 
                            parameter.ToString(), 
                            columnName.ToLower(), 
                            replacement)
                        );
                    FileInformation.DataProvider.SetData(file);
                }
            }
        }
    }
}
