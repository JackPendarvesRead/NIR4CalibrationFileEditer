using System.Windows.Controls;
using WPFCalibrationFileEditor.ViewModel;

namespace WPFCalibrationFileEditor.View
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class ShowParameters : Page
    {
        ShowParametersViewModel viewModel;
        public ShowParameters(ShowParametersViewModel viewModel)
        {
            this.viewModel = viewModel;
            DataContext = viewModel;
            InitializeComponent();
        }
        //private void SaveButton_Click(object sender, RoutedEventArgs e)
        //{
        //    var outputFilePath = viewModel.CalibrationFilePath.GetWriteFilePath();
        //    using (var stream = new FileStream(outputFilePath, FileMode.Create, FileAccess.Write, FileShare.Delete))
        //    {
        //        new FileSave(stream).Save(viewModel.DataProvider);
        //    }
        //    System.Windows.Application.Current.Shutdown();
            
        //}     

        //private void DataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        //{
        //    if(e.EditAction == DataGridEditAction.Commit)
        //    {
        //        if (e.Column is DataGridBoundColumn column)
        //        {
        //            var parameters = viewModel.Parameters;
        //            var parameter = parameters[e.Row.GetIndex()];
        //            var originalCode = parameter.Code;
        //            var bindingPath = (column.Binding as Binding).Path.Path;
        //            var tb = e.EditingElement as TextBox;
        //            var value = tb.Text;
        //            SetData(parameter, bindingPath, value);                    
        //            viewModel.Parameters = parameters;
        //        }
        //    }
        //}

        //private void SetData(NIR4Parameter changeParameter, string bindingPath, string replacement)
        //{
        //    var file = viewModel.DataProvider.GetData();
        //    var parameters = RegularExpressions.findParameterGroups.Matches(file);

        //    foreach(Match parameter in parameters)
        //    {
        //        if(parameter.Groups["code"].Value == changeParameter.Code)
        //        {
        //            file = file.Replace(
        //                parameter.ToString(), 
        //                JacksUsefulLibrary.RegularExpressionMethods.RegexExtensionMethods.ReplaceGroup(RegularExpressions.findParameterGroups, parameter.ToString(), bindingPath.ToLower(), replacement)
        //                );
        //            viewModel.DataProvider.SetData(file);
        //        }
        //    }
        //}
    }
}
