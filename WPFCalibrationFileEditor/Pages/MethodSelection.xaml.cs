using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFCalibrationFileEditor.Pages
{
    /// <summary>
    /// Interaction logic for MethodSelection.xaml
    /// </summary>
    public partial class MethodSelection : Page
    {
        public MethodSelection()
        {
            InitializeComponent();
        }

        private void SelectFoss_Click(object sender, RoutedEventArgs e)
        {
            var page = new SelectFossFiles();
            this.NavigationService.Navigate(page);
        }

        private void SelectPlsx_Click(object sender, RoutedEventArgs e)
        {
            var page = new SelectPlsxFile();
            this.NavigationService.Navigate(page);
        }
    }
}
