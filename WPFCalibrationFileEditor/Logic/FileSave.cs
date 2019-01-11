using NIR4CalibrationEditorMethods.Domain;
using System;
using System.IO;
using System.Text;

namespace WPFCalibrationFileEditor.Logic
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
