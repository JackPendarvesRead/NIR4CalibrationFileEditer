using System.IO;
using System.Text;

namespace WPFCalibrationFileEditor.Model.PlsxConverter
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
    }
}