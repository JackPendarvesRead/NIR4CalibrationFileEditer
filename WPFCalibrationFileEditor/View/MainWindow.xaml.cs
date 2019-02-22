using System.Windows;
using System.Windows.Navigation;
using WPFCalibrationFileEditor.ViewModel;

namespace WPFCalibrationFileEditor.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            DataContext = new MainWindowViewModel();
        }
    }
}
