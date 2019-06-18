using WPFCalibrationFileEditor.Model;
using WPFCalibrationFileEditor.Logic.PlsxConverter;

namespace WPFCalibrationFileEditor.Logic.PlsxConverter.PlsxConverterMethods
{
    public interface IMethod
    {
        void Run(DataProvider dataProvider);
    }
}
