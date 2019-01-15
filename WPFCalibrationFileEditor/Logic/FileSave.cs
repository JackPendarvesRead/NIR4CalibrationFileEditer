using NIR4CalibrationEditorMethods.Domain;
using System;
using System.IO;
using System.Text;

namespace WPFCalibrationFileEditor.Logic
{
    public class FileSave
    {
        private readonly Stream stream;

        public FileSave(Stream stream)
        {
            this.stream = stream;
        }

        public void Save(DataProvider data)
        {
            using (var sw = new StreamWriter(stream, Encoding.Default, 1024, true))
            {
                sw.Write(data.GetData());
                sw.Flush();
            }
        }
    }
}
