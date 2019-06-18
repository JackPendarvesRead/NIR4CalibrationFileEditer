using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using WPFCalibrationFileEditor.Model;

namespace WPFCalibrationFileEditor.Logic.PlsxConverter
{
    public class DataProvider
    {
        private string data;
        public DataProvider(string data)
        {
            SetData(data);
        }
        public DataProvider(Stream dataStream)
        {
            using(var sr = new StreamReader(dataStream, Encoding.Default, true, 1024, true))
            {
                var data = sr.ReadToEnd();
                dataStream.Seek(0, SeekOrigin.Begin);
                SetData(data);
            }
        }
        public string GetData()
        {
            return data;
        }
        public void SetData(string data)
        {
            if (data.Length > 0)
            {
                this.data = data;
            }
        }

        public void UpdateDataProviderParameters(NIR4Parameter changeParameter, string columnName, string replacement)
        {
            var file = GetData();
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
                    SetData(file);
                }
            }
        }
    }
}