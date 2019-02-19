using System.Windows.Controls;
using WPFCalibrationFileEditor.ViewModel;

namespace WPFCalibrationFileEditor.View
{
    /// <summary>
    /// Interaction logic for SelectCalibrationFile.xaml
    /// </summary>
    public partial class SelectPlsxFile : Page
    {
        public SelectPlsxFile()
        {
            DataContext = new SelectPlsxFileViewModel();            
            InitializeComponent();
        }
    }
}
