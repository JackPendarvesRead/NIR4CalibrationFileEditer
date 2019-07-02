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

        public void UpdateDataProviderParameters(NIR4Parameter changeParameter)
        {
            var file = GetData();
            var fileParameters = RegularExpressions.findParameterGroups.Matches(file);

            foreach(Match fileParameter in fileParameters)
            {
                if(fileParameter.Groups["code"].Value == changeParameter.Code
                    || fileParameter.Groups["label"].Value == changeParameter.Label)
                {
                    file = file.Replace(fileParameter.Value, changeParameter.ToString());
                    SetData(file);
                }
            }
        }
    }
}