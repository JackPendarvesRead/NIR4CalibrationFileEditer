using System.Windows.Forms;
using System.Windows.Input;
using WPFCalibrationFileEditor.Command;
using WPFCalibrationFileEditor.Model;
using WPFCalibrationFileEditor.Model.PlsxConverter;
using WPFCalibrationFileEditor.View;

namespace WPFCalibrationFileEditor.ViewModel
{
    public class SelectPlsxFileViewModel
    {   
        public SelectPlsxFileViewModel()
        {
            SaveChangesCommand = new SelectPlsxNavigateCommand(this);
            FileSelectCommand = new SelectPlsxFileSelectCommand(this);
            fileInformation = new PlsxFileInformation();
        }

        private PlsxFileInformation fileInformation;
        public PlsxFileInformation FileInformation
        {
            get { return fileInformation; }
        }        

        public ICommand SaveChangesCommand { get; private set; }
        public void SaveChanges()
        {
            //do the conversion stuff
            var converter = new PlsxConverterProcess(fileInformation);
            converter.Run();

            //get new page
        }

        public ICommand FileSelectCommand { get; private set; }
        public void SelectFile()
        {
            OpenFileDialog ofd = new OpenFileDialog
            {
                Filter = "NIR4 calibration file|*.plsx",
                CheckFileExists = true
            };
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                fileInformation.CalibrationFilePath = ofd.FileName;
            }
        }
    }
}
