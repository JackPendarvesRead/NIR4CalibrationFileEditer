using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFCalibrationFileEditor.Model.PlsxConverter;

namespace WPFCalibrationFileEditor.Model
{
    internal class FileSave
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
