using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFCalibrationFileEditor.Logic
{
    public static class FilePathManipulation
    {
        public static string GetWriteFilePath(this string filePath)
        {
            return filePath.GetWriteFilePath(DateTime.Now.ToString("yyMMdd_hhmmss"));
        }
        public static string GetWriteFilePath(this string filePath, string appendToFilePath)
        {
            var filename = Path.GetFileNameWithoutExtension(filePath);
            return Path.Combine(Path.GetDirectoryName(filePath), $"{filename}_updated_{appendToFilePath}.plsx");
        }
    }
}
