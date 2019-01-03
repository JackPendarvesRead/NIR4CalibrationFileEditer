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
        public void Save(DataProvider data, string filePath)
        {
            using (var stream = new FileStream(GetWriteFilePath(filePath), FileMode.Create, FileAccess.Write, FileShare.Delete))
            using (var sw = new StreamWriter(stream, Encoding.Default, 1024, true))
            {
                sw.Write(data.GetData());
                sw.Flush();
            }
        }

        private string GetWriteFilePath(string filePath)
        {
            var file = Path.GetFileNameWithoutExtension(filePath);
            var date = DateTime.Now.ToString("yyMMdd_hhmmss");
            return Path.Combine(Path.GetDirectoryName(filePath), $"{file}_updated_{date}.plsx");
        }
    }
}
