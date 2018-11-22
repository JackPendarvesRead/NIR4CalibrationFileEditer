﻿using NIR4CalibrationEditorMethods;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using WPFCalibrationFileEditor.Domain;
using WPFCalibrationFileEditor.ViewModel;

namespace WPFCalibrationFileEditor
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class ShowParameters : Page
    {
        PageViewModel viewModel;

        public ShowParameters()
        {
            base.DataContext = viewModel;
            InitializeComponent();
        }
        public ShowParameters(object data) : this()
        {
            viewModel = data as PageViewModel;
            this.DataContext = data;
        }
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {

            var save = new FileSave();
            var writeFilePath = save.GetWriteFilePath(viewModel.CalibrationFilePath);
            using (var stream = new FileStream(writeFilePath, FileMode.Create, FileAccess.Write, FileShare.Delete))
            {
                save.Save(stream, viewModel.DataProvider);
            }
            System.Windows.Application.Current.Shutdown();
        }     

        private void DataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            if(e.EditAction == DataGridEditAction.Commit)
            {
                if (e.Column is DataGridBoundColumn column)
                {
                    var parameters = viewModel.Parameters;
                    var parameter = parameters[e.Row.GetIndex()];
                    var originalCode = parameter.Code;
                    var bindingPath = (column.Binding as Binding).Path.Path;
                    var tb = e.EditingElement as TextBox;
                    var value = tb.Text;
                    SetData(parameter, bindingPath, value);
                    
                    viewModel.Parameters = parameters;
                }
            }
        }

        private void SetData(NIR4Parameter changeParameter, string bindingPath, string replacement)
        {
            var file = viewModel.DataProvider.GetData();
            var parameters = RegularExpressions.findParameterGroups.Matches(file);

            foreach(Match parameter in parameters)
            {
                if(parameter.Groups["code"].Value == changeParameter.Code)
                {
                    file = file.Replace(parameter.ToString() ,RegularExpressions.findParameterGroups.ReplaceGroup(parameter.ToString(), bindingPath.ToLower(), replacement));
                    viewModel.DataProvider.SetData(file);
                }
            }
        }
    }
}
