using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFCalibrationFileEditor.Logic
{
    public class FilePathManipulation
    {
        public string GetWriteFilePath(string filePath)
        {
            var date = DateTime.Now.ToString("yyMMdd_hhmmss");
            return GetWriteFilePath(filePath, date);
        }
        public string GetWriteFilePath(string filePath, string date)
        {
            var file = Path.GetFileNameWithoutExtension(filePath);
            return Path.Combine(Path.GetDirectoryName(filePath), $"{file}_updated_{date}.plsx");
        }
    }
}
