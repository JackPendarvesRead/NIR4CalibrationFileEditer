using NIR4CalibrationEditorMethods;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFCalibrationFileEditor.Domain;

namespace WPFCalibrationFileEditor
{
    public class FileSave
    {
        public void Save(Stream stream, DataProvider data)
        {
            using (var sw = new StreamWriter(stream, Encoding.Default, 1024, true))
            {
                sw.Write(data.GetData());
                sw.Flush();
            }
        }

        public string GetWriteFilePath(string filePath)
        {
            var file = Path.GetFileNameWithoutExtension(filePath);
            var date = DateTime.Now.ToString("yyMMdd_hhmmss");
            return Path.Combine(Path.GetDirectoryName(filePath), $"{file}_updated_{date}.plsx");
        }
    }
}
